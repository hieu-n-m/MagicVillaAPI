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

	[Route("api/VillaNumberAPI")]
	[ApiController]
	public class VillaNumberAPIController : ControllerBase
	{
		private readonly ILogging _logger;
		private readonly IVillaNumberRepository _villaNumberRepository;
		private readonly IVillaRepository _villaRepository;
		private readonly IMapper _mapper;
		protected ApiResponse _response;
		public VillaNumberAPIController(IVillaNumberRepository villaNumberRepository, IVillaRepository villaRepository, ILogging logger, IMapper mapper)
		{
			_villaNumberRepository = villaNumberRepository;
			_villaRepository = villaRepository;
			_logger = logger;
			_mapper = mapper;
			_response = new();
		}

		[HttpGet]
		[Authorize]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status403Forbidden)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		public async Task<ActionResult<ApiResponse>> GetVillaNumbers()
		{
			try
			{
				_logger.Log("Get all numbered villas", "");
				_response.Result = _mapper.Map<List<VillaNumberDTO>>(await _villaNumberRepository.GetAllAsync());
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

		[HttpGet("{no:int}", Name = "GetVillaNumbersByNo")]
		[Authorize]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status403Forbidden)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		public async Task<ActionResult<ApiResponse>> GetVillaNumbersByNo(int no)
		{
			try
			{
				if (no == 0)
				{
					_logger.Log("Cannot get villa of No " + no, "error");
					_response.HttpStatusCode = HttpStatusCode.BadRequest;
					return BadRequest(_response);
				}
				var villa = await _villaNumberRepository.GetOneAsync(v => v.VillaNo == no);
				if (villa == null)
				{
					_response.HttpStatusCode = HttpStatusCode.NotFound;
					return NotFound(_response);
				}
				_response.Result = _mapper.Map<VillaNumberDTO>(villa);
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
		public async Task<ActionResult<ApiResponse>> AddVillaNumber([FromBody] VillaNumberCreateDTO villaCreate)
		{
			try
			{
				if (villaCreate == null)
				{
					_response.HttpStatusCode = HttpStatusCode.BadRequest;
					return BadRequest(_response);
				}
				if (await _villaNumberRepository.GetOneAsync(v => v.VillaNo == villaCreate.VillaNo) != null)
				{
					ModelState.AddModelError("VillaError", "VillaNumber already exists");
					_response.HttpStatusCode = HttpStatusCode.BadRequest;
					return BadRequest(ModelState);
				}
				if (await _villaRepository.GetOneAsync(v => v.Id == villaCreate.VillaID) != null)
				{
					ModelState.AddModelError("VillaError", "Villa already exists");
					_response.HttpStatusCode = HttpStatusCode.BadRequest;
					return BadRequest(ModelState);
				}
				var villaTransfer = _mapper.Map<VillaNumber>(villaCreate);
				await _villaNumberRepository.AddAsync(villaTransfer);
				_response.Result = villaTransfer;
				_response.HttpStatusCode = HttpStatusCode.Created;
				_response.IsSuccess = true;
				return CreatedAtRoute("GetVillaNumbersByNo", new { no = villaTransfer.VillaNo }, _response);
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.ErrorMessages = new List<string>() { ex.ToString() };
			}
			return _response;
		}

		[HttpDelete("{no:int}", Name = "RemoveVillaNumber")]
		[Authorize(Roles = "admin")]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status403Forbidden)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		public async Task<ActionResult<ApiResponse>> RemoveVillaNumber(int no)
		{
			try
			{
				if (no == 0)
				{
					_response.HttpStatusCode = HttpStatusCode.BadRequest;
					return BadRequest(_response);
				}
				var villa = await _villaNumberRepository.GetOneAsync(v => v.VillaNo == no);
				if (villa == null)
				{
					_response.HttpStatusCode = HttpStatusCode.BadRequest;
					return NotFound(_response);
				}
				await _villaNumberRepository.RemoveAsync(villa);
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

		[HttpPut("{no:int}", Name = "UpdateVillaNumber")]
		[Authorize(Roles = "admin")]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status403Forbidden)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		public async Task<ActionResult<ApiResponse>> UpdateVillaNumber(int no, [FromBody] VillaNumberUpdateDTO villaUpdateData)
		{
			try
			{
				if ((villaUpdateData == null) || (no == villaUpdateData.VillaNo))
				{
					_response.HttpStatusCode = HttpStatusCode.BadRequest;
					return BadRequest(_response);
				}
				if (await _villaRepository.GetOneAsync(v => v.Id == villaUpdateData.VillaID) != null)
				{
					ModelState.AddModelError("VillaError", "Villa already exists");
					_response.HttpStatusCode = HttpStatusCode.BadRequest;
					return BadRequest(ModelState);
				}
				var villaTransfer = _mapper.Map<VillaNumber>(villaUpdateData);
				await _villaNumberRepository.UpdateAsync(villaTransfer);
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

		[HttpPatch("{no:int}", Name = "UpdatePartialVillaNumber")]
		[Authorize(Roles = "admin")]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status403Forbidden)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		public async Task<IActionResult> UpdatePartialVillaNumber(int no, JsonPatchDocument<VillaNumberUpdateDTO> patchDTO)
		{
			if ((patchDTO == null) || (no == 0))
			{
				return BadRequest();
			}
			var villa = await _villaNumberRepository.GetOneAsync(v => v.VillaNo == no, tracking: false)!;
			if (villa == null)
			{
				return BadRequest();
			}
			var villaDTOTransfer = _mapper.Map<VillaNumberUpdateDTO>(villa);
			patchDTO.ApplyTo(villaDTOTransfer, ModelState);
			var villaTransfer = _mapper.Map<VillaNumber>(villaDTOTransfer);
			await _villaNumberRepository.UpdateAsync(villaTransfer);
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			return NoContent();
		}
	}
}
