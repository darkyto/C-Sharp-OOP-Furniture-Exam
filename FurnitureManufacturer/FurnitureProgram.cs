namespace FurnitureManufacturer
{
    using System;
    using System.Collections.Generic;
    using Engine;
    using FurnitureManufacturer.Models;
    using FurnitureManufacturer.Engine.Factories;

    public class FurnitureProgram
    {
        public static void Main()
        {
            FurnitureManufacturerEngine.Instance.Start();
        }
    }
}
