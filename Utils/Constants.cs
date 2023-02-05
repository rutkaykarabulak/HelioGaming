namespace HelioGaming.Utils
{
	/// <summary>
	/// This class is used to strore common values.
	/// </summary>
	public class Constants
	{
		public const int MaxStringCharacterLength = 255;

		public const int MaxFloorAndDoorValue = 10;

		#region Regex
		// regex
		public const string regexOnlyLettersNumbersAndDashes = "^[a-zA-Z0-9\\_-]+$";
		public const string regexOnlyLettersNumbersAndDashesErr = "Allowing to entry only letters, numbers and dashes.";
		public const string regexOnlyUpperCasesUnderScoreAndNumbers = "^[A-Z0-9\\_]+$";
		public const string regexOnlyUpperCasesUnderScoreAndNumbersErr = "Allowing only upper cases, under scores and numbers.";
		#endregion

		#region Table names

		public const string AddressTable = "Address";
		public const string CompanyTable = "Company";
		public const string PersonTable = "Person";
		#endregion
	}
}
