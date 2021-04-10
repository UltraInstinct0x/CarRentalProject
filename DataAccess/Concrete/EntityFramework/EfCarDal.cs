using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalDbContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (CarRentalDbContext context = new CarRentalDbContext())
            {
                var result = 
                    from c in  context.Cars 
                    join b in context.Brands on c.BrandId equals b.Id
                    join co in context.Colors on c.ColorId equals co.Id
                    join i in context.CarImages on c.Id equals i.CarId
                    orderby c.Id ascending 
                    select new CarDetailDto
                    {
                        CarName = c.Description,
                        BrandName = b.Name,
                        ColorName = co.Name,
                        DailyPrice = c.DailyPrice,
                        Description = c.Description,
                        Id = c.Id,
                        ImagePath = i.ImagePath,
                        ModelYear = c.ModelYear
                    };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
