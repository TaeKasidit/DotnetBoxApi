﻿namespace ApiBox.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using ApiBox.ViewModelSchemaFilters;
    using Swashbuckle.AspNetCore.SwaggerGen;

    [SwaggerSchemaFilter(typeof(SaveCarSchemaFilter))]
    public class SaveCar
    {
        [Range(1, 20)]
        public int Cylinders { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }
    }
}
