using LMS.Library.Models;
using LMS.Library.Services;
using Microsoft.AspNetCore.Mvc;

namespace CsharpAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly PersonManager _personManager;

        public PeopleController()
        {
            _personManager = PersonManager.Current;
        }

        [HttpGet]
        public IActionResult GetAllPeople()
        {
            var people = _personManager.people;
            return Ok(people);
        }

        [HttpGet("{id}")]
        public IActionResult GetPersonById(int id)
        {
            var person = _personManager.GetById(id);
            if (person == null)
                return NotFound();

            return Ok(person);
        }

        [HttpPost]
        public IActionResult AddPerson(Person person)
        {
            _personManager.AddPerson(person);
            return CreatedAtAction(nameof(GetPersonById), new { id = person.Id }, person);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePerson(int id, Person person)
        {
            if (id != person.Id)
                return BadRequest();

            _personManager.UpdatePerson(person);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePerson(int id)
        {
            var person = _personManager.GetById(id);
            if (person == null)
                return NotFound();

            _personManager.RemovePerson(person);
            return NoContent();
        }

        [HttpGet("search")]
        public IActionResult SearchPeople(string query)
        {
            var people = _personManager.Search(query);
            return Ok(people);
        }

        [HttpPost("create")]
        public IActionResult CreatePerson(Person person)
        {
            _personManager.AddPerson(person);
            return CreatedAtAction(nameof(GetPersonById), new { id = person.Id }, person);
        }

        [HttpGet("courses")]
        public IActionResult GetPersonCourses(string name)
        {
            var person = _personManager.people.FirstOrDefault(p => p.Name == name);
            if (person == null)
                return NotFound();

            person.ListEnrolled();
            return Ok();
        }

        [HttpPost("enroll")]
        public IActionResult EnrollPersonInCourse(string personName, string courseName)
        {
            var person = _personManager.people.FirstOrDefault(p => p.Name == personName);
            if (person == null)
                return NotFound();

            person.AddEnrolled(courseName);
            return Ok();
        }

        [HttpPost("unenroll")]
        public IActionResult UnenrollPersonFromCourse(string personName, string courseName)
        {
            var person = _personManager.people.FirstOrDefault(p => p.Name == personName);
            if (person == null)
                return NotFound();

            person.rmEnrolled(courseName);
            return Ok();
        }

        [HttpGet("classification")]
        public IActionResult GetClassification(string classification)
        {
            var classificationEnum = _personManager.ClassSetter(classification);
            return Ok(classificationEnum);
        }
    }
}