
namespace FurnitureManufacturer.Models
{
    using System;
    using System.Collections.Generic;
    using FurnitureManufacturer.Interfaces;

    public class AdjustableChair : Chair, IAdjustableChair , IChair
    {

        public AdjustableChair(string model, MaterialType material, decimal price, decimal height , int numberOfLegs)
            : base(model, material, price, height , numberOfLegs)
        {
            
        }

        public void SetHeight(decimal height)
        {
            this.Height = height;
        }

        public override string ToString()
        {
            return string.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Legs: {5}", this.GetType().Name, this.Model, this.Material, this.Price, this.Height, this.NumberOfLegs);
        }
    }
}
