using Onion.AppCore.DTO;
using Onion.AppCore.Entities;
using Onion.AppCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Onion.AppCore.Services
{
    public class OperationService : IOperation
    {
        private readonly IGenericRepository<Operation> _operationRepository;

        public OperationService(IGenericRepository<Operation> operationRepository)
            => _operationRepository = operationRepository;


        public IEnumerable<OperationDTO> GetList()
            => _operationRepository.GetList().Select(x => new OperationDTO()
            {
                Id = x.Id,
                Name = x.Name,
                Type = x.Type,
                Date = x.Date,
                Author = x.Author,
                Object = x.Object,

                ProjectId = x.ProjectId
            });


        public void Create(string type, string object0, string name, string author, int projectId)
           => _operationRepository.Create(new Operation()
           {
               Name = name,
               Type = type,
               Date = DateTime.Now,
               Author = author,
               Object = object0,

               ProjectId = projectId
           });
    }
}
