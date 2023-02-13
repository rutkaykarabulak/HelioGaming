using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HelioGaming.Models;
using HelioGaming.Models.EntityModels;
using HelioGaming.Api.IServices;
using HelioGaming.Api.Services;
using HelioGaming.Models.DbModels;

namespace HelioGaming.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CompanyController : ControllerBase
	{
		private ICompanyService companyService;


		[HttpGet]
		public async Task<IActionResult> Get(int id)
		{
			if (!ModelState.IsValid || id == 0)
			{
				return BadRequest(ModelState);
			}

			CompanyEntity? company = await companyService.Get(id);

			if (company == null)
			{
				return NotFound($"There is no company record with given id {id}");
			}
 
			return Ok(company);
		}

		[HttpGet("All")]

		public IActionResult GetAll()
		{
			List<CompanyEntity> companies = companyService.GetAll().ToList();

			if (companies.Count == 0)
			{
				return NotFound("There is no company in database");
			}

			return Ok(companies);
		}

		[HttpPost()]

		public IActionResult Create([FromBody] CompanyEntity company)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			Company entity = companyService.Create(company);

			return Ok(entity);
		}

		[HttpDelete]

		public IActionResult Remove(int id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			bool isRemoved = companyService.Remove(id);

			if (!isRemoved)
			{
				return NotFound($"There is no company record with given id {id}");
			}

			return Ok(isRemoved);
		}

		public CompanyController(EFDataContext postgreSQL, ICompanyService companyService)
		{	
			companyService = new CompanyService(postgreSQL);
			if (companyService != null)
			{
				this.companyService = companyService;
			}
		}
	}
}
