using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.DTO;
using MagicVilla_VillaAPI.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Net;
using Microsoft.AspNetCore.Authorization;

namespace MagicVilla_VillaAPI.Controllers
{
	[Route("api/Users")]
	[ApiController]
	public class UserController : Controller
	{
		private readonly IUserRepository _userRepository;
		protected ApiResponse _response;
		public UserController(IUserRepository userRepository)
		{
			_userRepository = userRepository;
			_response = new();
		}
		[HttpPost("login")]
		[AllowAnonymous]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<ActionResult<ApiResponse>> Login([FromBody] LoginRequestDTO loginRequest)
		{
			var loginResponse = await _userRepository.Login(loginRequest);

			if (loginResponse.User == null || string.IsNullOrEmpty(loginResponse.Token))
			{
				_response.IsSuccess = false;
				_response.HttpStatusCode = HttpStatusCode.BadRequest;
				_response.ErrorMessages.Add("Username or password is incorrect");
				return BadRequest(_response);
			}
			_response.IsSuccess = true;
			_response.HttpStatusCode = HttpStatusCode.OK;
			_response.Result = loginResponse;

			return Ok(_response);
		}
		[HttpPost("register")]
		[AllowAnonymous]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<ActionResult<ApiResponse>> Register([FromBody] RegisterationRequestDTO registerationRequest)
		{
			var isUnique = _userRepository.IsUniqueUser(registerationRequest.UserName);
			if (!isUnique)
			{
				_response.IsSuccess = false;
				_response.HttpStatusCode = HttpStatusCode.BadRequest;
				_response.ErrorMessages.Add("Username already exists");
				return BadRequest(_response);
			}
			var user = await _userRepository.Register(registerationRequest);
			if (user == null)
			{
				_response.IsSuccess = false;
				_response.HttpStatusCode = HttpStatusCode.BadRequest;
				_response.ErrorMessages.Add("Register error");
				return BadRequest(_response);
			}
			_response.IsSuccess = true;
			_response.HttpStatusCode = HttpStatusCode.OK;

			return Ok(_response);
		}
	}
}
