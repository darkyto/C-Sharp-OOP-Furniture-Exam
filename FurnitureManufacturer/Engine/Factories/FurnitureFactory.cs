namespace FurnitureManufacturer.Engine.Factories
{
    using System;
    using Interfaces;
    using Interfaces.Engine;
    using Models;
    using System.Linq;

    public class FurnitureFactory : IFurnitureFactory
    {
        private const string Wooden = "wooden";
        private const string Leather = "leather";
        private const string Plastic = "plastic";
        private const string InvalidMaterialName = "Invalid material name: {0}";

        public ITable CreateTable(string model, string materialType, decimal price, decimal height, decimal length, decimal width)
        {
            MaterialType enumMaterials = GetMaterialType(materialType.ToLower());
            Table newTable = new Table(model, enumMaterials ,price, height, length, width);
            return newTable; 
        }

        public IChair CreateChair(string model, string materialType, decimal price, decimal height, int numberOfLegs)
        {
            MaterialType enumMaterials = GetMaterialType(materialType.ToLower());
            Chair newTable = new Chair(model, enumMaterials, price, height, numberOfLegs);
            return newTable; 
        }

        public IAdjustableChair CreateAdjustableChair(string model, string materialType, decimal price, decimal height, int numberOfLegs)
        {
            MaterialType enumMaterials = GetMaterialType(materialType.ToLower());
            AdjustableChair newTable = new AdjustableChair(model, enumMaterials, price, height, numberOfLegs);
            return newTable; 
        }

        public IConvertibleChair CreateConvertibleChair(string model, string materialType, decimal price, decimal height, int numberOfLegs)
        {
            MaterialType enumMaterials = GetMaterialType(materialType.ToLower());
            ConvertibleChair newTable = new ConvertibleChair(model, enumMaterials, price, height, numberOfLegs);
            return newTable; 
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
