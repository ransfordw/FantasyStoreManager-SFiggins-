using FantasyStoreManager.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyStoreManager.Models
{
    public class ProductEdit
    {
        [Display(Name = "Product ID")]
        public int ProductId { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Was silence cast on you? You must enter at least 2 characters.")]
        [MaxLength(50, ErrorMessage = "Are you attempting to cast a spell as a ritual? The maximum length of this field is 50 characters.")]
        public string Name { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Was silence cast on you? You must enter at least 2 characters.")]
        [MaxLength(8000)]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Product Type")]
        public ProductType TypeOfProduct { get; set; }
        [Required]
        public string Price { get; set; }
        [Required]
        public bool IsMagical { get; set; }
    }
}
