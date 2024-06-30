using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace POS.Core.Models.Brands
{
    public class BrandInsertModel
    {
        [Required]
        public string BrandName { get; set; } =string.Empty;
        [JsonIgnore]
        public string? BrandImagePath { get; set; } 
        [Required]
        public IFormFile file { get; set; } 
    }
}
