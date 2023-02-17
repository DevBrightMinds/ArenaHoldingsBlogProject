using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ArenaBlogAPI.Models;

namespace ArenaBlogAPI.Controllers
{
    public class UsersController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // we will not get any fancy here by building a complex login system
        // the focus is on the creation of articles and the contact form
        // this is a basic login/registration system that will not even hash the password string 

        // GET: api/Users/5
        public ErrorReporting GetUsers([FromBody] Users item)
        {
            Users users = db.Users.FirstOrDefault(user => user.Username == item.Username && user.Password == item.Password);

            if (users == null)
            {
                return new ErrorReporting() { Error = true, ErrorDetail = NotFound(), Results = null };
            }

            return new ErrorReporting() { Error = false, ErrorDetail =null, Results = users };
        }

        // POST: api/Users
        public ErrorReporting PostUsers(Users users)
        {
            if (!ModelState.IsValid)
            {
                return new ErrorReporting() { Error = true, ErrorDetail = BadRequest(ModelState), Results = null };
            } else if(UsersExists(users.Username))
            {
                return new ErrorReporting() { Error = true, ErrorDetail = "That username '" + users.Username + "' has been taken, try a different one.", Results = null };
            }

            db.Users.Add(users);
            db.SaveChanges();

            return new ErrorReporting() { Error = false, ErrorDetail = null, Results = users.ID };

        }

        private bool UsersExists(string username)
        {
            return db.Users.Count(e => e.Username == username) > 0;
        }
    }
}