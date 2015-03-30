namespace FurnitureManufacturer.Models
{
    using System;
    using FurnitureManufacturer.Interfaces;

    public class ConvertibleChair : Chair, IConvertibleChair , IChair
    {
        private const decimal convertedState = 0.10m;

        private bool isConverted;
        private decimal normalHeight;

        public ConvertibleChair(string model, MaterialType materialEnum, decimal price, decimal height, int legs)
            : base(model, materialEnum, price, height, legs)
        {
            this.normalHeight = height;
            this.IsConverted = false;       // default condition for converted chairs
        }

        #region Properties
        public bool IsConverted
        {
            get { return this.isConverted; }
            set { this.isConverted = value; }
        }

        public void Convert()
        {
            if (isConverted == true)
            {
                this.isConverted = false;
                this.Height = normalHeight;
            }
            else if (isConverted == false)
            {
                this.IsConverted = true;
                this.Height = convertedState;
            }
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return string.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Legs: {5}, State: {6}", 
                this.GetType().Name, 
                this.Model,
                this.Material, 
                this.Price, 
                this.Height, 
                this.NumberOfLegs, 
                this.IsConverted ? "Converted" : "Normal");
        }
#endregion
    }
}
