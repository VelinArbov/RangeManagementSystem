﻿namespace RangeManagementSystem.Web.Models
{
    public class WeaponViewModel
    {
        public int Id { get; set; }
        public required string Type { get; set; }
        public required string Caliber { get; set; }
        public required int Quantity { get; set; }
        public bool Availability { get; set; }
    }
}