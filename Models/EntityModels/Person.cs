using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HelioGaming.Utils;
using static HelioGaming.Utils.CommonTypes;

namespace HelioGaming.Models.EntityModels
{
	/// <summary>
	/// Definition of Person class to be used in EF database creation.
	/// </summary>
	[Table(Constants.PersonTable)]
	public class Person
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key, Column(Order = 0)]
		public int Id { get; set; }

		[Required]
		[MaxLength(Constants.MaxStringCharacterLength)]
		public string FullName { get; set; } = string.Empty;

		[MaxLength(Constants.MaxStringCharacterLength)]
		public string BirthPlace { get; set; } = string.Empty;

		[ForeignKey("AddressId")]
		public int AddressId { get; set; }
		
		public int CompanyId { get; set; }

		[ForeignKey("CompanyId")]
		public virtual Company Company { get; set; }

		[DefaultValue(2)]
		public Gender Gender { get; set; }
	}
}
