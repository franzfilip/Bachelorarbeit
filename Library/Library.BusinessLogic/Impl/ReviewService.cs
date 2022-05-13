using AutoBetter.BusinessLogic.impl;
using Library.DataAccess;
using Library.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BusinessLogic.Impl {
    public class ReviewService : BaseService<Review>, IReviewService {
        public ReviewService(IReviewRepository repository) : base(repository) {
        }
        public override async Task<Review> AddAsync(Review entity) {
            var review = await repository.GetFirstAsync(r => r.UserId == entity.UserId && r.BookId == entity.BookId, r => r.User, r => r.Book);
            if(review != null) {
                review.Rating = entity.Rating;
                return await repository.UpdateAsync(review);
            }

            return await repository.AddAsync(entity);
        }

        public override async Task<Review> UpdateAsync(Review entity) {
            var review = await repository.GetFirstAsync(r => r.Id == entity.Id, r => r.User, r => r.Book);
            return await repository.UpdateAsync(review);
        }
    }
}
