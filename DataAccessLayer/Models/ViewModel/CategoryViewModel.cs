using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models.ViewModel
{
    public class CategoryViewModel
    {
        public int Id{ get; set; }
        public string Name{ get; set; }
        public bool Active { get; set; }
        public int TotalAds{ get; set; }
    }
}
