using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LandOfTamagotchiAPI.Models;
using System;
using Microsoft.EntityFrameworkCore;

namespace LandOfTamagotchiAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class TamagotchisController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public TamagotchisController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Tamagotchi>> GetAll()
        {
            var allTheTamagotchis = _context.Tamagotchis;

            return Ok(allTheTamagotchis);
        }
    }
}