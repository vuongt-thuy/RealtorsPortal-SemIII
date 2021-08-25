using DataAccessLayer.Models.Entities;
using DataAccessLayer.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Mapper
{
    public class UserMapper : IMapping<User, UserViewModel>, RootMapping<User, UserViewModel>
    {
        public UserViewModel Mapping(User user)
        {
            UserViewModel userDTO = GetDTO(user);
            userDTO.Id = user.Id;
            userDTO.Username = user.Username;
            userDTO.Fullname = user.Fullname;
            userDTO.Password = user.Password;
            userDTO.Phone = user.Phone;
            userDTO.Email = user.Email;
            userDTO.Avt = user.Avt;
            userDTO.Birthday = user.Birthday;
            userDTO.Address = user.Address;
            userDTO.Company = user.Company;
            userDTO.RoleId = user.RoleId;
            userDTO.Active = user.Active;
            userDTO.CreatedAt = user.CreatedAt;
            return userDTO;
        }
    }
}
