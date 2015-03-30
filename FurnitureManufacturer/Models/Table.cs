namespace FurnitureManufacturer.Models
{
    using System;
    using FurnitureManufacturer.Interfaces;

    public class Table : Furniture, IFurniture , ITable
    {
        private decimal length;
        private decimal width;
        private decimal area;

        public Table(string model, MaterialType materialEnum, decimal price, decimal height , decimal length, decimal width)
            :base(model, materialEnum, price, height)
        {
            this.Length = length;
            this.Width = width;
            this.area = width * length;
        }

        #region Properties
        public decimal Length
        {
            get { return this.length; }
            set 
            {
                if (value <= 0.0m)
                {
                    throw new ArgumentException("Lenght value for table can not be less or equal to 0!");
                }
                this.length = value; 
            }
        }

        public decimal Width
        {
            get { return this.width; }
            set 
            {
                if (value <= 0.0m)
                {
                    throw new ArgumentException("Width value for table can not be less or equal to 0!");
                }
                this.width = value; 
            }
        }

        public decimal Area
        {
            get { return this.area; } // already validated by lenght and width exceptions
        }
        #endregion

        #region Methods
        public override string ToString()
        {
           
            return string.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Length: {5}, Width: {6}, Area: {7}", this.GetType().Name, this.Model, this.Material, this.Price, this.Height, this.Length, this.Width, this.Area);
        }
        #endregion 
    }
}
