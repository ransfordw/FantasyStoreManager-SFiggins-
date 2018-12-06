using FantasyStoreManager.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyStoreManager.Models
{
    public class StoreEdit
    {
        [Display(Name = "Store ID")]
        public int StoreId { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Was silence cast on you? You must enter at least 2 characters.")]
        [MaxLength(60, ErrorMessage = "Are you attempting to cast a spell as a ritual? The maximum length of this field is 50 characters.")]
        public string Name { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Was silence cast on you? You must enter at least 2 characters.")]
        [MaxLength(35, ErrorMessage = "Are you attempting to cast a spell as a ritual? The maximum length of this field is 50 characters.")]
        public string Location { get; set; }
        [Required]
        [Display(Name = "Store Type")]
        public StoreType TypeOfStore { get; set; }
    }
}
