using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hess.DataLayer.DTO.Store
{
    public class TBL_Products
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [Column(TypeName = "varchar"), MaxLength(50)]
        public string ProductCode { get; set; }

        [Column(TypeName = "nvarchar"), MaxLength(500)]
        public string ProductName { get; set; }

        [Column(TypeName = "nvarchar"), MaxLength(200)]
        public string BrandName { get; set; }

        [Column(TypeName = "nvarchar"), MaxLength(200)]
        public string ModelName { get; set; }

        [Column(TypeName = "nvarchar"), MaxLength(4000)]
        public string Detail { get; set; }

        public Decimal? OldPrice { get; set; }

        public Decimal Price { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [DefaultValue(false)]
        public bool Is_Deleted { get; set; }
        [DefaultValue(false)]
        public bool Is_Active { get; set; }

        public virtual TBL_ProductDetails TBL_ProductDetails { get; set; }
    }
}
