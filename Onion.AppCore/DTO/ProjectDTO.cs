﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Onion.AppCore.DTO
{
    public class ProjectDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Name, please !")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Name length is [8;100] !")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter Deadline, please !")]
        public DateTime Deadline { get; set; }
        [Required(ErrorMessage = "Enter Start Date, please !")]
        public DateTime StartDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string TechStack { get; set; }
        public double Cost { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Enter Use Area, please !")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Use Area length is [3;30] !")]
        public string UseArea { get; set; }


        public int ConditionId { get; set; }
        public int ReviewStageId { get; set; }

    }
}
