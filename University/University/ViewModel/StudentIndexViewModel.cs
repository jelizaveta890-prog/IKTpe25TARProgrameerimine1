using System.ComponentModel.DataAnnotations;
using University.Models;

namespace University.ViewModel
{
    public class StudentIndexViewModel
    {
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 1)]
        public string LastName { get; set; }

        [StringLength(50, MinimumLength = 1)]
        public string FirstMidName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime EnrollmentDate { get; set; }

    }
}
