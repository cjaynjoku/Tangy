using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TangyDataAccess;

namespace TangyBusiness.Mapper
{
    internal class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, TangyModels.CategoryDTO>().ReverseMap();
            
        }
    }
}
