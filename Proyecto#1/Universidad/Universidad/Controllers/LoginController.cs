using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Universidad.Models;
using Universidad.Utility;

namespace Universidad.Controllers
{
    public class LoginController : Controller
    {


        private readonly IUtility _utility;
        private readonly AppSettings _appSettings;

        public LoginController(IUtility utility, AppSettings appSettings)
        {
            _utility = utility;
            _appSettings = appSettings;
        }


        // GET: LoginController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexMessage(User user)
        {
            return View("Index",user);
        }

        [HttpPost]
        public ActionResult Index(User user)
        {
            try
            {
                if (user != null)
                {
                    user.Name = user.Email;
                    user.LastName = user.Email;
                    User userLogin = JsonConvert.DeserializeObject<User>(_utility.RestClient.Post(_appSettings.url.Login, JsonConvert.SerializeObject(user)));

                    if (userLogin != null)
                    {
                        if (userLogin.status)
                        {
                            userLogin.message = "Enter your verification code sent to the registered email";
                            return RedirectToAction(nameof(VerifyCode), userLogin);
                        }
                        else
                        {
                            return View();
                        }
                    }
                    else
                    {
                        user.message = "Login Failed! User does not exist or wrong password";
                        return RedirectToAction(nameof(IndexMessage), user);
                    }
                }
            }
            catch
            {
                return View();
            }
            return View();
        }


        // GET: LoginController/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult CreateMessage(User user)
        {
            return View("Create",user);
        }

        // POST: LoginController/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {
                if (user != null)
                {
                    User userSave = JsonConvert.DeserializeObject<User>(_utility.RestClient.Post(_appSettings.url.SaveUser, JsonConvert.SerializeObject(user)));

                    if (userSave != null)
                    {
                        userSave.message = "Successful registration!";
                        return RedirectToAction(nameof(CreateMessage), userSave);
                    }
                    else
                    {
                        userSave.message = "Failed registration!";
                        return RedirectToAction(nameof(CreateMessage), userSave);
                    }
                }
                else
                { 
                    user.message = "Data not found";
                    return RedirectToAction(nameof(CreateMessage), user);
                }
            }
            catch
            {
                user.message = "Error to save user";
                return RedirectToAction(nameof(CreateMessage), user);
            }
        }

        // GET: LoginController/VerifyCode
        public ActionResult VerifyCode(User user)
        {
            return View(user);
        }

        // POST: LoginController/VerifyCode
        [HttpPost]
        public ActionResult VerifyCodeUser(User user)
        {
            try
            {
                if (user != null)
                {
                    User userVerify = JsonConvert.DeserializeObject<User>(_utility.RestClient.Post(_appSettings.url.VerifyCode, JsonConvert.SerializeObject(user)));
                    if (userVerify.status)
                    {

                        string cookieValueFromReq = Request.Cookies["EmailUser"];
                        //set the key value in Cookie  
                        Set("EmailUser", userVerify.Email,10);
                        return Redirect("/Home/index");
                    }
                    else
                    {
                        return View(nameof(VerifyCode), userVerify);
                    }
                }
                return RedirectToAction(nameof(VerifyCode), user);
            }
            catch
            {
                return View();
            }
        }

        public void Set(string key, string value, int? expireTime)
        {
            CookieOptions option = new CookieOptions();

            if (expireTime.HasValue)
                option.Expires = DateTime.Now.AddMinutes(expireTime.Value);
            else
                option.Expires = DateTime.Now.AddMilliseconds(10);

            Response.Cookies.Append(key, value, option);
        }
    }
}
