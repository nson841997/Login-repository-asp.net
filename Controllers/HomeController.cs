using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Reponsitory_Demo.Models;
using System.Security.Cryptography;
using System.Text;
using Reponsitory_Demo.Repositories;

namespace Reponsitory_Demo.Controllers
{
    public class HomeController : Controller
    {
        //private DB_Entities _db = new DB_Entities();
        private GenericRepository<User> repository = null;
        private UserRepository userRepository = null;
        public HomeController()
        {
            this.userRepository = new UserRepository();
            this.repository = new GenericRepository<User>();
        }
        public HomeController(GenericRepository<User> repository, 
                                    UserRepository userRepository)
        {
            this.repository = repository;
            this.userRepository = userRepository;
        }
        //GET Home
        public ActionResult Index()
        {
            if (Session[ "idUser" ] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        // GET: Register
        public ActionResult Register()
        {
            return View();
        }
        // POST : Register
        [HttpPost]
        // kiem tra tinh hop le token
        [ValidateAntiForgeryToken]
        public ActionResult Register(User _user)
        {
            if (ModelState.IsValid)
            {
                var check = userRepository.WhereEmail(_user.Email);
                if (check == null)
                {
                    _user.Password = GetMD5(_user.Password);
                    userRepository.Insert(_user);
                    userRepository.Save();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Oh my god! Email already exists. Again!";
                    return View();
                }
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {
                var f_password = GetMD5(password);
                var data = userRepository.CheckLogin(email, f_password);
                if (data.Count()>0)
                {
                    Session["FullName"] = data.FirstOrDefault().FirstName + " " +
                                          data.FirstOrDefault().LastName;
                    Session["Email"] = data.FirstOrDefault().Email;
                    Session["idUser"] = data.FirstOrDefault().idUser;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Account or password false!";
                    return View();
                }
            }
            return View();
        }
        // Logout
        public ActionResult Logout()
        {
            Session.Clear(); // remove Session
            return RedirectToAction("Login");
        }
        // create a string MD5
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targerData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targerData.Length; i++)
            {
                byte2String += targerData[i].ToString( "x2" );
            }
            return byte2String;
        }
    }
}