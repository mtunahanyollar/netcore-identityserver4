﻿using IdentityServerIdentityAPI.AuthServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace IdentityServerIdentityAPI.AuthServer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(LocalApi.PolicyName)]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
         
        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(UserRecordViewModel userRecordViewModel)
        {
            ApplicationUser applicationUser = new ApplicationUser();
            applicationUser.UserName = userRecordViewModel.UserName;
            applicationUser.Email = userRecordViewModel.Email;
            applicationUser.City= userRecordViewModel.City;

            var result = await _userManager.CreateAsync(applicationUser, userRecordViewModel.Password);

            if(!result.Succeeded)
            {
                return BadRequest(result.Errors.Select(x=>x.Description));
            }

            return Ok("User Created!");
        }
    }
}
