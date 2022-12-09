using Hess.DataLayer.DTO.Store;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace Hess.DataLayer.Context
{


    public class HessStoreDBContext : DbContext
    {

        public HessStoreDBContext() : base()
        {
            this.Database.Connection.ConnectionString = Core.UtilityObjects.Globals.StoreDBConnStr;           

        }

        public DbSet<TBL_Products> TBL_Products { get; set; }
        public DbSet<TBL_ProductDetails> TBL_ProductDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();


            #region Example

            //// before 
            //modelBuilder.Entity<Person>()
            //        .Property(e => e.Name)
            //        .HasColumnAnnotation(
            //            IndexAnnotation.AnnotationName,
            //            new IndexAnnotation(new IndexAttribute { IsUnique = true }));

            //// after
            //modelBuilder.Entity<Person>()
            //    .HasIndex(p => p.Name)
            //    .IsUnique();

            //// multi column index
            //modelBuilder.Entity<Person>()
            //    .HasIndex(p => new { p.Name, p.Firstname })
            //    .IsUnique();
            #endregion





        }
    }
}
