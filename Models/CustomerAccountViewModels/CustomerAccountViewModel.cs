using System;
using System.ComponentModel.DataAnnotations;

namespace NetCoreVue.Models.CustomerAccountViewModels
{
    public class CustomerAccountViewModel
    {
        [Required]
        public string AccountName { get; set; }

        [Required]
        public string Comments { get; set; }

        [Required]
        public bool? IsVisible { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public int CreatedById { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

        [Required]
        public int UpdatedById { get; set; }

        [Required]
        public decimal RatePerHour { get; set; }

        [Required]
        public DateTime EffectiveStartDate { get; set; }

        [Required]
        public DateTime? EffectiveEndDate { get; set; }
    }
}

