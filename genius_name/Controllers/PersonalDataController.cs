using genius_name.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace genius_name.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalDataController : ControllerBase
    {
        readonly DB.DB database;

        public PersonalDataController(DB.DB database)
        {
            this.database = database;
        }

        [HttpPost("CreatePassport")]
        public async void CreatePassport(Passport passport)
        {
            database.Passports.Add(passport);
            await database.SaveChangesAsync();
        }

        [HttpPost("CreateSnils")]
        public async void CreateSnils(Snils snils)
        {

        }

        [HttpPost("SearchHumanPassport")]
        public async void SearchHumanPassport(Search search)
        {

        }

        [HttpPost("SendClaim")]
        public async void SendClaim(Passport passport)
        {

        }
    }
}
