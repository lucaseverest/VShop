﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using VShop.ProductAPI.Models;

namespace VShop.ProductAPI.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The name is required")]
        [MinLength(3)]
        [MaxLength(100)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "The price is required")]

        public decimal Price { get; set; }

        [MaxLength(255)]
        public string? Description { get; set; }

        [Required(ErrorMessage = "The stock is required")]
        [Range(0, 9999)]
        public long Stock { get; set; }
        public string? ImgURL { get; set; }

        public string? CategoryName { get; set; }
        [JsonIgnore]
        public Category? Category { get; set; }
        public int CategoryId { get; set; }
    }
}
