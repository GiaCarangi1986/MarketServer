using BLL.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using BLL.Interfaces;

namespace ASPNetCore.Controllers
{
    [Produces("application/json")]
    public class AccountController : Controller
    {
        private readonly IDbCrud dbOp;

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public AccountController(IDbCrud dbCrud, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            dbOp = dbCrud;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        [Route("api/Account/Register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User();
                user.Email = model.LoginPhoneNumber;
                user.UserName = model.LoginPhoneNumber;

                // Добавление нового пользователя
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    OrderModel orderModel = new OrderModel();
                    orderModel.TotalCost = 0;
                    orderModel.DateAndTime = DateTime.Now;
                    orderModel.IdUserFk = user.Id; //подключаем внешний ключ, связаннный с id user
                    dbOp.CreateOrder(orderModel);

                    await _userManager.AddToRoleAsync(user, "user");
                    // установка куки
                    await _signInManager.SignInAsync(user, false);
                    var msg = new
                    {
                        message = "Регистрация успешно пройдена, " + user.UserName + "!",
                        oki = 1
                    };
                    return Ok(msg);
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    var errorMsg = new
                    {
                        message = "Пользователь не добавлен.",
                        error = ModelState.Values.SelectMany(e => e.Errors.Select(er => er.ErrorMessage)),
                        oki = 2
                    };
                    return Ok(errorMsg);
                }
            }
            else
            {
                var errorMsg = new
                {
                    message = "Неверные входные данные.",
                    error = ModelState.Values.SelectMany(e => e.Errors.Select(er => er.ErrorMessage)),
                    oki = 2
                }; return Ok(errorMsg);
            }
        }

        [HttpPost]
        [Route("api/Account/Login")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result =
                    await _signInManager.PasswordSignInAsync(model.LoginPhoneNumber, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    List<UserModel> users = new List<UserModel>();
                    users = dbOp.GetAllUsers();
                    var userId = "";
                    foreach (var item in users)
                        if (item.UserName == model.LoginPhoneNumber)
                            userId = item.ID;

                    var role = "";
                    if (model.LoginPhoneNumber == "lizakurochkina")
                        role = "admin";
                    else role = "user";
                    var msg = new
                    {
                        message = "Выполнен вход пользователем: " + model.LoginPhoneNumber,
                        oki = 1,
                        role,
                        userId
                    };
                    return Ok(msg);
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                    var errorMsg = new
                    {
                        message = "Вход не выполнен.",
                        error = ModelState.Values.SelectMany(e => e.Errors.Select(er => er.ErrorMessage)),
                        oki = 2,
                        role = "guest"
                    };
                    return Ok(errorMsg);
                }
            }
            else
            {
                var errorMsg = new
                {
                    message = "Вход не выполнен.",
                    error = ModelState.Values.SelectMany(e => e.Errors.Select(er => er.ErrorMessage)),
                    oki = 2
                };
                return Ok(errorMsg);
            }
        }

        [HttpPost]
        [Route("api/account/logoff")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOff()
        {
            // Удаление куки
            await _signInManager.SignOutAsync();
            var msg = new
            {
                message = "Выполнен выход.",
                oki = 1
            };
            return Ok(msg);
        }

        [HttpPost]
        [Route("api/Account/isAuthenticated")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> LogisAuthenticatedOff()
        {
            User usr = await GetCurrentUserAsync();

            if (usr == null)
            {
                var message = "Вы Гость. Пожалуйста, выполните вход.";
                var msg = new
                {
                    message,
                    oki = 2,
                    userId = 0,
                    role = "guest"
                };
                return Ok(msg);
            }
            else
            {
                var message = "Вы вошли как: " + usr.UserName;

                var role = "";
                if (usr.UserName == "lizakurochkina")
                    role = "admin";
                else role = "user";

                var msg = new
                {
                    message,
                    oki = 1,
                    userId = usr.Id,
                    role
                };
                return Ok(msg);
            }
        }
        private Task<User> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
    }
}
