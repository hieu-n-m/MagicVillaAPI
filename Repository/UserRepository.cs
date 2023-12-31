﻿using AutoMapper;
using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.DTO;
using MagicVilla_VillaAPI.Repository.IRepository;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MagicVilla_VillaAPI.Repository
{
	public class UserRepository : IUserRepository
	{
		private readonly VillaContext _context;
		private readonly IMapper _mapper;
		private string secretKey;
		public UserRepository(VillaContext context, IMapper mapper, IConfiguration configuration)
		{
			_context = context;
			_mapper = mapper;
			secretKey = configuration.GetValue<string>("APISettings:Secret");
		}

		public bool IsUniqueUser(string username)
		{
			var user = _context.LocalUsers.FirstOrDefault(u => u.UserName == username);
			if (user == null)
			{
				return true;
			}
			return false;
		}

		public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
		{
			var user = _context.LocalUsers
				.FirstOrDefault(
					u => (u.UserName.ToLower() ==  loginRequestDTO.UserName.ToLower() 
					&&
					u.Password == loginRequestDTO.Password)
				);
			if (user == null)
			{
				return new LoginResponseDTO()
				{
					Token = "",
					User = null
				};
			}
			var tokenHandle = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(secretKey);

			var tokenDescriptor = new SecurityTokenDescriptor()
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
					new Claim(ClaimTypes.Name, user.Id.ToString()),
					new Claim(ClaimTypes.Role, user.Role)
				}),
				Expires = DateTime.UtcNow.AddDays(7),
				SigningCredentials = new (
					new SymmetricSecurityKey(key),
					SecurityAlgorithms.HmacSha256Signature
				)
			};

			var token = tokenHandle.CreateToken(tokenDescriptor);
			var loginResponseDTO = new LoginResponseDTO()
			{
				Token = tokenHandle.WriteToken(token), // serialize token
				User = user
			};
			return loginResponseDTO;
		}

		public async Task<LocalUser> Register(RegisterationRequestDTO registerationRequestDTO)
		{
			var user = _mapper.Map<LocalUser>(registerationRequestDTO);
			await _context.LocalUsers.AddAsync(user);
			await _context.SaveChangesAsync();
			user.Password = "";
			return user;
		}
	}
}
