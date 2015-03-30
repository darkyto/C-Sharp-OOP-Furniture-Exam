namespace FurnitureManufacturer.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using FurnitureManufacturer.Interfaces;

    public abstract class Furniture : IFurniture
    {
        private string model;
        private string material;
        private MaterialType materialEnum;
        private decimal price;
        private decimal height;

        public Furniture(string model, MaterialType materialType, decimal price, decimal height)
        {
            this.Model = model;
            this.materialEnum = materialType;
            this.Price = price;
            this.Height = height;
        }

        #region Properties
        public string Model
        {
            get { return this.model; }
            set 
            {
                if (string.IsNullOrEmpty(value) || value.Length < 3)
                {
                    throw new ArgumentException("Model value can not be NULL or Less then 3 symbols");
                }
                this.model = value; 
            }
        }

        public string Material
        {
            get { return this.materialEnum.ToString(); }
            set 
            {
                this.material = value; 
            }
        }

        public decimal Price
        {
            get { return this.price; }
            set 
            {
                if (value <= 0.0M)
                {
                    throw new ArgumentException("Price value can not be less or equal to 0");
                }
                this.price = value; 
            }
        }

        public decimal Height
        {
            get { return this.height; }
            set 
            {
                if (value <= 0.0M)
                {
                    throw new ArgumentException("Height value can not be less or equal to 0");
                }
                this.height = value; 
            }
        }
        #endregion

        #region Methods
        #endregion
    }
}
