namespace ISS.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class question
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public question()
        {
            answares = new HashSet<answare>();
        }

        public string questionID { get; set; }

        [Required]
        [StringLength(128)]
        public string quizID { get; set; }

        [Required]
        [StringLength(20)]
        public string question_number { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] timestamps { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string describe { get; set; }

        [StringLength(50)]
        public string imagePath { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<answare> answares { get; set; }

        public virtual quiz quiz { get; set; }
    }
}
