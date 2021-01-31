using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eshop.Application.Services.Commands.DeleteUser;
using eshop.Application.Services.Commands.EditUser;
using eshop.Application.Services.Commands.RegisterUser;
using eshop.Application.Services.Commands.UserStatusChange;
using eshop.Application.Services.Queries.GetRoles;
using eshop.Application.Services.Queries.GetUsers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Internal;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class UserController : Controller
    {
        private readonly IGetUsersService _getUsersService;
        private readonly IGetRolesService _getRolesService;
        private readonly IRegisterUserService _registerUserService;
        private readonly IDeleteUserService _deleteUserService;
        private readonly IUserStatusChangeService _userStatusChangeService;
        private readonly IEditUserService _edituserservice;

        
        // GET: UserController
        public UserController(IGetUsersService getUsersService, IGetRolesService getRolesService,
            IRegisterUserService registerUserService, IDeleteUserService deleteUserService,
            IUserStatusChangeService userStatusChangeService, IEditUserService editUserService)
        {
            _getUsersService = getUsersService;
            _getRolesService = getRolesService;
            _registerUserService = registerUserService;
            _deleteUserService = deleteUserService;
            _userStatusChangeService = userStatusChangeService;
            _edituserservice = editUserService;
        }
        public ActionResult Index(string Str_searchkey, int int_PageIndex = 1)
        {
            return View(_getUsersService.Execute(new RequestGetUserDto { Str_SearchKey = Str_searchkey, PageIndex = int_PageIndex }));
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            ViewBag.Roles = new SelectList(_getRolesService.Execute().Data, "RoleId", "RoleName");
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        public ActionResult Create(string Str_FullName, string Str_Email, int int_RoleId, string Str_Password, string Str_RePassword)
        {
            var result = _registerUserService.Execute(new RequestRegisterUserDto()
            {
                FullName = Str_FullName,
                Email = Str_Email,
                //Roles = new List<RolesInRegisterUserDto>()
                //{
                //    new RolesInRegisterUserDto
                //    {
                //        RoleId=int_RoleId
                //    }
                //},
                Password = Str_Password,
                ConfirmPassword = Str_RePassword
            });
            return View(result);
        }

        // GET: UserController/Edit/5
        public IActionResult Edit(int id)
        {
            
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(int Int_userid, string Str_fullname ,string str_Email)
        {
            return Json(_edituserservice.Execute(new RequestEditUserDto()
            {
                UserId=Int_userid,
                FullName=Str_fullname,
                Email=str_Email,
            }));
        }


        // POST: UserController/Delete/5
        [HttpPost]
        public ActionResult Delete(string UserId)
        {
            return Json(_deleteUserService.Execute(UserId));
        }

        [HttpPost]
        public IActionResult ChangeUserStatus(int UserId)
        {
            return Json(_userStatusChangeService.Execute(UserId));
        }
    }
}
