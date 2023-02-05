using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HelioGaming.Utils;
using static HelioGaming.Utils.CommonTypes;

namespace HelioGaming.Models.EntityModels
{
	/// <summary>
	/// Definition of Address class to be used in EF database creation.
	/// </summary>
	[Table(Constants.AddressTable)]
	public class Address
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key, Column(Order = 0)]
		public int Id { get; set; }

		[MaxLength(Constants.MaxStringCharacterLength)]
		public string Street { get; set; } = string.Empty;

		[MaxLength(Constants.MaxFloorAndDoorValue)]
		[DefaultValue(0)]
		public string Floor { get; set; } = string.Empty;

		[MaxLength(Constants.MaxFloorAndDoorValue)]
		[DefaultValue(0)]
		public string Door { get; set; } = string.Empty;

		[Required]
		public AddressType Type { get; set; }
	}
}
