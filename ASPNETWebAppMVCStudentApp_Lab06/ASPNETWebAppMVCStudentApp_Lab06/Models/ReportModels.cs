using System.Web.Mvc;

namespace ASPNETWebAppMVCStudentApp_Lab06.Models
{
    public class CourseViewModel
    {
        public int SelectedCourseID { get; set; }
        public SelectList Courses { get; set; }
    }

    public class StudentReportDTO
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal? Grade { get; set; }
    }
}