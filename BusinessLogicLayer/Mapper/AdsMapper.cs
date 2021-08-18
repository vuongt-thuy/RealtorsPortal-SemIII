﻿using BusinessLogicLayer.Respositories;
using DataAccessLayer.Models.Entities;
using DataAccessLayer.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Mapper
{
    public class AdsMapper : IMapping<Ads, AdsViewModel>, RootMapping<Ads, AdsViewModel>
    {
        private Respository<District> _resDistrict;
        private Respository<City> _resCity;
        private Respository<Country> _resCountry;
        private Respository<PackageOfUser> _resPOU;

        public AdsMapper()
        {
            _resDistrict = new Respository<District>();
            _resCity = new Respository<City>();
            _resCountry = new Respository<Country>();
            _resPOU = new Respository<PackageOfUser>();
        }

        public AdsViewModel Mapping(Ads ads)
        {
            var district = _resDistrict.FindById(ads.Ward.DistrictId);
            var city = _resCity.FindById(district.CityId);
            var country = _resCountry.FindById(city.CountryId);

            AdsViewModel adsDTO = GetDTO(ads);
            adsDTO.Id = ads.Id;
            adsDTO.User = ads.PackageOfUser.User;
            adsDTO.Country = country.Name;
            adsDTO.City = city.Name;
            adsDTO.District = district.Name;
            adsDTO.Ward = ads.Ward.Name;
            adsDTO.DetailAddress = ads.DetailAddress;
            adsDTO.Title = ads.Title;            
            adsDTO.LandArea = ads.LandArea;
            adsDTO.Price = ads.Price;
            adsDTO.Description = ads.Description;
            adsDTO.Note = ads.Note;
            adsDTO.StartDate = ads.StartDate;
            adsDTO.EndDate = ads.EndDate;
            adsDTO.CategoryId = ads.CategoryId;
            adsDTO.Need = ads.Need;
            adsDTO.UnitPrice = ads.UnitPrice;
            adsDTO.Status = ads.Status;
            adsDTO.CategoryId = ads.CategoryId;
            adsDTO.Priority = 1;
            adsDTO.CreatedAt = ads.CreatedAt;
            adsDTO.UpdatedAt = ads.UpdatedAt;
            
            return adsDTO;
        }
    }
}