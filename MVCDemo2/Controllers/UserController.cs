using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDemo2.Models;

namespace MVCDemo2.Controllers
{
    public class UserController : Controller
    {

        private static UserRepository _userRepository = new UserRepository();
        // GET: User
        public ActionResult Index()
        {
            return View(_userRepository.UserModels);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserModel userModel)
        {
            _userRepository.Add(userModel);

            return View(userModel);
        }

        public ActionResult Delete([Bind(Prefix = "Id")]int userId)
        {
            return View(_userRepository.GetById(userId));
        }
        [HttpPost]
        public ActionResult Delete(UserModel userModel)
        {
            _userRepository.DeleteById(userModel.Id);
            return RedirectToAction("Index");
        }

        public ActionResult Edit([Bind(Prefix = "Id")]int userId)
        {
            var user = _userRepository.GetById(userId);
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(UserModel user)
        {
            _userRepository.Edit(user);

            return RedirectToAction("Index");
        }

    }
}