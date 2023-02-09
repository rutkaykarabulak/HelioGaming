using HelioGaming.Models;
using HelioGaming.Models.DbModels;
using HelioGaming.Models.EntityModels;
using HelioGaming.Models.GET;

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
		public Task<PersonEntity?> Get(int id);

		/// <summary>
		/// Gets a random person entity
		/// </summary>
		/// <returns>Random person entity </returns>
		public Task<PersonEntity?> WildCard();

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
		public Person Create(PersonEntity person);

		/// <summary>
		/// Removes the person entity with given id 
		/// </summary>
		/// <param name="id"></param>
		/// <returns>True if removal is successfull, false otherwise</returns>
		public bool Remove(int id);

		/// <summary>
		/// Searchs for a person with given parameters
		/// </summary>
		/// <returns>Person entity if it exists, null otherwise</returns>
		public List<PersonEntity?> Search(PersonEntitySearch get);

		//public Task<PersonEntity> Update(PersonEntity person); TODO

	}
}
