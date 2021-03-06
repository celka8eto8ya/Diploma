using Onion.AppCore.DTO;
using Onion.AppCore.Entities;
using Onion.AppCore.Interfaces;
using System.Linq;

namespace Onion.AppCore.Services
{
    public class PersonalFileService : IPersonalFile
    {
        private readonly IGenericRepository<PersonalFile> _personalFileRepository;
        private readonly IGenericRepository<Task> _taskRepository;

        public PersonalFileService(IGenericRepository<PersonalFile> personalFileRepository,
            IGenericRepository<Task> taskRepository)
        {
            _personalFileRepository = personalFileRepository;
            _taskRepository = taskRepository;
        }

        public PersonalFileDTO GetByEmployeeId(int id)
        {
            PersonalFile personalFile = _personalFileRepository.GetList().First(x => x.EmployeeId == id);
            return new PersonalFileDTO()
            {
                Id = personalFile.Id,
                ProjectsDone = personalFile.ProjectsDone,
                TotalTimeInProjects = personalFile.TotalTimeInProjects,
                AVGProjectTime = personalFile.AVGProjectTime,
                SetProjectDate = personalFile.SetProjectDate,
                SuccessTaskCompletion = personalFile.SuccessTaskCompletion,
                AVGTaskCompletionPerMonth = personalFile.AVGTaskCompletionPerMonth,
                AVGSalary = personalFile.AVGSalary,
                AVGTaskCost = personalFile.AVGTaskCost,
                AVGTaskOverdueTime = personalFile.AVGTaskOverdueTime,
                AVGTaskComplexity = personalFile.AVGTaskComplexity,
                AVGTaskCompletionTime = personalFile.AVGTaskCompletionTime,

                EmployeeId = personalFile.EmployeeId
            };
        }

        public void Update(PersonalFileDTO personalFileDTO)
            => _personalFileRepository.Update(new PersonalFile
            {
                Id = _personalFileRepository.GetList().First(x => x.EmployeeId == personalFileDTO.Id).Id,
                ProjectsDone = personalFileDTO.ProjectsDone,
                TotalTimeInProjects = personalFileDTO.TotalTimeInProjects,
                AVGProjectTime = personalFileDTO.AVGProjectTime,
                SetProjectDate = personalFileDTO.SetProjectDate,
                SuccessTaskCompletion = personalFileDTO.SuccessTaskCompletion,
                AVGTaskCompletionPerMonth = personalFileDTO.AVGTaskCompletionPerMonth,
                AVGSalary = personalFileDTO.AVGSalary,
                AVGTaskCost = personalFileDTO.AVGTaskCost,
                AVGTaskOverdueTime = personalFileDTO.AVGTaskOverdueTime,
                AVGTaskComplexity = personalFileDTO.AVGTaskComplexity,
                AVGTaskCompletionTime = personalFileDTO.AVGTaskCompletionTime,

                EmployeeId = personalFileDTO.EmployeeId
            });

    }
}
