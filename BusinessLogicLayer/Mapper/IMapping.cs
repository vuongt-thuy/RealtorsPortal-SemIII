using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Mapper
{
    public class IMapping<T, K> where T : class where K : class
    {
        private MapperConfiguration config;

        public IMapping()
        {
            config = new MapperConfiguration(c => c.CreateMap<T, K>());
        }

        public K GetDTO(T t)
        {
            var mapper = config.CreateMapper();
            var data = mapper.Map<K>(t);
            return data;
        }
    }
}
