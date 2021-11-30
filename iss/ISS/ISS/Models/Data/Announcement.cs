namespace ISS.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Announcement")]
    public partial class Announcement
    {
        [Key]
        public string announcement_ID { get; set; }

        [StringLength(20)]
        public string type { get; set; }

        [Required]
        [StringLength(128)]
        public string current_cousre_ID { get; set; }

        [Required]
        [StringLength(128)]
        public string teacher_ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime create_date { get; set; }

        public TimeSpan create_time { get; set; }

        [Required]
        [StringLength(50)]
        public string title { get; set; }

        [Required]
        [StringLength(1000)]
        public string describe { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        public virtual Current_courses Current_courses { get; set; }
    }
}
