using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HelioGaming.Utils;
using System.ComponentModel;

namespace HelioGaming.Models.EntityModels
{
	/// <summary>
	/// Definition of Company class to be used in EF database creation.
	/// </summary>
	[Table(Constants.CompanyTable)]
	public class Company
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key, Column(Order = 0)]
		public int Id { get; set; }

		[Required]
		[RegularExpression(Constants.regexOnlyLettersNumbersAndDashes, ErrorMessage = Constants.regexOnlyLettersNumbersAndDashesErr)]
		public string Name { get; set; } = string.Empty;

		[Required]
		public DateTime DateOfRegistration { get; set; }

		[ForeignKey("AddressId")]
		public  int AddressId { get; set; }

		public string Number { get; set; } = string.Empty;

		public string PhoneNumber { get; set; } = string.Empty;
		public int EmployeeCount { get; set; } = 0;

		[InverseProperty(Constants.CompanyTable)]
		public virtual ICollection<Person> Employees { get; set; }

	}
}
