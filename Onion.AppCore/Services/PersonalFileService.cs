using Onion.AppCore.DTO;
using Onion.AppCore.Entities;
using Onion.AppCore.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Onion.AppCore.Services
{
    public class PersonalFileService : IPersonalFile
    {
        private readonly IGenericRepository<PersonalFile> _personalFileRepository;
        public PersonalFileService(IGenericRepository<PersonalFile> personalFileRepository)
        {
            _personalFileRepository = personalFileRepository;
        }

        public IEnumerable<PersonalFileDTO> GetList()
        {
            return _personalFileRepository.GetList().Select(x => new PersonalFileDTO
            {
                Id = x.Id,
                ProjectsDone = x.ProjectsDone,
                TotalTimeInProjects = x.TotalTimeInProjects,
                SetProjectDate = x.SetProjectDate,
                SuccessTaskCompletion = x.SuccessTaskCompletion,
                AVGTaskCompletionPerMonth = x.AVGTaskCompletionPerMonth,
                AVGSalary = x.AVGSalary,
                AVGTaskCost = x.AVGTaskCost,
                AVGTaskOverdueTime = x.AVGTaskOverdueTime,
                AVGTaskComplexity = x.AVGTaskComplexity,
                AVGTaskCompletionTime = x.AVGTaskCompletionTime,
                EmployeeId = x.EmployeeId
            });
        }

        public void Update(PersonalFileDTO personalFileDTO)
        {
           

        }

    }
}
