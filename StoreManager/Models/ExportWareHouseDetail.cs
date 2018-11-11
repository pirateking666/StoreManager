namespace StoreManager.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ExportWareHouseDetail")]
    public partial class ExportWareHouseDetail
    {
        public int ID { get; set; }

        public int ExportWareHouseID { get; set; }

        public int ProductID { get; set; }

        public int Quantity { get; set; }

        public virtual ExportWareHouse ExportWareHouse { get; set; }

        public virtual Product Product { get; set; }
    }
}
