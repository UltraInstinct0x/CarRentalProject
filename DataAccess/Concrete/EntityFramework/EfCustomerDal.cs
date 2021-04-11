using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, CarRentalDbContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails(Expression<Func<CustomerDetailDto, bool>> filter = null)
        {
            using (CarRentalDbContext context = new CarRentalDbContext())
            {
                var result = from c in context.Customers 
                    join u in context.Users on c.UserId equals u.Id
 
                    select new CustomerDetailDto()
                    {
                        CustomerId = c.Id,
                        CompanyName= c.CompanyName,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Email = u.Email,
                        Password = u.PasswordHash                               
                    };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
