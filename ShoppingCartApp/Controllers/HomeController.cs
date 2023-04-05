using ShoppingCartApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCartApp.Controllers
{
    public class HomeController : Controller
    {
        CartDBContext cd = new CartDBContext();
        public ActionResult Index(string searchBy, string search)
        {
            //var products = cd.products.ToList();
            //return View(cd.products.ToList());

            if (searchBy == "ProductName")
            {
                var data = cd.products.Where(m=>m.ProductName.StartsWith(search)).ToList();
                return View(data);
            }
            else if (searchBy == "ProductCategory")
            {
                var data = cd.products.Where(m => m.ProductCategory.StartsWith(search)).ToList();
                return View(data);
            }
            else
            {
                var data = cd.products.ToList();
                return View(data);
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Customer customer)
        {
            if (ModelState.IsValid)
            {
                cd.customers.Add(customer);
                cd.SaveChanges();
                ModelState.Clear();
                ViewBag.Message = customer.Name + "successfully registered.";
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Some Error Occurred");
            }
            return View(customer);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Customer customersUser)
        {
            
            var obj = cd.customers.FirstOrDefault(u => u.EmailId == customersUser.EmailId && u.Password == customersUser.Password);
            if (obj != null)
            {
                Session["UserId"] = obj.UserId.ToString();
                Session["EmailId"] = obj.EmailId.ToString();
                return RedirectToAction("LoggedIn");
            }
            else
            {
                ModelState.AddModelError("", "Email Id or Password is wrong!");
            }
           
            return View();
        }

        public ActionResult LoggedIn(string searchBy, string search)
        {
            if (Session["UserId"] != null)
            {
                if (searchBy == "ProductName")
                {
                    var data = cd.products.Where(m => m.ProductName.StartsWith(search)).ToList();
                    return View(data);
                }
                else if (searchBy == "ProductCategory")
                {
                    var data = cd.products.Where(m => m.ProductCategory.StartsWith(search)).ToList();
                    return View(data);
                }
                else
                {
                    var data = cd.products.ToList();
                    return View(data);
                }
                //return View(cd.products.ToList());
            }
            else
            {
                return RedirectToAction("Login");
            }

        }

        public ActionResult MerchantRegister()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MerchantRegister(Merchant merchant)
        {
            if (ModelState.IsValid)
            {
                cd.merchants.Add(merchant);
                cd.SaveChanges();
                ModelState.Clear();
                ViewBag.Message = merchant.MerchantName + "successfully registered.";
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Some Error Occurred");
            }
            return View(merchant);
        }

        public ActionResult MerchantLogin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MerchantLogin(Merchant merchantUser)
        {
            
            var obj = cd.merchants.FirstOrDefault(u => u.MerchantEmail == merchantUser.MerchantEmail && u.MerchantPassword == merchantUser.MerchantPassword);
            if (obj != null)
            {
                Session["MerchantId"] = obj.MerchantId.ToString();
                Session["MerchantEmail"] = obj.MerchantEmail.ToString();
                return RedirectToAction("MLoggedIn");
            }
            else
            {
                ModelState.AddModelError("", "Email Id or Password is wrong!");
            }
            
            return View();
        }

        public ActionResult MLoggedIn()
        {
            if (Session["MerchantId"] != null)
            {
                return RedirectToAction("Index", "Products");
            }
            else
            {
                return RedirectToAction("MerchantLogin");
            }

        }

    }
}