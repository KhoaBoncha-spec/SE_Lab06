using ASPNETWebAppMVCStudentApp_Lab06.Models;
using ASPNETWebAppMVCStudentApp_Lab06;
using Microsoft.Reporting.WebForms;
using System.Linq;
using System.Web.Mvc;

namespace ASPNETWebAppMVCStudentApp_Lab06.Controllers
{
    public class ReportController : Controller
    {
        private readonly SchoolDB_Ex02_Lab06Entities _context = new SchoolDB_Ex02_Lab06Entities();

        public ActionResult Index()
        {
            var model = new CourseViewModel
            {
                Courses = new SelectList(_context.Courses.ToList(), "CourseID", "Title")
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Generate(int SelectedCourseID, string action)
        {
            string reportPath = Server.MapPath("~/Reports/StudentReport.rdlc");
            LocalReport localReport = new LocalReport { ReportPath = reportPath };

            var students = _context.Enrollments
                .Where(e => e.CourseID == SelectedCourseID)
                .Select(e => new StudentReportDTO
                {
                    StudentID = e.Students.StudentID,
                    FirstName = e.Students.FirstName,
                    LastName = e.Students.LastName,
                    Grade = e.Grade
                }).ToList();

            localReport.DataSources.Add(new ReportDataSource("StudentDataSet", students));

            byte[] reportBytes = localReport.Render("PDF");

            if (action == "preview")
            {
                // Hiển thị trực tiếp PDF trên trình duyệt để xem trước (Print Preview)
                return File(reportBytes, "application/pdf");
            }
            else
            {
                // Tải file PDF về máy (Export to PDF)
                return File(reportBytes, "application/pdf", "StudentReport.pdf");
            }
        }
    }
}