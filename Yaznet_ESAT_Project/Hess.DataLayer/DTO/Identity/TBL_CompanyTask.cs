using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hess.DataLayer.DTO.Identity
{
    public class TBL_CompanyTask
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [Required, ForeignKey("TBL_Companys")]
        public string Company_ID { get; set; }

        [Required]
        public int Task_ID { get; set; }

        [Required]
        public int TaskStatus { get; set; } = 0;        

        public string TaskMessage { get; set; }

        [Required]
        public string CreateLogin { get; set; }
        
        [Required]
        public DateTime CreateDate { get; set; }


        public virtual TBL_Companys TBL_Companys { get; set; }
    }
}
