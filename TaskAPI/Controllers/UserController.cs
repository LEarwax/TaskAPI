using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskAPI.Models;
using TaskAPI.DataAccess;
using Newtonsoft.Json;

namespace TaskAPI.Controllers
{
    
    public class UserController : Controller
    {
        readonly UserData _dal;

        public UserController(UserData dal)
        {
            _dal = dal;    
        }

        [Route("api/[controller]")]
        [HttpGet]
        public JsonResult GetAll()
        {
            var result = Json(_dal.GetAll());
            return result;
        }

        [HttpPost]
        [Route("api/[controller]")]
        public JsonResult New(User user)
        {
            var result = Json(_dal.Create(user.Name, user.Password));
            return result;
        }

        [Route("api/[controller]/{id}")]
        [HttpGet]
        public JsonResult GetOne(int id)
        {
            var result = Json(_dal.GetOne(id));
            return result;
        }

        // update a user

        // delete a user


    }





}
