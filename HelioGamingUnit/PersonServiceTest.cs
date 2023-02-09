using HelioGaming.Api.Controllers;
using HelioGaming.Api.IServices;
using HelioGaming.Models.DbModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelioGamingUnit
{
	public class PersonServiceTest
	{
		private readonly PersonController _controller;
		private readonly IPersonService _personService;

		public PersonServiceTest()
		{
			_personService = new PersonServiceUnit();
			_controller = new PersonController(_personService);
		}
		
		/// <summary>
		/// HttpGet("All") tests
		/// </summary>

		[Fact]
		public void Get_WhenCalled_ReturnsOk()
		{
			// Act
			var okResult = _controller.Get();

			// Assert
			Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
		}

		/// <summary>
		/// HttpGet("All")
		/// 
		/// We have 2 person entity in our test service, and assert checks if our test is successfull
		/// </summary>
		[Fact]

		public void Get_WhenCalled_ReturnsAllItems()
		{
			// Act
			var okResult = _controller.Get() as OkObjectResult;

			// Assert
			var items = Assert.IsType<List<PersonEntity>>(okResult.Value);
			Assert.Equal(2, items.Count);
		}

		/// <summary>
		/// When we pass an unkown id our get method should return not found
		/// </summary>
		[Fact]

		public void GetById_UnkownIdPassed_ReturnsNotFound()
		{
			// Act
			var notFoundResult = _controller.Get(5555);

			// Assert

			Assert.IsType<NotFoundResult>(notFoundResult);
		}

		/// <summary>
		/// When we pass a known ID which exists in our database, it should return ok
		/// </summary>

		[Fact]
		public void GetById_ExistingIdPassed_ReturnsOkResult()
		{
			// Arrange
			var testId = 1;
			// Act
			var okResult = _controller.Get(testId);
			// Assert
			Assert.IsType<OkObjectResult>(okResult as IActionResult);
		}

		/// <summary>
		/// When we pass a known ID which exists in our database, it should return person entity
		/// </summary>

		[Fact]
		public void GetById_ExistingIdidPassed_ReturnsRightEntity()
		{
			// Arrange
			var testId = 1;
			// Act
			var okResult = _controller.Get(testId) as IActionResult;
			// Assert
			Assert.IsType<PersonEntity>(okResult);
			Assert.Equal(testId, (okResult as PersonEntity).Id);
		}

		/// <summary>
		/// it should OK when you create a valid person
		/// </summary>
		[Fact]
		public void Create_Person_ShouldReturnOk()
		{
			// arrange
			PersonEntity personEntity = new PersonEntity()
			{
				Id = 5,
				FullName = "Silan Yakut",
				BirthPlace = "Diyarbakir",
				AddressId = 2,
				CompanyId = 2,
				Gender = HelioGaming.Utils.CommonTypes.Gender.Female
			};

			// Act

			var okResult = _controller.Create(personEntity);

			Assert.IsType<OkResult>(okResult);
		}

		/// <summary>
		/// When we send an ID that doesn't exist it should return not found
		/// </summary>
		[Fact]

		public void Remove_UnknownPerson_ShouldReturnNotFound()
		{
			// arrange
			int testId = -55;

			// act
			var notFound = _controller.Remove(testId);

			// assert

			Assert.IsType<NotFoundResult>(notFound);
		}

		/// <summary>
		/// When you try to remove a person who is already in list it should return ok
		/// </summary>
		[Fact]
		public void Remove_ValidPerson_ShouldReturnOk()
		{
			// arrange
			int id = 1;

			// act
			var okResult = _controller.Remove(id);

			// assert
			Assert.IsType<OkObjectResult>(okResult);
		}



	}
}
