using AutoMapper;
using Library.Datamodel;
using Library.GraphQLTypes.InputTypes.DTO;

namespace Library.Mapper {
    public class BookProfile : Profile {
        public BookProfile() {
            CreateMap<BookCreate, Book>()
                .ForMember(
                dest => dest.Authors,
                opt => opt.MapFrom(src => src.Authors.Select(id => new Author { Id = id })));

            CreateMap<BookUpdate, Book>()
                .ForMember(
                dest => dest.Authors,
                opt => opt.MapFrom(src => src.Authors.Select(id => new Author { Id = id })));
        }

    }
}