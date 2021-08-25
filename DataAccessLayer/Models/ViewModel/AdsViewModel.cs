using DataAccessLayer.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models.ViewModel
{
    public class AdsViewModel
    {
        public int Id { get; set; }
        public string UserFullname { get; set; }
        public string UserAvt { get; set; }
        public string UserPhone { get; set; }
        public string Title { get; set; }
        public int CountryId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Ward { get; set; }
        public string DetailAddress { get; set; }
        public int LandArea { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Need { get; set; }
        public string UnitPrice { get; set; }
        public int Priority { get; set; }
        public int Status { get; set; }
        public string RoleName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
