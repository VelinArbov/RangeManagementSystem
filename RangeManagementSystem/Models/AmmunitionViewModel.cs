namespace RangeManagementSystem.Web.Models
{
    public class AmmunitionViewModel
    {
        public int Id { get; set; }
        public  string Type { get; set; }
        public  string Caliber { get; set; }
        public  int Quantity { get; set; }
        public bool Availability { get; set; }
        public int WeaponId { get; set; }
    }
}
