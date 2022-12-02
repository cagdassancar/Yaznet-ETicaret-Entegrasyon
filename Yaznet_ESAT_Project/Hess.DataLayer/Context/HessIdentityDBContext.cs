using Hess.Core.UtilityObjects;
using Hess.DataLayer.DTO;
using Hess.DataLayer.DTO.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hess.DataLayer.Context
{
   
    public class HessIdentityDBContext : DbContext
    {

        public HessIdentityDBContext()
        {
            this.Database.Connection.ConnectionString = Core.UtilityObjects.Globals.IdentityDBConnStr;
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<HessIdentityDBContext, Migrations.Identity.Configuration>());
        }

        public DbSet<TBL_Companys> TBL_Companys { get; set; }
        public DbSet<TBL_CompanyLogins> TBL_CompanyLogins { get; set; }
        public DbSet<TBL_CompanyShops> TBL_CompanyShops { get; set; }
        public DbSet<TBL_CompanyTask> TBL_CompanyTask { get; set; }        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           


        }
    }
}
