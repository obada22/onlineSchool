namespace ISS.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Courses_Program
    {
        [Key]
        public string program_ID { get; set; }

        public int day_ID { get; set; }

        [StringLength(128)]
        public string Courrnt_course_ID { get; set; }

        [StringLength(128)]
        public string devam_ID { get; set; }

        public TimeSpan start_time { get; set; }

        public TimeSpan finish_time { get; set; }

        public virtual Day Day { get; set; }

        public virtual Current_courses Current_courses { get; set; }

        public virtual DevamZamani DevamZamani { get; set; }
    }
}
