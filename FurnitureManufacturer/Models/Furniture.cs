namespace FurnitureManufacturer.Models
{
    using System;
    using FurnitureManufacturer.Interfaces;

    public abstract class Furniture : IFurniture
    {
        string model;
        MaterialType material;
        decimal price;
        decimal height;

        public Furniture(string model, MaterialType material, decimal price, decimal height)
        {
            this.Model = model;
            this.Material = material;
            this.Price = price;
            this.Height = height;
        }
       
        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 3)
                {
                    throw new ArgumentException("Model value can not be Null or less then 3 symbols");
                }
                this.model = value;
            }
        }

        public MaterialType Material
        {
            get
            {
                return this.material;
            }
            private set
            {
                this.material = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value <= 0.00M)
                {
                    throw new ArgumentException("Price can not be negative or 0");
                }
                this.price = value;
            }
        }

        public decimal Height
        {
            get
            {
                return this.height;
            }
            internal set
            {
                if (value <= 0.00M)
                {
                    throw new ArgumentException("Height value can not be negative or 0!");
                }
                this.height = value;
            }
        }
    }
}
