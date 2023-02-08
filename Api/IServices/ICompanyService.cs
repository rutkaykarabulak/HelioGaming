using HelioGaming.Models;
using HelioGaming.Models.DbModels;
using HelioGaming.Models.EntityModels;

namespace HelioGaming.Api.IServices
{
	/// <summary>
	/// Interface for company service that handes CRUD operations on company object.
	/// </summary>
	public interface ICompanyService
	{
		/// <summary>
		/// Searchs for a given id in database.
		/// </summary>
		/// <param name="id"></param>
		/// <returns>Company Entity if there is a record with a given id, null otherwise.</returns>
		public abstract Task<CompanyEntity?> Get(int id);

		/// <summary>
		/// Gets all the company record in database
		/// </summary>
		/// <returns>Enumerable objects of company entities</returns>
		public abstract IEnumerable<CompanyEntity> GetAll();

		/// <summary>
		/// Creates a company object and inserts into database
		/// </summary>
		/// <param name="company"></param>
		/// <returns>Objects that were created</returns>
		public abstract Company Create(CompanyEntity company);

		//public abstract Task<CompanyEntity> Update();  TODO with put object

		/// <summary>
		/// Removes the object with given id.
		/// </summary>
		/// <param name="id"></param>
		/// <returns>True, if removal is successfull, false otherwise</returns>
		public abstract bool Remove(int id);

		// Update TODO
	}
}
