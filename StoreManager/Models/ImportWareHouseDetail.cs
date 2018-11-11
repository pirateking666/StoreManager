namespace StoreManager.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ImportWareHouseDetail")]
    public partial class ImportWareHouseDetail
    {
        public int ID { get; set; }

        public int ImportWareHouseID { get; set; }

        public int ProductID { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public virtual ImportWareHouse ImportWareHouse { get; set; }

        public virtual Product Product { get; set; }
    }
}
