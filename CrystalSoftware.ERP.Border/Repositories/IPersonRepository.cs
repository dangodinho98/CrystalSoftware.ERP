using CrystalSoftware.ERP.Border.Models;
using System;
using System.Threading.Tasks;

namespace CrystalSoftware.ERP.Border.Repositories
{
    public interface IPersonRepository
	{
		Task<People> GetById(Guid id);
	}
}
