using static HelioGaming.Utils.CommonTypes;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using HelioGaming.Utils;

namespace HelioGaming.Models.DbModels
{
	/// <summary>
	/// Representation of address object in database
	/// </summary>
	public class Address
	{
		/// <summary>
		/// Id of the address
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Street of the address
		/// </summary>
		[MaxLength(Constants.MaxStringCharacterLength)]
		public string Street { get; set; } = string.Empty;

		/// <summary>
		/// Floor of the address
		/// </summary>
		[MaxLength(Constants.MaxFloorAndDoorValue)]
		[DefaultValue(0)]
		public string Floor { get; set; } = string.Empty;

		/// <summary>
		/// Door of the address
		/// </summary>
		[MaxLength(Constants.MaxFloorAndDoorValue)]
		[DefaultValue(0)]
		public string Door { get; set; } = string.Empty;
		/// <summary>
		/// Address type
		/// </summary>
		[Required]
		public AddressType Type { get; set; }
	}
}
