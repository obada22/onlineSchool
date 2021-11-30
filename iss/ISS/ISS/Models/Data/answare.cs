namespace ISS.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class answare
    {
        public string answareID { get; set; }

        public bool iscorrect { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string text { get; set; }

        [Required]
        [StringLength(10)]
        public string answare_number { get; set; }

        [StringLength(128)]
        public string questionID { get; set; }

        public virtual question question { get; set; }
    }
}
