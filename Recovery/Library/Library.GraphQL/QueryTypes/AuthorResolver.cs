using HotChocolate.Resolvers;
using Library.BusinessLogic;
using Library.Datamodel;
using Library.EF;
using Library.GraphQLTypes.ObjectTypes;
using Microsoft.EntityFrameworkCore;

namespace Library.GraphQL.QueryTypes {
    //[ExtendObjectType(typeof(Query))]
    public class AuthorResolver {
        
        //public async Task<IQueryable<Author>> Authors([Service] IAuthorService authorService) {
        //    //return context.Authors.AsNoTracking();
        //    //return await authorService.GetAsync(includes: author => author.Books);
        //    return await authorService.GetAsync();
        //}

        //public async Task<Author> AuthorById([Service] IAuthorService authorService, int id) {
        //    //var x = context.GetSelections(new AuthorType());
        //    return await authorService.GetFirstAsync(author => author.Id == id);
        //}
    }
}
