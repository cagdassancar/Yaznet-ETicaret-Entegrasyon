using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hess.DataLayer.DTO.Identity
{
    public class TBL_Companys
    {
        [Key]
        public string ID { get; set; }

        [Key, Column(TypeName = "varchar"), MaxLength(50)]
        public string CompanyCode { get; set; }

        [Column(TypeName = "varchar"), MaxLength(50)]
        public string CompanyName { get; set; }

        public DateTime CreateDate { get; set; }

        [Column(TypeName = "varchar"), MaxLength(500)]
        public string CompanyModeKey { get; set; }

        [Required]
        public virtual IEnumerable<TBL_CompanyLogins> TBL_CompanyLogins { get; set; }

        [Required]
        public virtual IEnumerable<TBL_CompanyStores> TBL_CompanyStores { get; set; }
    }
}
