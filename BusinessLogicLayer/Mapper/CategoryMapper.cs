using BusinessLogicLayer.Respositories;
using DataAccessLayer.Models.Entities;
using DataAccessLayer.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Mapper
{
    public class CategoryMapper : IMapping<Category, CategoryViewModel>, RootMapping<Category, CategoryViewModel>
    {
        private Respository<Category> _catRes = new Respository<Category>();
        public CategoryViewModel Mapping(Category cat)
        {
            CategoryViewModel catDTO = GetDTO(cat);
            catDTO.Id = cat.Id;
            catDTO.Name = cat.Name;
            catDTO.Active = cat.Active;
            catDTO.TotalAds = cat.Ads.Count;
            return catDTO;
        }
    }
}
