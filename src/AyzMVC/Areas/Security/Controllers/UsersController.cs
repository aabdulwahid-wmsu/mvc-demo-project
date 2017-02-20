using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AyzMVC.Areas.Security.Models;
using AyzMVC.Dal;

namespace AyzMVC.Areas.Security.Controllers
{
    public class UsersController : Controller
    {
        private IList<UserViewModel> Users
        {
            get
            {
                if(Session["data"] == null)
                {
                    Session["data"] = new List<UserViewModel> 
                    {
                        new UserViewModel {
                             id = Guid.NewGuid(),
                             FirstName = "John",
                             LastName = "Wick",
                             age = 29,
                             Gender = "Male"
                        },

                        new UserViewModel {
                            id = Guid.NewGuid(),
                            FirstName = "Jane",
                            LastName = "Smith",
                            age = 27,
                            Gender = "Female"
                        }
                    };
                }
                return Session["data"] as List<UserViewModel>;
            }
        }

        // GET: Security/Users
        public ActionResult Index()
        {
            using (var db = new DatabaseContext())
            {
                var users = (from user in db.Users
                             select new UserViewModel
                {
                    id = user.id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    age = user.age,
                    Gender = user.Gender
                }).ToList();


                return View(users);
            }
        }

        // GET: Security/Users/Details/5
        public ActionResult Details(Guid Id)
        {
            var u = Users.FirstOrDefault(users => users.id == Id);
            return View(u);
        }

        // GET: Security/Users/Create
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: Security/Users/Create
        [HttpPost]
        public ActionResult Create(UserViewModel viewModel)
        {
         try {

             if (ModelState.IsValid == false)
                 return View();

            using (var db = new DatabaseContext())
            {
                db.Users.Add(new User
                 {
                     id = Guid.NewGuid(),
                     FirstName = viewModel.FirstName,
                     LastName = viewModel.LastName,
                     age = viewModel.age,
                     Gender = viewModel.Gender
                 });

                db.SaveChanges();
            }
            return RedirectToAction("Index");
         }
         catch
         {
                return View();
         }
        }

        // GET: Security/Users/Edit/5
        public ActionResult Edit(Guid Id)
        {
            var u = Users.FirstOrDefault(users => users.id == Id);
            
            return View(u);
        }

        // POST: Security/Users/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid Id, UserViewModel viewModel)
        {
            try
            {
                var u = Users.FirstOrDefault(users => users.id == Id);
				
				u.FirstName = viewModel.FirstName;
				u.LastName = viewModel.LastName;
                u.age = viewModel.age;
                u.Gender = viewModel.Gender;
            

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Security/Users/Delete/5
        public ActionResult Delete(Guid Id)
        {
            var u = Users.FirstOrDefault(users => users.id == Id);
            return View(u);
        }

        // POST: Security/Users/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid Id, FormCollection collection)
        {
            try
            {
                var u = Users.FirstOrDefault( users => users.id == Id);
                Users.Remove(u);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
