namespace ISS.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class news
    {
        [StringLength(128)]
        public string User_ID { get; set; }

        public string newsID { get; set; }

        [Required]
        [StringLength(4000)]
        public string describe { get; set; }

        [Required]
        [StringLength(255)]
        public string picPath { get; set; }

        [Required]
        [StringLength(50)]
        public string title { get; set; }

        [StringLength(255)]
        public string link { get; set; }

        [StringLength(255)]
        public string link1 { get; set; }

        [StringLength(255)]
        public string link2 { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
    }
}
