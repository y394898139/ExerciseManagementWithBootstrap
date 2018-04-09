using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CompWithBoo.Models
{
    public partial class Exercise
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //Exercise Id
        public int Id { get; set; }
        [MaxLength(100)]
        //Exercise Name
        public String ExerciseName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        //Exercise Date
        public DateTime ? ExerciseDate { get; set; }
        //Duration Time
        [Required]
        [Range(1, 120)]
        public int DurationTime { get; set; }
    }
}