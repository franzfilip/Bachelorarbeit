using AutoMapper;
using Library.Datamodel;
using Library.GraphQLTypes.InputTypes.Author;

namespace Library.Mapper {
    public class AuthorProfile: Profile {
        public AuthorProfile() {
            CreateMap<AuthorCreate, Author>()
                .ForMember(
                dest => dest.Books,
                opt => opt.MapFrom(src => src.Books.Select(id => new Book { Id = id })));

            CreateMap<AuthorUpdate, Author>()
                .ForMember(
                dest => dest.Books,
                opt => opt.MapFrom(src => src.Books.Select(id => new Book { Id = id })));
        }
    }
}
