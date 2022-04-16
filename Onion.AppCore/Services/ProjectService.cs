using Onion.AppCore.DTO;
using Onion.AppCore.Entities;
using Onion.AppCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Onion.AppCore.Services
{
    public class ProjectService : IProject
    {
        private readonly IGenericRepository<Project> _projectRepository;
        private readonly IGenericRepository<Condition> _conditionRepository;
        private readonly IGenericRepository<ReviewStage> _reviewStageRepository;

        public ProjectService(IGenericRepository<Project> projectRepository, IGenericRepository<Condition> conditionRepository,
            IGenericRepository<ReviewStage> reviewStageRepository)
        {
            _projectRepository = projectRepository;
            _conditionRepository = conditionRepository;
            _reviewStageRepository = reviewStageRepository;
        }

        public IEnumerable<FullProjectDTO> GetList()
            => _projectRepository.GetList().Select(x => new FullProjectDTO()
            {
                ProjectDTO = new ProjectDTO()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Deadline = x.Deadline,
                    StartDate = x.StartDate,
                    CreateDate = x.CreateDate,
                    UpdateDate = x.UpdateDate,
                    TechStack = x.TechStack,
                    Cost = x.Cost,
                    Description = x.Description,
                    UseArea = x.UseArea,
                    ConditionId = x.ConditionId,
                    ReviewStageId = x.ReviewStageId,
                },
                ConditionName = _conditionRepository.GetById(x.ConditionId).Name,
                ReviewStageName = _reviewStageRepository.GetById(x.ReviewStageId).Name
            });

        public void Create(ProjectDTO projectDTO)
            => _projectRepository.Create(new Project()
            {
                Name = projectDTO.Name,
                Deadline = projectDTO.Deadline,
                StartDate = projectDTO.StartDate,
                CreateDate = DateTime.Now.Date,
                UpdateDate = DateTime.Now.Date,
                TechStack = projectDTO.TechStack,
                Cost = projectDTO.Cost,
                Description = projectDTO.Description,
                UseArea = projectDTO.UseArea,
                ConditionId = _conditionRepository.GetList().First(x => x.Name == Enums.Conditions.ForImplementation.ToString()).Id,
                ReviewStageId = _reviewStageRepository.GetList().First(x => x.Name == Enums.ReviewStages.None.ToString()).Id,
            });


        public void Delete(int id)
            => _projectRepository.Delete(id);


        public ProjectDTO GetById(int id)
        {
            Project project = _projectRepository.GetById(id);
            ProjectDTO projectDTO = new ProjectDTO()
            {
                Id = project.Id,
                Name = project.Name,
                Deadline = project.Deadline,
                StartDate = project.StartDate,
                CreateDate = project.CreateDate,
                UpdateDate = project.UpdateDate,
                TechStack = project.TechStack,
                Cost = project.Cost,
                Description = project.Description,
                UseArea = project.UseArea,
                ConditionId = project.ConditionId,
                ReviewStageId = project.ReviewStageId
            };

            return projectDTO;
        }



        public void Update(ProjectDTO projectDTO)
            => _projectRepository.Update(new Project()
            {
                Id = projectDTO.Id,
                Name = projectDTO.Name,
                Deadline = projectDTO.Deadline,
                StartDate = projectDTO.StartDate,
                CreateDate = projectDTO.CreateDate,
                UpdateDate = DateTime.Now,
                TechStack = projectDTO.TechStack,
                Cost = projectDTO.Cost,
                Description = projectDTO.Description,
                UseArea = projectDTO.UseArea,
                ConditionId = projectDTO.ConditionId,
                ReviewStageId = projectDTO.ReviewStageId
            });

    }

}

