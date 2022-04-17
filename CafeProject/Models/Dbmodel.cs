namespace CafeProject.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Dbmodel : DbContext
    {
        public Dbmodel()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Category_table> Category_table { get; set; }
        public virtual DbSet<product_table> product_table { get; set; }
        public virtual DbSet<productproperty_table> productproperty_table { get; set; }
        public virtual DbSet<property_table> property_table { get; set; }
        public virtual DbSet<User_table> User_table { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<property_table>()
                .HasMany(e => e.productproperty_table)
                .WithOptional(e => e.property_table)
                .HasForeignKey(e => e.PropertyID);
        }
    }
}
