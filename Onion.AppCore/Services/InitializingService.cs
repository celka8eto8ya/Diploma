using Onion.AppCore.DTO;
using Onion.AppCore.Entities;
using Onion.AppCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Onion.AppCore.Services
{
    public class InitializingService : IInitializing
    {
        private readonly IGenericRepository<Role> _roleRepository;
        private readonly IGenericRepository<Condition> _conditionRepository;
        private readonly IGenericRepository<ReviewStage> _reviewStageRepository;

        public InitializingService(IGenericRepository<Role> roleRepository, IGenericRepository<Condition> conditionRepository,
            IGenericRepository<ReviewStage> reviewStageRepository)
        {
            _roleRepository = roleRepository;
            _conditionRepository = conditionRepository;
            _reviewStageRepository = reviewStageRepository;
        }



        public void InitializeRoles()
        {
            if (!_roleRepository.GetList().Any())
            {
                _roleRepository.Create(new Role()
                {
                    Name = Enums.Roles.ProjectManager.ToString(),
                    AccessLevel = Enums.AccessLevels.High.ToString(),
                    CreateDate = DateTime.Now
                });

                _roleRepository.Create(new Role()
                {
                    Name = Enums.Roles.Employee.ToString(),
                    AccessLevel = Enums.AccessLevels.Medium.ToString(),
                    CreateDate = DateTime.Now
                });

                _roleRepository.Create(new Role()
                {
                    Name = Enums.Roles.Customer.ToString(),
                    AccessLevel = Enums.AccessLevels.Low.ToString(),
                    CreateDate = DateTime.Now
                });
            }
        }

        public void InitializeEmployee()
        {
            
        }

        public void InitializeConditions()
        {
            if (!_conditionRepository.GetList().Any())
            {
                _conditionRepository.Create(new Condition()
                {
                    Name = Enums.Conditions.Completed.ToString(),
                    CreateDate = DateTime.Now
                });

                _conditionRepository.Create(new Condition()
                {
                    Name = Enums.Conditions.ForConsideration.ToString(),
                    CreateDate = DateTime.Now
                });

                _conditionRepository.Create(new Condition()
                {
                    Name = Enums.Conditions.ForImplementation.ToString(),
                    CreateDate = DateTime.Now
                });

                _conditionRepository.Create(new Condition()
                {
                    Name = Enums.Conditions.InProgress.ToString(),
                    CreateDate = DateTime.Now
                });
            }
        }

        public void InitializeReviewStages()
        {
            if (!_reviewStageRepository.GetList().Any())
            {
                _reviewStageRepository.Create(new ReviewStage()
                {
                    Name = Enums.ReviewStages.Accepted.ToString(),
                    CreateDate = DateTime.Now
                });

                _reviewStageRepository.Create(new ReviewStage()
                {
                    Name = Enums.ReviewStages.ForConsideration.ToString(),
                    CreateDate = DateTime.Now
                });

                _reviewStageRepository.Create(new ReviewStage()
                {
                    Name = Enums.ReviewStages.ForRevision.ToString(),
                    CreateDate = DateTime.Now
                });

                _reviewStageRepository.Create(new ReviewStage()
                {
                    Name = Enums.ReviewStages.None.ToString(),
                    CreateDate = DateTime.Now
                });
            }
        }



        public void Initialize()
        {
            InitializeRoles();
            InitializeConditions();
            InitializeReviewStages();
        }
    }
}
