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
    public class PackageMapper : IMapping<Package, PackageViewModel>, RootMapping<Package, PackageViewModel>
    {
        public PackageViewModel Mapping(Package p)
        {
            PackageViewModel _pDTO = new PackageViewModel();
            _pDTO.Id = p.Id;
            _pDTO.Name = p.Name;
            _pDTO.Price = p.Price;
            _pDTO.Priority = p.Priority;
            _pDTO.Description = p.Description;
            _pDTO.Active = p.Active;
            _pDTO.CreatedAt = p.CreatedAt;
            return _pDTO;
        }
    }
}
