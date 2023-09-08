using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Model
{
    [Table("Student")]
    public class Student
    {
        [Column("Id")]
        [Key]
        [Required]
        [Range(1, 9999, ErrorMessage = "Id must be between 1 and 9999")]
        public int Id { get; set; }

        [Column("Name")]
        [Required]
        [MaxLength(200, ErrorMessage = "Name must be less than 200 characters")]        
        public string Name { get; set; }        
    }
}
