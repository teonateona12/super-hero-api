﻿using Microsoft.AspNetCore.Mvc;

namespace super_hero_api.Controllers
{
    [Route("api/superHero")]
    [ApiController]
    public class SuperHeroController: ControllerBase
    {
        private static List<SuperHero> heroes = new List<SuperHero>
            {
                new SuperHero
                {
                    Id =1,
                    Name = "Spider Man",
                    FirstName= "Peter",
                    LastName="Parker"

                },
                new SuperHero
                {
                    Id =2,
                    Name = "Teona",
                    FirstName= "Peter",
                    LastName="Parker"

                }
};

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok(heroes);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> Get(int id)
        {
            var hero = heroes.Find(h => h.Id == id);
            if(hero == null)
            {
                return BadRequest("Hero not found.");
            }
            return Ok(hero);
        }
        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero( SuperHero hero)
        {
            heroes.Add(hero);
            return Ok(heroes);
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero request)
        {
            var hero = heroes.Find(h => h.Id == request.Id);
            if (hero == null)
            {
                return BadRequest("Hero not found.");
            }
            hero.Name = request.Name;
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;

            return Ok(hero);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> Delete(int id)
        {
            var hero = heroes.Find(h => h.Id == id);
            if (hero == null)
            {
                return BadRequest("Hero not found.");
            }
            heroes.Remove(hero);
            return Ok(heroes);
        }
    }
}
