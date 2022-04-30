using Eticaret.Business.Services;
using Eticaret.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Eticaret.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: api/<UserController>
        [HttpGet]
        public List<User> Get()
        {
            return _userService.List();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _userService.GetById(id);
        }

        // POST api/<UserController>
        [HttpPost("Add")]
        public void Add(User data)
        {
            _userService.Add(data);
        }

        [HttpPost("SendFile")]
        public IActionResult SendFile()
        {

          var  file = HttpContext.Request.Form.Files[0];

            if (file.Length > 0)
            {
                var filePath = Path.GetTempFileName();

                using (var stream = System.IO.File.Create("C:\\xxxx\\aaa.jpg"))
                {
                    file.CopyTo(stream);
                }
            }


            // Process uploaded files
            // Don't rely on or trust the FileName property without validation.

            return Ok("Ok");
        }


    }
}
