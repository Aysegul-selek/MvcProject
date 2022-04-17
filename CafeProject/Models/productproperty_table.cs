namespace CafeProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class productproperty_table
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]

        [Key]
        public int? ProductpropertyID { get; set; }
     
        public int? ProductID { get; set; }
        
        public int? PropertyID { get; set; }

        public virtual product_table product_table { get; set; }

        public virtual property_table property_table { get; set; }
    }
}
