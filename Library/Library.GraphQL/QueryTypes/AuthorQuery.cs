using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Resolvers;
using Library.BusinessLogic;
using Library.Datamodel;
using Library.EF;
using Library.GraphQL.DataLoaders;

namespace Library.GraphQL.QueryTypes {
    [ExtendObjectType(typeof(Query))]
    public class AuthorQuery {
        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        //TODO Paging auf Connection umbennen
        public async Task<IQueryable<Author>> AuthorsConnection([Service] IAuthorService authorService) {
            return await authorService.GetAsync();
        }

        [Authorize]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public async Task<IQueryable<Author>> Authors([Service] IAuthorService authorService) {
            return await authorService.GetAsync();
        }
    }
}
