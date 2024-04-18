using System.ComponentModel.DataAnnotations;

namespace RangeManagementSystem.Web.Models
{
    public class ShootingEventCreateViewModel
    {
        [Required(ErrorMessage = "Началната дата е задължителна.")]
        [Display(Name = "Начална дата: ")]
        public DateTime StartDate { get; set; } = DateTime.UtcNow;
        [Required(ErrorMessage = "Крайната дата е задължителна.")]
        [Display(Name = "Крайна дата: ")]
        public DateTime EndDate { get; set; } = DateTime.UtcNow;
        [Required(ErrorMessage = "Минималният брой участници е задължителен.")]
        [Range(1, 20, ErrorMessage = "Минималният брой участници трябва да бъде между 1 и 20.")]
        [Display(Name = "Минимален брой участници: ")]
        public int MinParticipants { get; set; }
        [Required(ErrorMessage = "Максималният брой участници е задължителен.")]
        [Range(1, 20, ErrorMessage = "Максималният брой участници трябва да бъде между 1 и 20.")]
        [Display(Name = "Максимален брой участници: ")]
        public int MaxParticipants { get; set; }
        public string? SuccessMessage { get; set; }
    }
}
