namespace AbstergoCommerce.WebUI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sale")]
    public partial class Sale
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sale()
        {
            SaleDetails = new HashSet<SaleDetail>();
        }

        public int Id { get; set; }

        public Guid? CustomerID { get; set; }

        public DateTime SalesDate { get; set; }

        [Column(TypeName = "money")]
        public decimal Total { get; set; }

        public bool InCart { get; set; }

        public int? CargoID { get; set; }

        public int? OrderStatusID { get; set; }

        [StringLength(20)]
        public string CargoTrackNo { get; set; }

        public virtual Cargo Cargo { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual OrderStat OrderStat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SaleDetail> SaleDetails { get; set; }
    }
}
