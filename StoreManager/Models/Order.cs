namespace StoreManager.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            Bills = new HashSet<Bill>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int ID { get; set; }

        public DateTime ModifyDay { get; set; }

        [Required]
        [StringLength(11)]
        public string CustomerPhone { get; set; }

        public int? SaleOff { get; set; }

        public int? StatusID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bill> Bills { get; set; }

        public virtual SaleOff SaleOff1 { get; set; }

        public virtual Status Status { get; set; }

        public virtual Customer Customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
