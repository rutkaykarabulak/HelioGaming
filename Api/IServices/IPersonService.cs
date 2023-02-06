using HelioGaming.Models;
using HelioGaming.Models.DbModels;

namespace HelioGaming.Api.IServices
{
	/// <summary>
	/// Interface for person service that handles CRUD operation on person entity
	/// </summary>
	public interface IPersonService
	{
		/// <summary>
		/// Searchs for a person entity with given id in database
		/// </summary>
		/// <param name="id"></param>
		/// <returns>Person entity if there is any with given object, null otherwise</returns>
		public Task<PersonEntity>? Get(int id);

		/// <summary>
		/// Searchs for all person entities in database
		/// </summary>
		/// <returns>Enumerable objects of person entities</returns>
		public IEnumerable<PersonEntity> GetAll();

		/// <summary>
		/// Creates a person entity and inserts into database
		/// </summary>
		/// <param name="person"></param>
		/// <returns>Person entitiy that were created</returns>
		public Task<PersonEntity> Create(PersonEntity person);

		/// <summary>
		/// Removes the person entity with given id 
		/// </summary>
		/// <param name="id"></param>
		/// <returns>True if removal is successfull, false otherwise</returns>
		public Task<bool> Remove(int id);

		//public Task<PersonEntity> Update(PersonEntity person); TODO

	}
}
