namespace ISS.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Current_courses
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Current_courses()
        {
            Announcements = new HashSet<Announcement>();
            Courses_Program = new HashSet<Courses_Program>();
            AspNetUsers = new HashSet<AspNetUser>();
        }

        [Key]
        public string current_cousre_ID { get; set; }

        [Required]
        [StringLength(128)]
        public string course_ID { get; set; }

        [Required]
        [StringLength(128)]
        public string teacher_ID { get; set; }

        [Column(TypeName = "text")]
        public string describe { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Announcement> Announcements { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        public virtual Course Course { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Courses_Program> Courses_Program { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AspNetUser> AspNetUsers { get; set; }
    }
}
