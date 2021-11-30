namespace ISS.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Adress")]
    public partial class Adress
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Adress()
        {
            AspNetUsers = new HashSet<AspNetUser>();
        }

        [Key]
        public string adress_id { get; set; }

        [StringLength(20)]
        public string country { get; set; }

        [StringLength(10)]
        public string city { get; set; }

        [StringLength(20)]
        public string neighborhood { get; set; }

        [StringLength(50)]
        public string detailes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AspNetUser> AspNetUsers { get; set; }
    }
}
