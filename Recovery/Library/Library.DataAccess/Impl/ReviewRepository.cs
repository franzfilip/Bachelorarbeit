using AutoBetter.DataAccess.impl;
using Library.Datamodel;
using Library.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess.Impl {
    public class ReviewRepository : Repository<Review>, IReviewRepository {
        public ReviewRepository(IDbContextFactory<LibraryContext> contextFactory) : base(contextFactory) {
        }

        public virtual async Task<Review> AddAsync(Review review) {
            if (review is null) {
                throw new ArgumentNullException(nameof(review));
            }

            await context.AddAsync(review);
            await context.SaveChangesAsync();
            await context.Entry(review).Reference(x => x.User).LoadAsync();
            await context.Entry(review).Reference(x => x.Book).LoadAsync();
            return review;
        }
    }
}
