using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechathonFinancial.Models
{
    public class WordDefinition
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MinLength(2)]
        [Display(Name = "Word/Phrase")]
        [Column(TypeName = "varchar(50)")]
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string? Word {  get; set; }

        [Required]
        [MinLength(2)]
        [Display(Name = "Abbreviation")]
        [Column(TypeName = "varchar(25)")]
        [StringLength(25)]
        [DataType(DataType.Text)]
        public string? Abbreviation { get; set; }

        [Required]
        [MinLength(10)]
        [Display(Name = "Definition")]
        [Column(TypeName = "varchar(250)")]
        [StringLength(250)]
        [DataType(DataType.Text)]
        public string? Definition { get; set; }
    }
}
