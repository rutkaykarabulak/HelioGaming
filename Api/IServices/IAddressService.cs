using HelioGaming.Models;
using HelioGaming.Models.DbModels;

namespace HelioGaming.Api.IServices
{
	/// <summary>
	/// Interface for address service that handles CRUD operations on address object
	/// </summary>
	public interface IAddressService
	{
		/// <summary>
		/// Searchs for address entity with a given id in database
		/// </summary>
		/// <param name="id"></param>
		/// <returns>Address entity if there is a record were found, null otherwise</returns>
		public abstract Task<AddressEntity>? Get(int id);
		/// <summary>
		/// Creates a address entity and insers into database
		/// </summary>
		/// <param name="address"></param>
		/// <returns>Address entity that were created</returns>
		public abstract Task<AddressEntity> Create(AddressEntity address);

		/// <summary>
		/// Removes the address entity with given id from database
		/// </summary>
		/// <param name="id"></param>
		/// <returns>True if removal is successfull, false otherwise</returns>
		public abstract Task<bool> Remove(int id);
	}
}
