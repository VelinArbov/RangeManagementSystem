namespace RangeManagementSystem.Web.Models
{
    public class WeaponViewModel
    {
        public int Id { get; set; }
        public required string Type { get; set; }
        public required string Caliber { get; set; }
        public  int Quantity { get; set; }
        public bool Availability { get; set; }
        public int FreeWeapons  => Quantity - RentedWeapons;
        public int RentedWeapons { get; set; }

    }
}
