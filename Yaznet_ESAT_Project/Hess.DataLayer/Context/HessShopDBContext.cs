using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Hess.DataLayer.DTO.Shop;

namespace Hess.DataLayer.Context
{
  

    public class HessShopDBContext : DbContext
    {
        
        public HessShopDBContext() :base()
        {
            this.Database.Connection.ConnectionString = Core.UtilityObjects.Globals.ShopDBConnStr;
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<HessShopDBContext, Migrations.Shop.Configuration>());

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

            #region TBL_Products
            // modelBuilder.Entity<TBL_Products>().HasIndex(p => p.ProductCode).IsUnique();
            #endregion



        }
    }
}
