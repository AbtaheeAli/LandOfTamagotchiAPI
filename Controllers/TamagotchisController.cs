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

        [HttpGet("{id}")]
        public ActionResult<Tamagotchi> GetByID(int id)
        {
            var tamagotchi = _context.Tamagotchis.FirstOrDefault(tamagotchi => tamagotchi.Id == id);

            if (tamagotchi == null)
            {
                return NotFound();
            }

            return Ok(tamagotchi);
        }

        [HttpPost]
        public ActionResult<Tamagotchi> Create(Tamagotchi tamagotchiToCreate)
        {
            if (tamagotchiToCreate.HungerLevel != 0)
            {
                var errorMessage = new
                {
                    message = $"You requested hunger level to be at{tamagotchiToCreate.HungerLevel}, but each tamagotchi starts at a hunger level of 0. Please try again with the input of 0."
                };

                return UnprocessableEntity(errorMessage);
            }

            if (tamagotchiToCreate.HappinessLevel != 0)
            {
                var errorMessage = new
                {
                    message = $"You requested happiness level to be at{tamagotchiToCreate.HappinessLevel}, but each tamagotchi starts at a happiness level of 0. Please try again with the input of 0."
                };

                return UnprocessableEntity(errorMessage);
            }

            if (tamagotchiToCreate.Birthday != DateTime.Today)
            {
                var errorMessage = new
                {
                    message = $"You requested the tamagotchi's birthday to be at {tamagotchiToCreate.Birthday}, but each tamagotchi is given a birthday of the day it was created. Please try again."
                };

                return UnprocessableEntity(errorMessage);
            }

            _context.Tamagotchis.Add(tamagotchiToCreate);
            _context.SaveChanges();

            return CreatedAtAction(null, null, tamagotchiToCreate);
        }

        [HttpPost("{id}/playtimes")]
        public ActionResult<Tamagotchi> UpdatePlayTime(int id, string playtime)
        {
            var tamagotchiThatLivesInTheDatabase = _context.Tamagotchis.FirstOrDefault(tamagotchi => tamagotchi.Id == id);

            if (tamagotchiThatLivesInTheDatabase == null)
            {
                return NotFound();
            }

            tamagotchiThatLivesInTheDatabase.HungerLevel += 3;
            tamagotchiThatLivesInTheDatabase.HappinessLevel += 5;

            _context.Entry(tamagotchiThatLivesInTheDatabase).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(tamagotchiThatLivesInTheDatabase);
        }

        [HttpPost("{id}/feedings")]
        public ActionResult<Tamagotchi> UpdateFeeding(int id, string feeding)
        {
            var tamagotchiThatLivesInTheDatabase = _context.Tamagotchis.FirstOrDefault(tamagotchi => tamagotchi.Id == id);

            if (tamagotchiThatLivesInTheDatabase == null)
            {
                return NotFound();
            }

            if (tamagotchiThatLivesInTheDatabase.HungerLevel < 5)
            {
                tamagotchiThatLivesInTheDatabase.HungerLevel = 0;
            }
            else
            {
                tamagotchiThatLivesInTheDatabase.HungerLevel -= 5;
            }

            if (tamagotchiThatLivesInTheDatabase.HappinessLevel < 3)
            {
                tamagotchiThatLivesInTheDatabase.HappinessLevel = 0;
            }
            else
            {
                tamagotchiThatLivesInTheDatabase.HappinessLevel -= 3;
            }

            _context.Entry(tamagotchiThatLivesInTheDatabase).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(tamagotchiThatLivesInTheDatabase);
        }

        [HttpPost("{id}/scoldings")]
        public ActionResult<Tamagotchi> UpdateScolding(int id, string feeding)
        {
            var tamagotchiThatLivesInTheDatabase = _context.Tamagotchis.FirstOrDefault(tamagotchi => tamagotchi.Id == id);

            if (tamagotchiThatLivesInTheDatabase == null)
            {
                return NotFound();
            }

            if (tamagotchiThatLivesInTheDatabase.HappinessLevel < 5)
            {
                tamagotchiThatLivesInTheDatabase.HappinessLevel = 0;
            }
            else
            {
                tamagotchiThatLivesInTheDatabase.HappinessLevel -= 5;
            }

            _context.Entry(tamagotchiThatLivesInTheDatabase).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(tamagotchiThatLivesInTheDatabase);
        }

        [HttpDelete("{id}")]
        public ActionResult<Tamagotchi> Delete(int id)
        {
            var foundTamagotchi = _context.Tamagotchis.FirstOrDefault(tamagotchi => tamagotchi.Id == id);

            if (foundTamagotchi == null)
            {
                return NotFound();
            }

            _context.Tamagotchis.Remove(foundTamagotchi);
            _context.SaveChanges();

            return Ok(foundTamagotchi);
        }
    }
}