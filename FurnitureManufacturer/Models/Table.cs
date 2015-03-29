namespace FurnitureManufacturer.Models
{
    using System;
    using System.Threading.Tasks;
    using FurnitureManufacturer.Interfaces;

    public class Table : Furniture , ITable
    {

        private decimal length;
        private decimal width;
        private decimal area;

        public Table(string model, MaterialType material, decimal price, decimal height, decimal length, decimal width)
            :base(model, material, price, height)
        {
            this.Length = length;
            this.Width = width;
            this.area = length * width;
        }

        public decimal Length
        {
            get { return this.length; }
            set 
            {
                this.length = value;
            }
        }

        public decimal Width
        {
            get { return this.width; }
            set 
            {
                this.width = value;
            }
        }

        public decimal Area
        {
            get { return this.area; }
        }

        public override string ToString()
        {
            return string.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Length: {5}, Width: {6}, Area: {7}", this.GetType().Name, this.Model, this.Material.ToString(), this.Price, this.Height, this.Length, this.Width, this.Area);
        }
    }
}
