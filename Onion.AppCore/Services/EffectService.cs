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


        public EffectService(IGenericRepository<Step> stepRepository, IGenericRepository<Condition> conditionRepository,
            IGenericRepository<ReviewStage> reviewStageRepository, IGenericRepository<Task> taskRepository,
            IGenericRepository<Effect> effectRepository)
        {
            _stepRepository = stepRepository;
            _conditionRepository = conditionRepository;
            _reviewStageRepository = reviewStageRepository;
            _taskRepository = taskRepository;

            _effectRepository = effectRepository;
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
                PCT_A = x.PCT_A,
                PCT_T = x.PCT_T,
                POT = x.POT,
                POA = x.POA,

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

        public double IRRCalculate(EffectDTO effectDTO)
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
                    {
                        summ += mass[j] / Math.Pow(1 + i, j + 1);
                    }

                }

                if (summ < initial)
                {
                    IRR = (i - 0.0001) * 100;
                    break;
                }
            }
            return IRR;
        }

        public double NPVCalculate(EffectDTO effectDTO)
        {
            //double initial = 10000;
            double initial = effectDTO.NPV_InitialInvestments;
            //double percent = 0.1;
            double percent = effectDTO.NPV_DiscountRate/100;
            //double[] mass = { 5000, 4000, 3000, 1000, 0, 0, 0 };
            double[] mass = effectDTO.NPV_CashFlows;
           
            double summ = 0;

            for (int i = 0; i < mass.Length; i++)
            {
                if (mass[i] > 0)
                {
                    summ += mass[i] / Math.Pow(1 + percent, i + 1);
                }
            }
            return  summ - initial;
        }


        public void Create(EffectDTO effectDTO)
        {

            _effectRepository.Create(new Effect()
            {
                CalculateDate = DateTime.Now,
                IRR = IRRCalculate(effectDTO),
                ROI = (effectDTO.ROI_InvestmentsIncome - effectDTO.ROI_ExpensesAmount) / effectDTO.ROI_InvestmentsAmount,
                NPV = NPVCalculate(effectDTO),
                ETC = 4,
                PCT_A = 5,
                PCT_T = 6,
                POT = 7,
                POA = 8,

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


        //public void Delete(int id)
        //{
        //    if (_taskRepository.GetList().Any(x => x.StepId == id))
        //        _taskRepository.GetList().Where(x => x.StepId == id).ToList().ForEach(x => _taskRepository.Delete(x.Id));

        //    _stepRepository.Delete(id);
        //}


        //public void Update(StepDTO stepDTO)
        //    => _stepRepository.Update(new Step
        //    {
        //        Id = stepDTO.Id,
        //        Name = stepDTO.Name,
        //        Description = stepDTO.Description,
        //        TechStack = stepDTO.TechStack,
        //        TaskAmount = stepDTO.TaskAmount,
        //        PercentCompletionTasks = stepDTO.PercentCompletionTasks,
        //        AmountCompletionTasks = stepDTO.AmountCompletionTasks,

        //        ProjectId = stepDTO.ProjectId,
        //        ConditionId = stepDTO.ConditionId,
        //        ReviewStageId = stepDTO.ReviewStageId
        //    });


        //public StepDTO GetById(int id)
        //{
        //    Step step = _stepRepository.GetById(id);
        //    return new StepDTO()
        //    {
        //        Id = step.Id,
        //        Name = step.Name,
        //        Description = step.Description,
        //        TechStack = step.TechStack,
        //        TaskAmount = step.TaskAmount,
        //        PercentCompletionTasks = step.PercentCompletionTasks,
        //        AmountCompletionTasks = step.AmountCompletionTasks,

        //        ProjectId = step.ProjectId,
        //        ConditionId = step.ConditionId,
        //        ReviewStageId = step.ReviewStageId
        //    };
        //}

    }
}
