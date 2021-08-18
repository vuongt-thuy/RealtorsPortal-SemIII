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
    public class CountryMapper : IMapping<Country, CountryViewModel>, RootMapping<Country, CountryViewModel>
    {
        private Respository<Ads> _adsRes;

        public CountryMapper()
        {
            _adsRes = new Respository<Ads>();
        }

        public CountryViewModel Mapping(Country country)
        {
            CountryViewModel countryDTO = GetDTO(country);
            countryDTO.Id = country.Id;
            countryDTO.Name = country.Name;
            countryDTO.TotalAds = country.Id;
            countryDTO.TotalAds = _adsRes.GetList(x => x.Ward.District.City.Country.Id == country.Id).Count();
            return countryDTO;
        }
    }
}
