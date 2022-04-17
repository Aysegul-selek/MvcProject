namespace CafeProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class product_table
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public product_table()
        {
            productproperty_table = new HashSet<productproperty_table>();
        }

        [Key]
        public int ProductID { get; set; }

        [StringLength(50)]
        public string ProductName { get; set; }

        public int? CategoryID { get; set; }

        [StringLength(50)]
        public string Price { get; set; }

        [StringLength(50)]
        public string ImagePath { get; set; }

        [StringLength(50)]
        public string Isdeleted { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }

        [StringLength(50)]
        public string CreatoruserID { get; set; }

        public virtual Category_table Category_table { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<productproperty_table> productproperty_table { get; set; }
    }
}
