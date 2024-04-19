using System.ComponentModel;

namespace RangeManagementSystem.Web.Models
{
    public class WeaponCreateViewModel
    {
        [DisplayName("Тип: ")]
        public  string Type { get; set; }
        [DisplayName("Калибър: ")]
        public string Caliber { get; set; }
        [DisplayName("Брой: ")]
        public int Quantity { get; set; }
        public bool Availability { get; set; } = true;
    }
}
