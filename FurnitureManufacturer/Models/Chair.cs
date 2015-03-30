
namespace FurnitureManufacturer.Models
{
    using System;
    using FurnitureManufacturer.Interfaces;

    public class Chair : Furniture , IFurniture, IChair
    {
        private int numberOfLegs;

        public Chair(string model, MaterialType materialEnum, decimal price, decimal height, int legs)
            : base(model, materialEnum, price, height)
        {
            this.NumberOfLegs = legs;
        }

        public int NumberOfLegs
        {
            get { return this.numberOfLegs; }
            set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Number of legs(chair) value can not be less or equal to 0");
                }
                this.numberOfLegs = value; 
            }
        }

        public override string ToString() // also do it for adjustible
        {
            return string.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Legs: {5}"
                , this.GetType().Name, this.Model, this.Material, this.Price, this.Height, this.NumberOfLegs);
        }
    }
}
