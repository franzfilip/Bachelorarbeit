using AutoMapper;
using Library.Datamodel;
using Library.GraphQLTypes.InputTypes.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Mapper {
    public class UserProfile : Profile {
        public UserProfile() {
            CreateMap<RegisterData, User>()
                .ForMember(dest => dest.Roles, opt => opt.Ignore())
                .ForMember(dest => dest.Reviews, opt => opt.Ignore());
        }
    }
}
