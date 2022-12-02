using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hess.DataLayer.DTO.Identity
{
    public class TBL_CompanyLogins
    {
        [Key]
        public string ID { get; set; }

        [ForeignKey("TBL_Companys")]
        public string Company_ID { get; set; }

        [Column(TypeName = "nvarchar"), MaxLength(50)]
        public string UserName { get; set; }

        [Column(TypeName = "nvarchar"), MaxLength(50)]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar"), MaxLength(500)]
        public string Password { get; set; }

        public DateTime CreateDate { get; set; }

        [Required]
        public virtual TBL_Companys TBL_Companys { get; set; }
    }
}
