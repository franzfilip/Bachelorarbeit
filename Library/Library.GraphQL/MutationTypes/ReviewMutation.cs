using AutoMapper;
using Library.BusinessLogic;
using Library.Datamodel;
using Library.GraphQLTypes.InputTypes.Review;

namespace Library.GraphQL.MutationTypes {
    [ExtendObjectType(Name = "Mutation")]
    public class ReviewMutation {
        private readonly IMapper mapper;

        public ReviewMutation(IMapper mapper) {
            this.mapper = mapper;
        }

        public async Task<Review> CreateReview([Service] IReviewService reviewService, ReviewCreate input) {
            if (input is null) {
                throw new ArgumentNullException(nameof(input));
            }

            Review review = mapper.Map<Review>(input);
            return await reviewService.AddAsync(review);
        }

        public async Task<Review> UpdateReview([Service] IReviewService reviewService, ReviewUpdate input) {
            if (input is null) {
                throw new ArgumentNullException(nameof(input));
            }

            Review review = mapper.Map<Review>(input);
            return await reviewService.UpdateAsync(review);
        }
    }
}
