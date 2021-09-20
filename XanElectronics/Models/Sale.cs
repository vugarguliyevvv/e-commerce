using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace XanElectronics.Models
{
    public class Sale
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }

        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }
        public DateTime Date { get; set; }
        public bool IsFinished { get; set; }
        public decimal Total { get; set; }
        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
        public virtual ICollection<SaleProduct> SaleProducts { get; set; }
        public Sale()
        {
            Date = DateTime.Now;
        }
    }
}
