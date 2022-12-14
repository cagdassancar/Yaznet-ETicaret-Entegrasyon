using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Hess.DataLayer.DTO.Store
{
    public class TBL_ProductDetails
    {

        [Key, ForeignKey("TBL_Products")]
        public Int64 Product_ID { get; set; }

        [Column(TypeName = "varchar"), MaxLength(200)]
        public String HBCode { get; set; }

        [Column(TypeName = "varchar"), MaxLength(200)]
        public String TYCode { get; set; }

        [Column(TypeName = "varchar"), MaxLength(200)]
        public String NOCode { get; set; }

        [Column(TypeName = "varchar"), MaxLength(200)]
        public String EBCode { get; set; }

        [Column(TypeName = "varchar"), MaxLength(200)]
        public String AZCode { get; set; }

        [Column(TypeName = "varchar"), MaxLength(200)]
        public String GoogleCode { get; set; }
        [Column(TypeName = "varchar"), MaxLength(200)]
        public String ERPCode { get; set; }

        [Required]
        public virtual TBL_Products TBL_Products { get; set; }

    }
}
