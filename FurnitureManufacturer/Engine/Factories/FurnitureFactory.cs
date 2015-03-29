namespace FurnitureManufacturer.Engine.Factories
{
    using System;

    using Interfaces;
    using Interfaces.Engine;
    using Models;

    public class FurnitureFactory : IFurnitureFactory
    {
        private const string Wooden = "wooden";
        private const string Leather = "leather";
        private const string Plastic = "plastic";
        private const string InvalidMaterialName = "Invalid material name: {0}";

        public ITable CreateTable(string model, string materialType, decimal price, decimal height, decimal length, decimal width)
        {

            MaterialType materialEnum = GetMaterialType(materialType);
            Table newTable = new Table(model, materialEnum, price, height, length, width);
            
            return newTable;
        }

        public IChair CreateChair(string model, string materialType, decimal price, decimal height, int numberOfLegs)
        {
            MaterialType materialEnum = GetMaterialType(materialType);
            Chair newChair = new Chair(model, materialEnum, price, height, numberOfLegs);
            return newChair;

        }

        public IAdjustableChair CreateAdjustableChair(string model, string materialType, decimal price, decimal height, int numberOfLegs)
        {
            MaterialType materialEnum = GetMaterialType(materialType);
            AdjustableChair newChair = new AdjustableChair(model, materialEnum, price, height, numberOfLegs);
            return newChair;
        }

        public IConvertibleChair CreateConvertibleChair(string model, string materialType, decimal price, decimal height, int numberOfLegs)
        {
            MaterialType materialEnum = GetMaterialType(materialType);
            ConvertibleChair newChair = new ConvertibleChair(model, materialEnum, price, height, numberOfLegs);
            return newChair;
        }

        private MaterialType GetMaterialType(string material)
        {
            switch (material)
            {
                case Wooden:
                    return MaterialType.Wooden;
                case Leather:
                    return MaterialType.Leather;
                case Plastic:
                    return MaterialType.Plastic;
                default:
                    throw new ArgumentException(string.Format(InvalidMaterialName, material));
            }
        }
    }
}
