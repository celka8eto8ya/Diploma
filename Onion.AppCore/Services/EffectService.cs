using Newtonsoft.Json;
using Onion.AppCore.DTO;
using Onion.AppCore.Entities;
using Onion.AppCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Onion.AppCore.Services
{
    public class EffectService : IEffect
    {
        private readonly IGenericRepository<Step> _stepRepository;
        private readonly IGenericRepository<Condition> _conditionRepository;
        private readonly IGenericRepository<ReviewStage> _reviewStageRepository;
        private readonly IGenericRepository<Task> _taskRepository;

        private readonly IGenericRepository<Effect> _effectRepository;
        private readonly IGenericRepository<Team> _teamRepository;
        private readonly IGenericRepository<Employee> _employeeRepository;
        private readonly IGenericRepository<PersonalFile> _personalFileRepository;
        private readonly IGenericRepository<DashBoard> _dashBoardRepository;


        public EffectService(IGenericRepository<Step> stepRepository, IGenericRepository<Condition> conditionRepository,
            IGenericRepository<ReviewStage> reviewStageRepository, IGenericRepository<Task> taskRepository,
            IGenericRepository<Effect> effectRepository, IGenericRepository<Team> teamRepository,
            IGenericRepository<Employee> employeeRepository, IGenericRepository<PersonalFile> personalFileRepository,
            IGenericRepository<DashBoard> dashBoardRepository)
        {
            _stepRepository = stepRepository;
            _conditionRepository = conditionRepository;
            _reviewStageRepository = reviewStageRepository;
            _taskRepository = taskRepository;

            _effectRepository = effectRepository;
            _teamRepository = teamRepository;
            _employeeRepository = employeeRepository;
            _personalFileRepository = personalFileRepository;
            _dashBoardRepository = dashBoardRepository;
        }

        public IEnumerable<EffectDTO> GetList()
            => _effectRepository.GetList().Select(x => new EffectDTO()
            {
                Id = x.Id,
                CalculateDate = x.CalculateDate,
                IRR = x.IRR,
                ROI = x.ROI,
                NPV = x.NPV,
                ETC = x.ETC,
                CT_T = x.CT_T,
                PCT_T = x.PCT_T,
                POT = x.POT,
                OT = x.OT,

                ROI_ExpensesAmount = x.ROI_ExpensesAmount,
                ROI_InvestmentsIncome = x.ROI_InvestmentsIncome,
                ROI_InvestmentsAmount = x.ROI_InvestmentsAmount,

                NPV_InitialInvestments = x.NPV_InitialInvestments,
                NPV_DiscountRate = x.NPV_DiscountRate,
                NPV_YearsAmount = x.NPV_YearsAmount,
                NPV_CashFlows = JsonConvert.DeserializeObject<double[]>(x.NPV_CashFlows),

                IRR_InitialInvestments = x.IRR_InitialInvestments,
                IRR_YearsAmount = x.IRR_YearsAmount,
                IRR_CashFlows = JsonConvert.DeserializeObject<double[]>(x.IRR_CashFlows),

                ProjectId = x.ProjectId
            });


        //public bool IsUniqueStep(StepDTO stepDTO)
        //   => _stepRepository.GetList().Any(x => x.Name == stepDTO.Name && x.Id != stepDTO.Id);

        private double IRRCalculate(EffectDTO effectDTO)
        {
            double IRR = 0;
            //double initial = 10000;
            double initial = effectDTO.IRR_InitialInvestments;
            //double[] mass = { 1000, 3000, 4000, 6000, 0, 0, 0 };
            double[] mass = effectDTO.IRR_CashFlows;
            double summ;

            for (double i = 0.0001; i < 0.5; i += 0.0001)
            {
                summ = 0;
                for (int j = 0; j < mass.Length; j++)
                {
                    if (mass[j] > 0)
                        summ += mass[j] / Math.Pow(1 + i, j + 1);
                }

                if (summ < initial)
                {
                    IRR = (i - 0.0001) * 100;
                    break;
                }
            }
            return IRR;
        }

        private double NPVCalculate(EffectDTO effectDTO)
        {
            //double initial = 10000;
            double initial = effectDTO.NPV_InitialInvestments;
            //double percent = 0.1;
            double percent = effectDTO.NPV_DiscountRate / 100;
            //double[] mass = { 5000, 4000, 3000, 1000, 0, 0, 0 };
            double[] mass = effectDTO.NPV_CashFlows;

            double summ = 0;

            for (int i = 0; i < mass.Length; i++)
            {
                if (mass[i] > 0)
                    summ += mass[i] / Math.Pow(1 + percent, i + 1);
            }
            return summ - initial;
        }

        public void Create(EffectDTO effectDTO)
        {
            var projectTeams = _teamRepository.GetList().Where(x => x.ProjectId == effectDTO.ProjectId).ToList();
            var employees = _employeeRepository.GetList().ToList();
            var projectEmployees = new List<Employee>();

            for (int i = 0; i < projectTeams.Count; i++)
                employees.Where(x => x.TeamId == projectTeams[i].Id).ToList().ForEach(y => projectEmployees.Add(y));

            var personalFiles = _personalFileRepository.GetList().ToList();
            var projectPersonalFiles = new List<PersonalFile>();

            for (int i = 0; i < projectEmployees.Count; i++)
                personalFiles.Where(x => x.EmployeeId == projectEmployees[i].Id).ToList().ForEach(y =>
                    projectPersonalFiles.Add(y));

            double parameterCT_T = 0;
            double parameterPCT_T = 0;
            var projectPersonalFilesPCT_T = projectPersonalFiles.Where(x => x.AVGTaskCompletionTime != 0
                || (x.AVGTaskCompletionTime != 0 && x.AVGTaskOverdueTime != 0)).ToList();
            var projectPersonalFilesCT_T = projectPersonalFiles.Where(x => x.AVGTaskCompletionTime != 0
                && x.SuccessTaskCompletion > 0).ToList();


            projectPersonalFilesPCT_T.ForEach(y =>
                parameterPCT_T += y.AVGTaskCompletionTime / (y.AVGTaskCompletionTime - y.AVGTaskOverdueTime) * 100);

            projectPersonalFilesCT_T.ForEach(y => parameterCT_T += y.AVGTaskCompletionTime * y.SuccessTaskCompletion);

            if (projectPersonalFilesPCT_T.Count != 0)
                parameterPCT_T /= projectPersonalFilesPCT_T.Count;

            double parameterOT = 0;
            double parameterPOT = 0;
            var projectPersonalFilesPOT = projectPersonalFiles.Where(x => x.AVGTaskOverdueTime != 0
                || (x.AVGTaskCompletionTime != 0 && x.AVGTaskOverdueTime != 0)).ToList();

            var projectPersonalFilesOT = projectPersonalFiles.Where(x => x.AVGTaskOverdueTime != 0
                && x.SuccessTaskCompletion > 0).ToList();

            projectPersonalFilesPOT.ForEach(y =>
                parameterPOT += y.AVGTaskOverdueTime / (y.AVGTaskCompletionTime - y.AVGTaskOverdueTime) * 100);

            projectPersonalFilesOT.ForEach(y => parameterOT += y.AVGTaskOverdueTime * y.SuccessTaskCompletion);

            if (projectPersonalFilesPOT.Count != 0)
                parameterPOT /= projectPersonalFilesPOT.Count;

            double parameterETC = 0;
            for (int i = 0; i < projectPersonalFiles.Count; i++)
                parameterETC += (DateTime.Now -
                    _dashBoardRepository.GetList().First(x => x.EmployeeId == projectPersonalFiles[i].EmployeeId).SetDate).TotalDays
                        * projectPersonalFiles[i].AVGSalary / 30.0;

            _effectRepository.Create(new Effect()
            {
                CalculateDate = DateTime.Now,
                IRR = IRRCalculate(effectDTO),
                ROI = (effectDTO.ROI_InvestmentsIncome - effectDTO.ROI_ExpensesAmount) / effectDTO.ROI_InvestmentsAmount * 100,
                NPV = NPVCalculate(effectDTO),
                ETC = parameterETC,
                CT_T = parameterCT_T,
                PCT_T = parameterPCT_T,
                POT = parameterPOT,
                OT = parameterOT,

                ROI_ExpensesAmount = effectDTO.ROI_ExpensesAmount,
                ROI_InvestmentsIncome = effectDTO.ROI_InvestmentsIncome,
                ROI_InvestmentsAmount = effectDTO.ROI_InvestmentsAmount,

                NPV_InitialInvestments = effectDTO.NPV_InitialInvestments,
                NPV_DiscountRate = effectDTO.NPV_DiscountRate,
                NPV_YearsAmount = effectDTO.NPV_YearsAmount,
                NPV_CashFlows = JsonConvert.SerializeObject(effectDTO.NPV_CashFlows),

                IRR_InitialInvestments = effectDTO.IRR_InitialInvestments,
                IRR_YearsAmount = effectDTO.IRR_YearsAmount,
                IRR_CashFlows = JsonConvert.SerializeObject(effectDTO.IRR_CashFlows),

                ProjectId = effectDTO.ProjectId
            });
        }

    }
}
