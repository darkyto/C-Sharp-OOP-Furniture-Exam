
namespace FurnitureManufacturer.Models
{
    using System;
    using FurnitureManufacturer.Interfaces;

    public class AdjustableChair : Chair , IAdjustableChair , IChair
    {
        
        public AdjustableChair(string model, MaterialType materialEnum, decimal price, decimal height, int legs)
            : base(model, materialEnum, price, height, legs)
        {

        }

        public void SetHeight(decimal height) // this method will do the adjustible trick
        {
            this.Height = height;
        }

        public override string ToString()
        {
            return string.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Legs: {5}", 
                this.GetType().Name, 
                this.Model,
                this.Material, 
                this.Price, 
                this.Height, 
                this.NumberOfLegs);
        }
    }
}
