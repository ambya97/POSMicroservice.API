﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Core.Models.Brands
{
    public class UpdateBrandModel
    {
        [Required]
        public int BrandId { get; set; }
        [Required]
        public string BrandName { get; set; } = string.Empty;
        
        public string? BrandImagePath { get; set; }=string.Empty;
        [Required]
        public IFormFile file { get; set; }
    }
}
