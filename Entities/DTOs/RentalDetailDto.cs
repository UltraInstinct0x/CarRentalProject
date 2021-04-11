using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Abstract;

namespace Entities.DTOs
{
    public class RentalDetailDto:IDto
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DailyPrice { get; set; }
        public int ModelYear { get; set; }
        public string CompanyName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime RentDateEnd { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string Description { get; set; }
    }
}
