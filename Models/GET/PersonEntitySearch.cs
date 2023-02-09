using HelioGaming.Models.EntityModels;
using static HelioGaming.Utils.CommonTypes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HelioGaming.Models.GET
{
	/// <summary>
	/// This class is used to receive search http get calls
	/// If any of the parameters have a value, they are going to be included into search
	/// </summary>
	public class PersonEntitySearch
	{
		/// <summary>
		/// Full name of the person
		/// </summary>
		public string FullName { get; set; } = String.Empty;

		/// <summary>
		/// Birth place of the person
		/// </summary>
		public string BirthPlace { get; set; } = String.Empty;

		/// <summary>
		/// Name of the company 
		/// </summary>
		public string Company { get; set; } = String.Empty;

		/// <summary>
		/// Street name 
		/// </summary>
		public string Street { get; set; } = String.Empty;
		/// <summary>
		/// Address of the person
		/// </summary>
		public int? AddressId { get; set; }

		/// <summary>
		/// Company of the person
		/// </summary>
		public int? CompanyId { get; set; }

		/// <summary>
		/// Gender of the person
		/// </summary>
		public Gender? Gender { get; set; }
	}
}
