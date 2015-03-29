namespace FurnitureManufacturer.Interfaces
{
    using System;
    using FurnitureManufacturer.Models;

    public interface IFurniture
    {
        string Model { get; }

        MaterialType Material { get; }

        decimal Price { get; set; }

        decimal Height { get; }
    }
}
