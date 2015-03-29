namespace FurnitureManufacturer.Engine.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    using Interfaces.Engine;
    using Models;
    using FurnitureManufacturer.Engine;

    public class CompanyFactory : ICompanyFactory
    {
        public ICompany CreateCompany(string name, string registrationNumber)
        {
            return new Company(name, registrationNumber);
        }
    }
}
