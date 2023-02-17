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
    public class ContactsController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // POST: api/Contacts
        public ErrorReporting PostContacts(Contacts contacts)
        {
            if (!ModelState.IsValid)
            {
                return new ErrorReporting() { Error = true, ErrorDetail = BadRequest(ModelState), Results =null };
            } else if (ContactsExists(contacts.Email))
            {
                return new ErrorReporting() { Error = true, ErrorDetail = "That email address '" + contacts.Email +"' has already been used.", Results =null };
            }

            db.Contacts.Add(contacts);
            db.SaveChanges();

            return new ErrorReporting() { Error = false, ErrorDetail = null, Results = contacts.ID };
        }


        private bool ContactsExists(string email)
        {
            return db.Contacts.Count(e => e.Email == email) > 0;
        }
    }
}