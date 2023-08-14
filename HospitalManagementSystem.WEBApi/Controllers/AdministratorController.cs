using Azure.Core;
using Hospital_Management_System_Applications.Features.Administrator.Queries;
using Hospital_Management_System_Domains.Entities;
using Hospital_Management_System_Infrastructure.Services;
using Hospital_Management_System_Persistence.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Hospital_Management_System_WEB_API.Controllers
{
    public class AdministratorController : ApplicationController
    {
        private readonly HospitalManagementContext _context;
        private readonly ICustomerAdministratorService _customerAdministratorService;
        private readonly IConfiguration _configuration;

        public AdministratorController(HospitalManagementContext context, ICustomerAdministratorService customerAdministratorService, 
            IConfiguration configuration)
        {
            _context = context;
            _customerAdministratorService = customerAdministratorService;
            _configuration = configuration;
        }

        /// <summary>
        /// Login operation with our application
        /// </summary>
        /// <param name="customerAdministratorDTO"></param>
        /// <returns></returns>
        /*[HttpPost("Login")]
        public async Task<ActionResult> Login([FromBody] ReturnCustomerAdministratorDTO customerAdministratorDTO)
        {
            var customer = await _context.CustomerAdministrators
                .Where(x => x.Email == customerAdministratorDTO.Email && x.IsDeleted == false).SingleOrDefaultAsync();

            if (customer is null) { return NotFound(); }

            if (customer.Email != customerAdministratorDTO.Email) { return BadRequest(); }

            string sequence = BCrypt.Net.BCrypt.GenerateSalt(); ;
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(customerAdministratorDTO.Password, sequence);

            bool verified = BCrypt.Net.BCrypt.Verify(customer.Password, passwordHash);
            if (verified)
            {
              *//*  string token = InsertToken(customer);
                var data = new UserAdminResponse();
                data.Email = user.Email;
                data.Password = user.Password;
                data.UserId = user.UserId;
                data.Token = token;
                return Ok(data);*//*
            }
            else
            {
                return Ok("Password is not match");
            }

        }*/

        private string InsertToken(CustomerAdministrator customer)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, customer.Email)
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("Appsettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            DateTime d1 = DateTime.Now;
            DateTime d2 = d1.AddSeconds(60);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: d2,
                signingCredentials: creds
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
