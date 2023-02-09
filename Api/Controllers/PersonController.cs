using HelioGaming.Api.IServices;
using HelioGaming.Api.Services;
using HelioGaming.Models.DbModels;
using HelioGaming.Models.EntityModels;
using HelioGaming.Models.GET;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelioGaming.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PersonController : ControllerBase
	{
		private IPersonService personService;

		[HttpGet]
		public async Task<IActionResult> Get(int id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			PersonEntity? person = await personService.Get(id);

			if (person == null)
			{
				return NotFound($"There is no person record with given id {id}");
			}

			return Ok(person);
		}

		[HttpGet("WildCard")]
		public async Task<IActionResult> GetWildCard()
		{
			PersonEntity? person = await personService.WildCard();

			if (person == null)
			{
				return NotFound("There is no person record in database to return random.");
			}

			return Ok(person);
		}

		[HttpGet("Search")]
		public IActionResult Search([FromQuery]PersonEntitySearch get)
		{
			List<PersonEntity?> persons = personService.Search(get);

			return Ok(persons);
		}

		[HttpGet("All")]

		public IActionResult Get()
		{
			List<PersonEntity> result = personService.GetAll().ToList();

			if (result.Count == 0)
			{
				return NotFound("There is no person record in database");
			}

			return Ok(result);
		}

		[HttpPost]

		public IActionResult Create([FromBody] PersonEntity person)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			Person entity = personService.Create(person);

			return Ok(entity);
		}

		[HttpDelete]
		public IActionResult Remove(int id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			bool isRemoved = personService.Remove(id);

			if (!isRemoved)
			{
				return NotFound($"There is no person record with given id {id}");
			}

			return Ok(isRemoved);
		}
		public PersonController(EFDataContext postgreSQL)
		{
			personService = new PersonService(postgreSQL);
		}
		public PersonController(IPersonService service)
		{
			personService = service;
		}
	}
}
