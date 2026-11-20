using System.Linq;
using System.Web.Mvc;
using ASPNETWebAppMVCStudentApp_Lab06.Models; // Đổi theo đúng tên Namespace project của bạn

namespace ASPNETWebAppMVCStudentApp_Lab06.Controllers
{
    public class AccountController : Controller
    {
        private SchoolDB_Ex02_Lab06Entities db = new SchoolDB_Ex02_Lab06Entities();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password)
        {
            var user = db.tblUser.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                Session["UserID"] = user.UserID;
                Session["Username"] = user.Username;
                return RedirectToAction("Index", "Students"); // Đăng nhập thành công chuyển tới trang chính
            }

            ViewBag.ErrorMessage = "Sai tên đăng nhập hoặc mật khẩu! Vui lòng thử lại.";
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}