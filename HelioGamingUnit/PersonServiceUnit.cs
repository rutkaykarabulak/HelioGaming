using HelioGaming.Api.IServices;
using HelioGaming.Models.DbModels;
using HelioGaming.Models.EntityModels;
using HelioGaming.Models.GET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HelioGamingUnit
{
	public class PersonServiceUnit : IPersonService
	{
		private readonly List<PersonEntity> _persons;
		private readonly List<AddressEntity> _addresses;
		private readonly List<CompanyEntity> _companies;

		public PersonServiceUnit()
		{
			_addresses = new List<AddressEntity>()
			{
				new AddressEntity()
				{
					Id = 1,
					Street = "Doctor ferran",
					Door = "1",
					Floor = "-3",
					Type = HelioGaming.Utils.CommonTypes.AddressType.Company
				},
				new AddressEntity()
				{
					Id = 2,
					Street = "Helio Gaming Malta street",
					Door = "2",
					Floor = "5",
					Type = HelioGaming.Utils.CommonTypes.AddressType.Company
				},
				new AddressEntity()
				{
					Id = 3,
					Street = "Istanbul buyukcekmece",
					Door = "1",
					Floor = "1",
					Type = HelioGaming.Utils.CommonTypes.AddressType.Individual
				},
				new AddressEntity()
				{
					Id = 4,
					Street = "Malta",
					Door = "2",
					Floor = "3",
					Type = HelioGaming.Utils.CommonTypes.AddressType.Individual
				}

			};

			_companies = new()
			{
				new CompanyEntity()
				{
					Id = 1,
					Name = "inbestMe",
					DateOfRegistration = DateTime.Now,
					AddressId = 1,
					Address = ToAddress(_addresses.ElementAt(0)),
					EmployeeCount = 1,
					Number = "ISIN2023",
					PhoneNumber = "+34674496674"

				},
				new CompanyEntity ()
				{
					Id = 2,
					Name = "Helio Gaming",
					DateOfRegistration = DateTime.Now,
					AddressId = 1,
					Address = ToAddress(_addresses.ElementAt(1)),
					EmployeeCount = 1,
					Number = "Malta2023",
					PhoneNumber = "+3569912812"
				}
			};

			_persons = new()
			{
				new PersonEntity()
				{
					Id=1,
					FullName = "Brian Helio Game",
					BirthPlace = "Malta",
					AddressId = 1,
					Address = ToAddress(_addresses.ElementAt(3)),
					Company = ToCompany(_companies.ElementAt(1)),
					CompanyId = 2,
					Gender = HelioGaming.Utils.CommonTypes.Gender.Male
				},
				new PersonEntity()
				{
					Id= 2,
					FullName = "Brian Helio Game",
					BirthPlace = "Malta",
					AddressId = 1,
					Address = ToAddress(_addresses.ElementAt(3)),
					Company = ToCompany(_companies.ElementAt(1)),
					CompanyId = 2,
					Gender = HelioGaming.Utils.CommonTypes.Gender.Male
				}
			};
		}

		public static Address ToAddress(AddressEntity address)
		{
			return new Address()
			{
				Id = address.Id,
				Door = address.Door,
				Floor = address.Floor,
				Street = address.Street,
				Type = address.Type
			};
		}

		public static Company ToCompany(CompanyEntity company)
		{
			return new Company()
			{
				Id = company.Id,
				Name = company.Name,
				DateOfRegistration = company.DateOfRegistration,
				AddressId = company.AddressId,
				EmployeeCount = company.EmployeeCount,
				Number = company.Number,
				PhoneNumber = company.PhoneNumber
			};
		}
		public Person Create(PersonEntity person)
		{
			Person entity = new Person()
			{
				Id = person.Id,
				FullName = person.FullName,
				BirthPlace = person.BirthPlace,
				AddressId = person.AddressId,
				CompanyId = person.CompanyId,
				Gender = person.Gender
			};

			return entity;
		}

		public Task<PersonEntity?> Get(int id)
		{
			PersonEntity? entity =  _persons.Where(p => p.Id == id).FirstOrDefault();

			return Task.FromResult(entity);
		}

		public IEnumerable<PersonEntity> GetAll()
		{
			return _persons;
		}

		public bool Remove(int id)
		{
			PersonEntity? entity = _persons.Where(p => p.Id == id).FirstOrDefault();
			if (entity == null)
			{
				return false;
			}

			_persons.Remove(entity);

			return true;
		}

		public List<PersonEntity?> Search(PersonEntitySearch get)
		{
			get.Street = get.Street.ToLower();
			get.FullName = get.FullName.ToLower();
			get.BirthPlace = get.BirthPlace.ToLower();
			get.Company = get.Company.ToLower();

			IEnumerable<PersonEntity> query = _persons;

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
				query = query.Where(p => p.AddressId == get.AddressId);
			}

			return query.ToList();
		}

		public async Task<PersonEntity?> WildCard()
		{
			int recordCount = _persons.Count();

			var seed = Convert.ToInt32(Regex.Match(Guid.NewGuid().ToString(), @"\d+").Value);

			Random random = new(seed);

			int randomNumber = random.Next(1, recordCount);

			PersonEntity? person = await Get(randomNumber);

			return person;
		}
	}
}
