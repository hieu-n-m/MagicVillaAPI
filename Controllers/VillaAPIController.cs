using AutoMapper;
using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Logging;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.DTO;
using MagicVilla_VillaAPI.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text.Json;

namespace MagicVilla_VillaAPI.Controllers
{

	[Route("api/VillaAPI")]
	//[Route("api/[controller]")]
	[ApiController]
	// Controller annotation to get built-in support for
	// other data annotations 
	public class VillaAPIController : ControllerBase
	// ControllerBase contains common methods for returning
	// data and user related to controller
	{
		// logger is automatically registed in CreateBuilder
		// (check appsettings.json)
		// you just need to implement
		private readonly ILogging _logger;
		private readonly IVillaRepository _villaRepository;
		private readonly IMapper _mapper;
		protected ApiResponse _response;
		public VillaAPIController(IVillaRepository villaRepository, ILogging logger, IMapper mapper)
		{
			_villaRepository = villaRepository;
			_logger = logger;
			_mapper = mapper;
			_response = new();
        }

		[HttpGet] // hey, this is Get endpoint
		[Authorize]
		[ProducesResponseType(StatusCodes.Status403Forbidden)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<ApiResponse>> GetVillas()
		{
			try
			{
				_logger.Log("Get all Villas", "");
                _response.Result = _mapper.Map<List<VillaDTO>>(await _villaRepository.GetAllAsync());
				_response.HttpStatusCode = HttpStatusCode.OK;
				_response.IsSuccess = true;
				return Ok(_response);
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.ErrorMessages = new List<string>() { ex.ToString() };
			}
			return _response;
		}

		[HttpGet("{id:int}", Name = "GetVillaById")]
		// if not define here, it will automatically define as Get
		[Authorize]
		[ProducesResponseType(StatusCodes.Status200OK)]
		//[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VillaDTO))] 
		// if dont want to specify the generic type of ActionResult
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status403Forbidden)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		// define posible response 
		public async Task<ActionResult<ApiResponse>> GetVillasById(int id)
		{
			try
			{
				if (id == 0)
				{
					_logger.Log("Cannot get villa of id " + id, "error");
					_response.HttpStatusCode = HttpStatusCode.BadRequest;
					return BadRequest(_response);
				}
				var villa = await _villaRepository.GetOneAsync(v => v.Id == id);
				if (villa == null)
				{
					_response.HttpStatusCode = HttpStatusCode.NotFound;
					return NotFound(_response);
				}
				_response.Result = _mapper.Map<VillaDTO>(villa);
				_response.HttpStatusCode = HttpStatusCode.OK;
				_response.IsSuccess = true;
				return Ok(_response);
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.ErrorMessages = new List<string>() { ex.ToString() };
			}
			return _response;
		}

		[HttpPost]
		[Authorize(Roles = "admin")]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status403Forbidden)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		//[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult<ApiResponse>> AddVilla([FromBody] VillaCreateDTO villaCreate)
		{
			try
			{
				// ModelState is validated before enter method by ApiController
				//if (!ModelState.IsValid)
				//{
				//	return BadRequest(ModelState);
				//}
				if (villaCreate == null)
				{
					_response.HttpStatusCode = HttpStatusCode.BadRequest;
					return BadRequest(_response);
				}
				// create custom validation on model using ModelState
				if (await _villaRepository.GetOneAsync(v => v.Name.ToLower() == villaCreate.Name.ToLower()) != null)
				{
					ModelState.AddModelError("NameError", "Name already exists");
					_response.HttpStatusCode = HttpStatusCode.BadRequest;
					return BadRequest(ModelState);
				}
				//if (villa.Id != 0)
				//{
				//	return StatusCode(StatusCodes.Status500InternalServerError);
				//	// if dont want built-in action
				//}
				var villaTransfer = _mapper.Map<Villa>(villaCreate);
				await _villaRepository.AddAsync(villaTransfer);
				_response.Result = villaTransfer;
				_response.HttpStatusCode = HttpStatusCode.Created;
				_response.IsSuccess = true;
				return CreatedAtRoute("GetVillaById", new { id = villaTransfer.Id }, _response);
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.ErrorMessages = new List<string>() { ex.ToString() };
			}
			return _response;
		}

		[HttpDelete("{id:int}", Name = "RemoveVilla")]
		[Authorize(Roles = "admin")]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status403Forbidden)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		public async Task<ActionResult<ApiResponse>> RemoveVilla(int id)
		{
			try
			{
				if (id == 0)
				{
					_response.HttpStatusCode = HttpStatusCode.BadRequest;
					return BadRequest(_response);
				}
				var villa = await _villaRepository.GetOneAsync(v => v.Id == id);
				if (villa == null)
				{
					_response.HttpStatusCode = HttpStatusCode.BadRequest;
					return NotFound(_response);
				}
				await _villaRepository.RemoveAsync(villa);
				_response.HttpStatusCode = HttpStatusCode.NoContent;
				_response.IsSuccess = true;
				return Ok(_response);
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.ErrorMessages = new List<string>() { ex.ToString() };
			}
			return _response;
		}

		[HttpPut("{id:int}", Name = "UpdateVilla")]
		[Authorize(Roles = "admin")]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status403Forbidden)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		public async Task<ActionResult<ApiResponse>> UpdateVilla(int id, [FromBody] VillaUpdateDTO villaUpdateData)
		{
			try
			{
				if ((villaUpdateData == null) || (id != villaUpdateData.Id))
				{
					_response.HttpStatusCode = HttpStatusCode.BadRequest;
					return BadRequest(_response);
				}
				var villaTransfer = _mapper.Map<Villa>(villaUpdateData);
				await _villaRepository.UpdateAsync(villaTransfer);
				_response.HttpStatusCode = HttpStatusCode.NoContent;
				_response.IsSuccess = true;
				return Ok(_response);
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.ErrorMessages = new List<string>() { ex.ToString() };
			}
			return _response;
		}

		// Install JsonPatch and NewtonsoftJson
		// https://jsonpatch.com/
		[HttpPatch("{id:int}", Name = "UpdatePartialVilla")]
		[Authorize(Roles = "admin")]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status403Forbidden)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		public async Task<IActionResult> UpdatePartialVilla(int id, JsonPatchDocument<VillaUpdateDTO> patchDTO)
		{
			if ((patchDTO == null) || (id == 0))
			{
				return BadRequest();
			}
			var villa = await _villaRepository.GetOneAsync(v => v.Id == id, tracking: false)!;
			if (villa == null)
			{
				return BadRequest();
			}
			var villaDTOTransfer = _mapper.Map<VillaUpdateDTO>(villa);
			patchDTO.ApplyTo(villaDTOTransfer, ModelState);
			var villaTransfer = _mapper.Map<Villa>(villaDTOTransfer);
			await _villaRepository.UpdateAsync(villaTransfer);
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			return NoContent();
		}
	}
}
