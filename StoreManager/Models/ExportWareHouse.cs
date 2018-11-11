namespace StoreManager.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ExportWareHouse")]
    public partial class ExportWareHouse
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ExportWareHouse()
        {
            Bills = new HashSet<Bill>();
            ExportWareHouseDetails = new HashSet<ExportWareHouseDetail>();
        }

        public int ID { get; set; }

        public DateTime ModifyDay { get; set; }

        public int EmployeeID { get; set; }

        [Required]
        [StringLength(11)]
        public string CustomerPhone { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bill> Bills { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Employee Employee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExportWareHouseDetail> ExportWareHouseDetails { get; set; }
    }
}
