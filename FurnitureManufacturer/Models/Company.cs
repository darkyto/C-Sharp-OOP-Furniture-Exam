namespace FurnitureManufacturer.Models
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using FurnitureManufacturer.Interfaces;
    using FurnitureManufacturer.Interfaces.Engine;
    using System.Linq;

    public class Company : ICompany
    {
        #region fields
        private const int regNumberSize = 10;

        private string name;
        private string registrationNum;
        private List<IFurniture> furnitures;

        #endregion

        #region Constructors
        public Company(string name, string registrationNum)
        {
            this.Name = name;
            this.RegistrationNumber = registrationNum;
            this.furnitures = new List<IFurniture>(); ;
        }
        #endregion

        #region Properties
        public string Name 
        {
            get { return this.name; }
            private set 
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentNullException("Company name value can not be null or less then 5 symbols");
                }
                this.name = value; 
            } 
        }

        public string RegistrationNumber
        {
            get { return this.registrationNum; }
            private set 
            {
                if (value.Length != regNumberSize)
                {
                    throw new ArgumentOutOfRangeException("Registration number must be EXACTLY 10 Numerical symbols");
                }
                for (int i = 0; i < value.Length; i++)
                {
                    if (!char.IsDigit(value[i]))
                    {
                        throw new ArgumentException("Only numerical symbols allowed for Registration number");
                    }
                }
                this.registrationNum = value; 
            }
        }

        public ICollection<IFurniture> Furnitures
        {
            get { return this.furnitures; }
        }

        #endregion

        #region Methods


        public void Add(IFurniture furniture)
        {
            this.furnitures.Add(furniture);
        }

        public void Remove(IFurniture furniture)
        {
            if (this.Furnitures.Contains(furniture))
            {
                this.furnitures.Remove(furniture);
            }
        }

        public IFurniture Find(string model)
        {
            foreach (var furn in furnitures)
            {
                if (furn.Model.ToLower() == model.ToLower())
                {
                    return furn;
                }
            }
            return null;
        }

        public string Catalog()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("{0} - {1} - ",this.Name , this.RegistrationNumber);
            if (this.furnitures.Count <= 0 )
            {
                sb.Append("no furnitures");
            }
            else if (this.furnitures.Count  == 1)
            {
                sb.Append("1 furniture");
                foreach (var furn in furnitures)
                {
                    sb.Append(furn.ToString());
                }
            }
            else
            {
                sb.AppendFormat("{0} furnitures\n", this.Furnitures.Count);
                int index = 0;
                var orderedFurniteres = furnitures.OrderBy(x => x.Price).ThenBy(x => x.Model);
                foreach (var furn in orderedFurniteres)
                {
                    index++;
                    sb.AppendFormat("{0}", furn.ToString());
                    if (index != orderedFurniteres.Count())
                    {
                        sb.AppendLine();
                    }

                }
            }
            return sb.ToString();
        }


        #endregion

    }
}
