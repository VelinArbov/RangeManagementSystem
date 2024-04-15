using RangeManagementSystem.Data.Common.Models;

namespace RangeManagementSystem.Data.Models
{
    public class Weapon : BaseModel<int>
    {
        public required string Type { get; set; }
        public required string Caliber   { get; set; }
        public required int Quantity { get; set; }
        public bool Availability { get; set; }
    }
}
