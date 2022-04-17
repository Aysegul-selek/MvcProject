namespace CafeProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Category_table
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category_table()
        {
            product_table = new HashSet<product_table>();
        }

        [Key]
        public int CategoryID { get; set; }

        [StringLength(50)]
        public string Categoryname { get; set; }

        [StringLength(50)]
        public string parentcategoryID { get; set; }

        [StringLength(50)]
        public string ısdeleted { get; set; }

        [Column(TypeName = "date")]
        public DateTime? createddate { get; set; }

        [StringLength(50)]
        public string creatoruserID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<product_table> product_table { get; set; }
    }
}
