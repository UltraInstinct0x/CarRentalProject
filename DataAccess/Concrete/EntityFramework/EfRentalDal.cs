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
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentalDbContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<RentalDetailDto, bool>> filter = null)
        {
            using (CarRentalDbContext context = new CarRentalDbContext())
            {
                var result =
                    from r in context.Rentals 
                    join c in context.Cars on r.CarId equals c.Id
                    join b in context.Brands on c.BrandId equals b.Id
                    join cu in context.Customers on r.CustomerId equals cu.Id
                    join u in context.Users on cu.UserId equals u.Id
                    orderby r.Id ascending 
                    select new RentalDetailDto
                    {
                        BrandName = b.Name,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        RentDate = r.RentDate,
                        ReturnDate = r.ReturnDate,
                        BrandId = b.Id,
                        CarId = r.Id,
                        CompanyName = u.FirstName + " " + u.LastName,
                        DailyPrice = c.DailyPrice,
                        Id = r.Id,
                        Description = c.Description,
                        ModelYear = c.ModelYear,
                        RentDateEnd = r.RentDateEnd,
                    };
                return filter==null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
