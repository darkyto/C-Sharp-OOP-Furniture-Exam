namespace FurnitureManufacturer.Models
{
    using System;
    using System.Collections.Generic;
    using FurnitureManufacturer.Interfaces;
    using System.Text;
    using System.Linq;

    public class Company : ICompany
    {
        private const int regNumberFixedSize = 10;

        private string name;
        private string registrationNumber;
        private List<IFurniture> furnitures;

        public Company(string name, string regNumber)
        {
            this.Name = name;
            this.RegistrationNumber = regNumber;
            this.furnitures = new List<IFurniture>(); // remember this
        }

        /*
 * Company validity rules:
    •	Adding duplicate furniture is allowed.
    •	Removing furniture removes the first occurance. If such is not found, nothing happens.
    •	Finding furniture by model gets the first occurance. If such is not found, return null. Searching is case insensitive.
        Companies should only be created through the ICompanyFactory implemented by a class named CompanyFactory. Furniture should only be created through the IFurnitureFactory implemented by a class named FurnitureFactory. Both classes are in the FurnitureManufacturer.Engine.Factories namespace.

 */

        // TODO: Write all needed classes by implementing the interfaces in this namespace. You may delete this class
        #region Properties
        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException("Name value can not be null or less then 5 symbols");
                }
                this.name = value;
            }
        }

        public string RegistrationNumber
        {
            get { return this.registrationNumber; }
            set
            {
                if ((value.Length != regNumberFixedSize) || !NumbersCheck(value)) // check this later
                {
                    throw new ArgumentException("Registration number must contain exactly 10 Numerical symbols!");
                }
                this.registrationNumber = value;
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

        public void Remove(IFurniture furn)
        {
            if (this.furnitures.Count > 0) // (this.Furnitures.Contains(furniture))  // check this if the first is not working
            {
                this.furnitures.Remove(furn);
            }
        }

        //	Finding furniture by model gets the first occurance. If such is not found, return null. Searching is case insensitive.
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
            /*The listed furniture added to a certain company (through the Add(…) method) should be ordered by price then by model. 

             */
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("{0} - {1} - ", this.Name, this.RegistrationNumber));
            if (this.Furnitures.Count <= 0)
            {
                sb.Append("no furnitures");
            }
            else if (this.Furnitures.Count == 1)
            {
                sb.AppendLine("1 furniture");
                foreach (var furn in furnitures)
                {
                    sb.Append(furn.ToString());
                }
            }
            else
            {
                sb.AppendLine(string.Format("{0} furnitures",this.Furnitures.Count));
                var orderedFurn = furnitures.OrderBy(f => f.Price).ThenBy(f => f.Model);
                int index = 0;
                foreach (var furn in orderedFurn)
                {
                    if (index < orderedFurn.Count() - 1)
                    {
                        sb.AppendLine(furn.ToString());
                    }
                    else
                    {
                        sb.Append(furn.ToString());
                    }

                    index++;
                }
            }

            return sb.ToString();
        }
        public bool NumbersCheck(string input)
        {
            bool areAllNumbers = true;
            foreach (var ch in input)
            {
                if (!char.IsDigit(ch))
                {
                    areAllNumbers = false;
                    break;
                }
            }
            return areAllNumbers;
        }
        #endregion
    }
}
