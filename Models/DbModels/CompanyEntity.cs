using HelioGaming.Models.EntityModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using HelioGaming.Utils;

namespace HelioGaming.Models.DbModels
{
	/// <summary>
	/// Representation of company object in database 
	/// </summary>
	public class CompanyEntity
	{
		/// <summary>
		/// Id of the company
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Name of the company
		/// </summary>
		[Required]
		public string Name { get; set; } = string.Empty;
		/// <summary>
		/// Registration date of company
		/// </summary>
		
		[Required]
		public DateTime DateOfRegistration { get; set; }

		/// <summary>
		/// Address of the company
		/// </summary>
		public int AddressId { get; set; }

		/// <summary>
		/// Address entity of the company
		/// </summary>
		public Address? Address { get; set; }

		/// <summary>
		/// Number of company
		/// </summary>
		public string Number { get; set; } = string.Empty;
		/// <summary>
		/// Phone number of company
		/// </summary>
		public string PhoneNumber { get; set; } = string.Empty;

		/// <summary>
		/// Number of person who works in this company
		/// </summary>
		public int EmployeeCount { get; set; } = 0;

		/// <summary>
		/// Employees of company
		/// </summary>
		public ICollection<Person> Employees { get; set; }
	}
}
