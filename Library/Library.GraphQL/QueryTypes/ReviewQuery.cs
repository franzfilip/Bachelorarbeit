using Library.BusinessLogic;
using Library.Datamodel;
using Microsoft.AspNetCore.Authorization;

namespace Library.GraphQL.QueryTypes {
    public class ReviewQuery {
        [ExtendObjectType(typeof(Query))]
        public class BookQuery {
            [UsePaging]
            [UseProjection]
            [UseFiltering]
            [UseSorting]
            public async Task<IQueryable<Review>> ReviewsWithPaging([Service] IBaseService<Review> reviewService) {
                return await reviewService.GetAsync();
            }

            [Authorize]
            [UseProjection]
            [UseFiltering]
            [UseSorting]
            public async Task<IQueryable<Review>> Reviews([Service] IBaseService<Review> reviewService) {
                return await reviewService.GetAsync();
            }
        }
    }
}
