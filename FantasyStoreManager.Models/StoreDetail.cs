using FantasyStoreManager.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyStoreManager.Models
{
    public class StoreDetail
    {
        [Display(Name = "Store ID")]
        public int StoreId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        [Display(Name = "Store Type")]
        public StoreType TypeOfStore { get; set; }
    }
}
