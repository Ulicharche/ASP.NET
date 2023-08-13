using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<string>> GetAllUsers()
        {
            return Ok(StaticDb.UsersName);
        }

        [HttpGet("{index}")]
        public ActionResult<string> GetUserByIndex(int index)
        {
            try
            {
                if (index < StaticDb.UsersName.Count)
                {
                    return BadRequest("Indeksot ima negativna vrednost");
                }
                if (index >= StaticDb.UsersName.Count)
                {
                    return NotFound($"{index}");
                }
                return Ok(StaticDb.UsersName[index]);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

