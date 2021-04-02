using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.DTOs;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("update")]
        public ActionResult Update(UserForRegisterDto userForRegisterDto,int userId)
        {
            var userExists = _userService.UserUpdateExists(userForRegisterDto.Email, userId);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }

            var updatedResult = _userService.Update(userForRegisterDto, userForRegisterDto.Password, userId);
            
            if (updatedResult.Success)
            {
                return Ok(updatedResult);
            }

            return BadRequest(updatedResult.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int userId)
        {
            var result = _userService.GetById(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
