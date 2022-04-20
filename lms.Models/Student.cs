using System.ComponentModel.DataAnnotations;

namespace lms.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [System.ComponentModel.DisplayName("code")]
        //[Range(1,4,ErrorMessage="the code must be 4 numbers ")]
        public int lessons_code { get; set; }
        [Required]
        [System.ComponentModel.DisplayName("Date")]
        public DateTime lessonsDate { get; set; }= DateTime.Now;
        

    }
}
