
using HelioGaming.Api.IServices;
using HelioGaming.Models;
using HelioGaming.Models.DbModels;
using HelioGaming.Models.EntityModels;

namespace HelioGaming.Api.Services
{
	public class CompanyService:ICompanyService
	{
		private EFDataContext _postgreSQL;
		public CompanyService(EFDataContext postgreSQL)
		{
			_postgreSQL = postgreSQL;
		}

		public Company Create(CompanyEntity company)
		{
			Company entity = new()
			{
				Name = company.Name,
				Number = company.Number,
				AddressId = company.AddressId,
				DateOfRegistration = DateTime.Now,
				EmployeeCount = company.EmployeeCount,
				PhoneNumber = company.PhoneNumber
			};

			_postgreSQL.Companies.Add(entity);
			_postgreSQL.SaveChanges();

			return entity;

		}

		public async Task<CompanyEntity?> Get(int id)
		{
			Company? _company = await _postgreSQL.Companies.FindAsync(id);

			if (_company == null)
			{
				return null;
			}

			Address? _address = _postgreSQL.Addresses.Where(a => a.Id.Equals(_company.AddressId)).FirstOrDefault();
			

			AddressEntity? address = null;
			if (_address != null)
			{
				address = new()
				{
					Id = _address.Id,
					Street = _address.Street,
					Floor = _address.Floor,
					Door = _address.Door,
					Type = _address.Type
				};
			}
			CompanyEntity company = new()
			{
				Id = _company.Id,
				Name = _company.Name,
				DateOfRegistration = _company.DateOfRegistration,
				PhoneNumber = _company.PhoneNumber,
				Number = _company.Number,
				AddressId = _company.AddressId,
				Address = _address,
				EmployeeCount = _company.EmployeeCount
			};

			return company;
		}

		public IEnumerable<CompanyEntity> GetAll()
		{
			List<Company> _companies = _postgreSQL.Companies.ToList();
			List<Address> _addresses = _postgreSQL.Addresses.ToList();
			List<CompanyEntity> companies = new();

			_companies.ForEach(c => companies.Add(new()
			{
				Id = c.Id,
				Name = c.Name,
				AddressId = c.AddressId,
				DateOfRegistration = c.DateOfRegistration,
				Number = c.Number,
				PhoneNumber = c.PhoneNumber,
				EmployeeCount = c.EmployeeCount,
				Address = _addresses.Where(a => a.Id.Equals(c.AddressId)).FirstOrDefault()
			})) ;

			return companies;
			
		}

		public bool Remove(int id)
		{
			Company? company = _postgreSQL.Companies.Where(c => c.Id == id).FirstOrDefault();

			if (company == null)
			{
				return false;
			}

			_postgreSQL.Companies.Remove(company);
			_postgreSQL.SaveChanges();

			return true;
		}
	}
}
