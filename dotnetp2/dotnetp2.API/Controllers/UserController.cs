
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dotnetp2.DTO;
using dotnetp2.Service;
using Microsoft.AspNetCore.Mvc;

namespace dotnetp2.API
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> GetByIdAsync(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetAllAsync()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateAsync(UserModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = await _userService.CreateAsync(user);
            return CreatedAtAction(nameof(GetByIdAsync), new { id }, id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, UserModel user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updated = await _userService.UpdateAsync(user);
            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var deleted = await _userService.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
