namespace ISS.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("quiz")]
    public partial class quiz
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public quiz()
        {
            questions = new HashSet<question>();
        }

        public string quizID { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] time { get; set; }

        public DateTime? created_date { get; set; }

        [StringLength(128)]
        public string Course_ID { get; set; }

        [Column(TypeName = "text")]
        public string description { get; set; }

        public short? timelimit { get; set; }

        [Required]
        [StringLength(25)]
        public string name { get; set; }

        [StringLength(128)]
        public string user_id { get; set; }

        public int typeID { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        public virtual Course Course { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<question> questions { get; set; }

        public virtual type type { get; set; }
    }
}
