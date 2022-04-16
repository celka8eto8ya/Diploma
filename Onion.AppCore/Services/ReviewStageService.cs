using Onion.AppCore.DTO;
using Onion.AppCore.Entities;
using Onion.AppCore.Interfaces;
using System.Collections.Generic;
using System.Linq;
namespace Onion.AppCore.Services
{
    public class ReviewStageService :IReviewStage
    {
        private readonly IGenericRepository<ReviewStage> _reviewStageRepository;

        public ReviewStageService(IGenericRepository<ReviewStage> reviewStageRepository)
        {
            _reviewStageRepository = reviewStageRepository;
        }

        public IEnumerable<ReviewStageDTO> GetList()
            => _reviewStageRepository.GetList().Select(x => new ReviewStageDTO()
            {
                Id = x.Id,
                Name = x.Name,
                CreateDate = x.CreateDate
            });
    }
}
