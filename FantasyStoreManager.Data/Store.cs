using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyStoreManager.Data
{
    public enum StoreType
    {
        [Display(Name = "Apothecary")]
        Apothecary = 1,
        [Display(Name = "General")]
        General,
        [Display(Name = "Magic")]
        Magic,
        [Display(Name = "Stablery")]
        Stablery,
        [Display(Name = "Smithy")]
        Smithy,
        [Display(Name = "Tannery")]
        Tannery,
        [Display(Name = "Tavern")]
        Tavern,
        [Display(Name = "Woodshop")]
        Woodshop
    }
    public class Store
    {
        [Key]
        public int StoreId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        [Display(Name = "Store Name")]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public StoreType TypeofStore { get; set; }

        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}
