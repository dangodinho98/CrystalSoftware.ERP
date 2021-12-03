using CrystalSoftware.ERP.Border.Dto;
using System;
using System.Threading.Tasks;

namespace CrystalSoftware.ERP.Border.Repositories
{
    public interface IPersonRepository
	{
		Task<Person> GetById(Guid id);
	}
}
