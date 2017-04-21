namespace AbstergoCommerce.WebUI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Image")]
    public partial class Image
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Image()
        {
            Brands = new HashSet<Brand>();
            Categories = new HashSet<Category>();
        }

        public int Id { get; set; }

        [StringLength(250)]
        public string BigUrl { get; set; }

        [StringLength(250)]
        public string MedUrl { get; set; }

        [StringLength(250)]
        public string SmallUrl { get; set; }

        public bool? Defaault { get; set; }

        public byte? RowNo { get; set; }

        public int? ProductID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Brand> Brands { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Category> Categories { get; set; }

        public virtual Product Product { get; set; }
    }
}
