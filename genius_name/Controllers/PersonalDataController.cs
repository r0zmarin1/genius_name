using genius_name.Model;
using genius_name.Tools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace genius_name.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalDataController : ControllerBase
    {
        readonly DB.DB database;
        readonly ValidateSnils validateSnils;

        public PersonalDataController(DB.DB database, ValidateSnils validateSnils)
        {
            this.database = database;
            this.validateSnils = validateSnils;
        }

        [HttpPost("CreatePassport")]
        public async void CreatePassport(Passport passport)
        {
            database.Passports.Add(passport);
            await database.SaveChangesAsync();
        }

        [HttpPost("CreateSnils")]
        public async Task<ActionResult> CreateSnils(Snils snils)
        {
            if (validateSnils.validateSnils(snils.Number) == false)
            {
                return BadRequest("ПЕПЕЦА");
            }
            database.Snilses.Add(snils);
            await database.SaveChangesAsync();
            return Ok("не пепеца все гуд");
        }

        [HttpPost("SearchHumanPassport")]
        public async Task<ActionResult<Passport>> SearchHumanPassport(Search search)
        {
            if (string.IsNullOrEmpty(search.FirstName) || string.IsNullOrEmpty(search.LastName))
                return BadRequest("Введите имя и фамилию полностью");
            var find =  await database.Passports.FirstOrDefaultAsync(s => s.FirstName.Equals(search.FirstName, StringComparison.OrdinalIgnoreCase)
            && s.LastName.Equals(search.LastName, StringComparison.OrdinalIgnoreCase));
            if (find == null)
                return NotFound("Не найдено");
            return find;
        }

        [HttpPost("SearchHumanSnils")]
        public async Task<ActionResult<Snils>> SearchHumanSnils(Search search)
        {
            if (string.IsNullOrEmpty(search.FirstName) || string.IsNullOrEmpty(search.LastName))
                return BadRequest("Введите имя и фамилию полностью");
            var find = await database.Snilses.FirstOrDefaultAsync(s => s.FirstName.Equals(search.FirstName, StringComparison.OrdinalIgnoreCase)
            && s.LastName.Equals(search.LastName, StringComparison.OrdinalIgnoreCase));
            if (find == null)
                return NotFound("Не найдено");
            return find;
        }

        [HttpPost("SendClaim")]
        public async Task<ActionResult<Passport>> SendClaim(Passport passport)
        {
            if (string.IsNullOrEmpty(passport.Serial) || passport.Number == 0 )
                return BadRequest("Введите серию и номер полностью");
            var find = await database.Passports.FirstOrDefaultAsync(s => s.Serial.Equals(passport.Serial, StringComparison.OrdinalIgnoreCase)
            && s.Number.Equals(passport.Number));
            if (find == null)
                return NotFound("Такого паспорта не существует");
            else
            {
                database.Passports.Remove(passport);
                return Ok("Ваши данные удалены");
            }
        }
    }
}
