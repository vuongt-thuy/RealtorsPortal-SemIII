using DataAccessLayer.Models.Entities;
using DataAccessLayer.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Mapper
{
    public class ContactMapper : IMapping<Contact, ContactViewModel>, RootMapping<Contact, ContactViewModel>
    {
        public ContactViewModel Mapping(Contact ct)
        {
            ContactViewModel _ctDTO = GetDTO(ct);
            _ctDTO.Id = ct.Id;
            _ctDTO.Name = ct.Name;
            _ctDTO.Phone = ct.Phone;
            _ctDTO.Email = ct.Email;
            _ctDTO.AdsTitle = ct.Ads.Title;
            _ctDTO.Status = ct.Status;
            _ctDTO.Message = ct.Message;
            return _ctDTO;
        }
    }
}
