using HelioGaming.Api.IServices;
using HelioGaming.Models.DbModels;
using HelioGaming.Models.EntityModels;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.Runtime.InteropServices;

namespace HelioGaming.Api.Services
{
	public class PersonService: IPersonService
	{
		private EFDataContext _postgreSQL;
		public PersonService(EFDataContext postgreSQL)
		{
			_postgreSQL= postgreSQL;
		}

		public Person Create(PersonEntity person)
		{
			throw new NotImplementedException();
		}

		public async Task<PersonEntity?> Get(int id)
		{
			Person? _person = await _postgreSQL.Persons.FindAsync(id);

			if (_person == null)
			{
				return null;
			}

			PersonEntity entity = new()
			{
				Id = _person.Id,
				FullName = _person.FullName,
				AddressId = _person.AddressId,
				Address = _postgreSQL.Addresses.Where(a => a.Id.Equals(_person.AddressId)).FirstOrDefault(),
				CompanyId = _person.CompanyId,
				Company = _postgreSQL.Companies.Where(c => c.Id.Equals(_person.CompanyId)).FirstOrDefault(),
				BirthPlace = _person.BirthPlace,
				Gender = _person.Gender,
			};

			return entity;
		}

		public IEnumerable<PersonEntity> GetAll()
		{
			List<Person> _persons = _postgreSQL.Persons.ToList();
			List<PersonEntity> persons = new();
			_persons.ForEach(p => persons.Add(new()
			{
				Id = p.Id,
				FullName = p.FullName,
				AddressId = p.AddressId,
				Address = _postgreSQL.Addresses.Where(a => a.Id.Equals(p.AddressId)).FirstOrDefault(),
				CompanyId = p.CompanyId,
				Company = _postgreSQL.Companies.Where(c => c.Id.Equals(p.CompanyId)).FirstOrDefault(),
				BirthPlace = p.BirthPlace,
				Gender = p.Gender,
			} 
			));

			return persons;
		}

		public bool Remove(int id)
		{
			Person? _person = _postgreSQL.Persons.Find(id);

			if (_person == null)
			{
				return false;
			}

			_postgreSQL.Remove(_person);
			_postgreSQL.SaveChanges();

			return true;
		}
	}
}
