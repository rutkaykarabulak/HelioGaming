using HelioGaming.Api.IServices;
using HelioGaming.Models.DbModels;
using HelioGaming.Models.EntityModels;
using HelioGaming.Models.GET;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

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
			Person entity = new()
			{
				FullName = person.FullName,
				BirthPlace = person.BirthPlace,
				CompanyId = person.CompanyId,
				AddressId = person.AddressId,
				Gender = person.Gender
			};

			if (person.CompanyId != 0)
			{
				Company? company = _postgreSQL.Companies.Find(person.CompanyId);

				if (company != null)
				{
					company.EmployeeCount++;
					_postgreSQL.Update(company);
				}
			}

			_postgreSQL.Add(entity);
			_postgreSQL.SaveChanges();

			return entity;
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

		public List<PersonEntity?> Search(PersonEntitySearch get)
		{
			List<PersonEntity> persons = GetAll().ToList();

			get.Street = get.Street.ToLower();
			get.FullName = get.FullName.ToLower();
			get.BirthPlace = get.BirthPlace.ToLower();
			get.Company = get.Company.ToLower();

			IEnumerable<PersonEntity> query = persons;

			if (!string.IsNullOrEmpty(get.FullName))
			{
				query = query.Where(p => p.FullName.ToLower().Contains(get.FullName));
			}
			if (!string.IsNullOrEmpty(get.BirthPlace))
			{
				query = query.Where(p => p.BirthPlace.ToLower().Contains(get.BirthPlace));
			}
			if (!string.IsNullOrEmpty(get.Street))
			{
				query = query.Where(p => p.Address.Street.ToLower().Contains(get.Street));
			}
			if (!string.IsNullOrEmpty(get.Company))
			{
				query = query.Where(p => p.Company.Name.ToLower().Contains(get.Company));
			}
			if (get.Gender.HasValue)
			{
				query = query.Where(p => p.Gender == get.Gender);
			}
			if (get.CompanyId.HasValue)
			{
				query = query.Where(p => p.CompanyId == get.CompanyId);
			}
			if (get.AddressId.HasValue)
			{
				query = query.Where(p => p.AddressId== get.AddressId);
			}

			return query.ToList();
		}

		public async Task<PersonEntity?> WildCard()
		{
			int recordCount = _postgreSQL.Persons.Count();

			var seed = Convert.ToInt32(Regex.Match(Guid.NewGuid().ToString(), @"\d+").Value);

			Random random = new(seed);

			int randomNumber = random.Next(1, recordCount);

			PersonEntity? person = await Get(randomNumber);

			return person;
		}
	}
}
