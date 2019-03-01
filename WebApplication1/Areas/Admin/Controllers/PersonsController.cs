using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Areas.Admin.Controllers
{
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    [Route("api/Persons")]
    public class PersonsController : Controller
    {

        private DbMemory _context;

        public PersonsController()
        {
            _context = ApplicationDbMemory.GetDb();
        }

        //GET ALL
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var personViewModel = new List<PersonViewModel>();
            personViewModel.AddRange(_context.Persons.Select(p => new PersonViewModel { Name = p.Name, StateName = p.State.Name, CPF = p.CPF, BirthDate = new DateTime(p.BirthDate) }));

            return Json(personViewModel);
        }

        //GET ALL
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var person = _context.Persons.FirstOrDefault(p => p.Id == id);
            if (person != null)
            {
                var personViewModel = new PersonViewModel() { Name = person.Name, StateName = person.State.Name, CPF = person.CPF, BirthDate = new DateTime(person.BirthDate) };
                return Json(personViewModel);
            }
            return StatusCode(404);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string name, string stateName, DateTime? birthDate, long cpf)
        {
            if (ModelState.IsValid)
            {

                var state = _context.States.FirstOrDefault(s => String.Equals(s.Name.ToLower(), stateName.ToLower()));

                if (state is null)
                {
                    return StatusCode(404);
                }

                if (cpf.ToString().Length != 11 || cpf < 0)
                    return StatusCode(400);

                DateTime auxBirthDate;
                if (birthDate is null)
                    return StatusCode(400);
                else
                    auxBirthDate = (DateTime)birthDate;

                var person = new Person();
                lock (_context.Persons)
                {
                    person = new Person()
                    {
                        Id = _context.Persons.Max(p => p.Id) + 1,
                        Name = name,
                        StateId = state.Id,
                        State = state,
                        BirthDate = auxBirthDate.Ticks,
                        CPF = cpf
                    };

                    _context.Persons.Add(person);
                }

                return Json(person);
            }
            return StatusCode(500, "Create");
        }
 
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, string name, string stateName)
        {
            if (ModelState.IsValid)
            {
                var person = _context.Persons.FirstOrDefault(p => p.Id == id);

                if(person is null)
                {
                    return StatusCode(404);
                }

                lock (_context.Persons)
                {
                    if (!String.IsNullOrEmpty(name))
                    {
                        person.Name = name;
                    }
                    if (!String.IsNullOrEmpty(stateName))
                    {
                        var state = _context.States.FirstOrDefault(s => String.Equals(s.Name.ToLower(), stateName.ToLower()));
                        if (state != null)
                        {
                            person.StateId = state.Id;
                            person.State = state;
                        }
                    }
                }

                return Json(person);
            }
            return StatusCode(500, "Edit");
        }
 
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var person = _context.Persons.FirstOrDefault(p => p.Id == id);

                if (person is null)
                {
                    return StatusCode(404);
                }

                _context.Persons.Remove(person);
            }
            return StatusCode(500, "Delete");
        }

    }
}