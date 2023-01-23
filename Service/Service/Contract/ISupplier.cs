using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service.Contract
{
    public interface ISupplier
    {
        Task<IEnumerable<Supplier>> GetAllSuppliers();
        Task<Supplier> GetSingleSupplier(long id);
        Task<string> AddSupplier(Supplier supplier);

        Task<string> UpdateSupplier(Supplier supplier);

        Task<string> RemoveSupplier(long id);
    }
}
