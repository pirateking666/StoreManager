namespace StoreManager.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ImportWareHouse")]
    public partial class ImportWareHouse
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ImportWareHouse()
        {
            ImportWareHouseDetails = new HashSet<ImportWareHouseDetail>();
        }

        public int ID { get; set; }

        public DateTime ModifyDay { get; set; }

        public int SupplierID { get; set; }

        public int StatusID { get; set; }

        public virtual Status Status { get; set; }

        public virtual Supplier Supplier { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ImportWareHouseDetail> ImportWareHouseDetails { get; set; }
    }
}
