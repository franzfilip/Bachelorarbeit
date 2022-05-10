using AutoMapper;
using Library.Datamodel;
using Library.GraphQLTypes.InputTypes.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Mapper {
    public class ReviewProfile : Profile {
        public ReviewProfile() {
            CreateMap<ReviewCreate, Review>()
                .ForMember(
                dest => dest.User, opt => opt.Ignore())
                .ForMember(
                dest => dest.Book, opt => opt.Ignore());

            CreateMap<ReviewUpdate, Review>()
                .ForMember(
                dest => dest.User, opt => opt.Ignore())
                .ForMember(
                dest => dest.Book, opt => opt.Ignore());
        }
    }
}
