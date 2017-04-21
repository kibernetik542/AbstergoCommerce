namespace AbstergoCommerce.WebUI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CustomerAddress")]
    public partial class CustomerAddress
    {
        public int Id { get; set; }

        public Guid CustomerID { get; set; }

        [Required]
        [StringLength(500)]
        public string Address { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
