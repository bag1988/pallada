using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace pallada.Models.Uslugi
{
    public class sectionModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int IdCategory { get; set; }

        [Required]
        [Display(Name = "Раздел")]
        public string Name { get; set; }

        public categoryModel Category { get; set; }
    }

    public class sectionView
    {
        public sectionModel Section { get; set; }
        public IEnumerable<categoryModel> Category { get; set; }
    }
}
