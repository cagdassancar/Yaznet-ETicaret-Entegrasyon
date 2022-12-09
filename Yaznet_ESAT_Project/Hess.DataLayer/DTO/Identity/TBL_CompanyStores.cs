using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hess.DataLayer.DTO.Identity
{
   public class TBL_CompanyStores
    {
        [Key]
        public string ID { get; set; }

        [ForeignKey("TBL_Companys")]
        public string Company_ID { get; set; }

        [Required]
        public virtual TBL_Companys TBL_Companys { get; set; }
    }
}
