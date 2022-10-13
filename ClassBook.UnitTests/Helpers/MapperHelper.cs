using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClassBook.BLL;

namespace ClassBook.UnitTests.Helpers
{
    public static class MapperHelper
    {
        public static IMapper GetMapperForTests()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(typeof(MappingProfile));
            });

            return mapperConfiguration.CreateMapper();
        }
    }
}
