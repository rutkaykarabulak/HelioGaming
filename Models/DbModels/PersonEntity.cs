using HelioGaming.Models.EntityModels;
using static HelioGaming.Utils.CommonTypes;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using HelioGaming.Utils;

namespace HelioGaming.Models.DbModels
{
	/// <summary>
	/// Representation of person object in database
	/// </summary>
	public class PersonEntity
	{
		/// <summary>
		/// Id of the person
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Full name of the person
		/// </summary>
		[MaxLength(Constants.MaxStringCharacterLength)]
		[Required]
		public string FullName { get; set; } = string.Empty;

		/// <summary>
		/// Birth place of the person
		/// </summary>
		[MaxLength(Constants.MaxStringCharacterLength)]
		public string BirthPlace { get; set; } = string.Empty;
		/// <summary>
		/// Address of the person
		/// </summary>
		public virtual AddressEntity Address { get; set; }

		/// <summary>
		/// Company of the person
		/// </summary>
		public virtual CompanyEntity Company { get; set; }

		/// <summary>
		/// Gender of the person
		/// </summary>
		[DefaultValue(2)]
		public Gender Gender { get; set; }
	}
}
