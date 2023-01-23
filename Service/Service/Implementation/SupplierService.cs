using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Repository;
using Service.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service.Implementation
{
    public class SupplierService : ISupplier
    {

        private readonly AppDbContext _dbContext;
        public SupplierService(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<IEnumerable<Supplier>> GetAllSuppliers()
        {
            var supplierList = await _dbContext.tblSupplier.ToListAsync();
            if (supplierList == null)
            {
                return null;
            }
            return supplierList.AsReadOnly();
            // return this._dbContext.tblSupplier.ToList();

            //var customerList = await _context.Customers.ToListAsync();
            //if (customerList == null)
            //{
            //    return null;
            //}
            //return customerList.AsReadOnly();

        }

        public async Task<Supplier> GetSingleSupplier(long id)
        {
            // return this._dbContext.tblUser.Where(x => x.userId == id).FirstOrDefault();
            // {
                var supplier = await this._dbContext.tblSupplier.FindAsync(id);
                if (supplier == null)
                {
                    return null;
                }
                return supplier;
                //return await this._dbContext.tblSupplier.Find(id);
        }


        public async Task<string> AddSupplier(Supplier supplier)
        {
            try
            {
                await this._dbContext.tblSupplier.AddAsync(supplier);
                this._dbContext.SaveChanges();
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }




        public async Task<string> RemoveSupplier(long id)
        {
            try
            {
                var supplier = await this._dbContext.tblSupplier.FindAsync(id);
                this._dbContext.Remove(supplier);
                this._dbContext.SaveChanges();
                return "Successfully Removed";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            // throw new NotImplementedException();
        }

        public async Task<string> UpdateSupplier(Supplier supplier)
        {
            try
            {
                var supplierValue = await this._dbContext.tblSupplier.FindAsync(supplier.supplierId);
                if (supplierValue != null)
                {
                    supplierValue.supplierName = supplier.supplierName;
                    this._dbContext.SaveChanges();
                    return "Successfully Updated";
                }
                else
                    return "No Record(s) Found";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }
}
