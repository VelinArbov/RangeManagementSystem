using System.ComponentModel;

namespace RangeManagementSystem.Web.Models
{
    public class WeaponEditViewModel
    {
        public int Id { get; set; }
        [DisplayName("Тип: ")]
        public string Type { get; set; }
        [DisplayName("Калибър: ")]
        public string Caliber { get; set; }
        [DisplayName("Брой: ")]
        public int Quantity { get; set; }
        [DisplayName("Свободен: ")]
        public bool Availability { get; set; }
    }
}
