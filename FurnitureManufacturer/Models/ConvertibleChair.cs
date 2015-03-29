namespace FurnitureManufacturer.Models
{       
    
    /*
     * Convertible chair validity rules:
        •	Has too states – converted and normal.
        •	States can be changed by converting the chair from one to another.
        •	Converted state sets the height to 0.10m.
        •	Normal state returns the height to the initial one.
        •	Initial state is normal.
        
    */
    using System;
    using System.Collections.Generic;
    using FurnitureManufacturer.Interfaces;

    public class ConvertibleChair : Chair , IConvertibleChair
    {
        private bool isConverted;
        private const decimal convertedHeight = 0.10m;
        private decimal normalHeight;


        public ConvertibleChair(string model, MaterialType material, decimal price, decimal height, int numberOfLegs)
            : base(model, material, price, height , numberOfLegs)
        {
            this.IsConverted = false;
            this.normalHeight = height;
        }

        public bool IsConverted
        {
            get { return this.isConverted; }
            set { this.isConverted = value; }
        }

        public void Convert()
        {
            if (!isConverted)
            {
                this.Height = convertedHeight;
                this.isConverted = true;
            }
            else
            {
                this.Height = normalHeight;
                this.isConverted = false;
            }
        }

        public override string ToString()
        {
            return string.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Legs: {5}, State: {6}", this.GetType().Name, this.Model, this.Material, this.Price, this.Height, this.NumberOfLegs, this.IsConverted ? "Converted" : "Normal");
        }
    }
}
