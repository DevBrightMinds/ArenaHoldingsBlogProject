using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using ArenaBlogAPI.Models;

namespace ArenaBlogAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ContactsController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: api/Contacts
        public ErrorReporting GetContacts()
        {

            try
            {
                List<Contacts> ContactsList = db.Contacts.ToList();

                return new ErrorReporting() { Error = false, ErrorDetail = null, Results = ContactsList };
            }
            catch (Exception e)
            {
                return new ErrorReporting() { Error = true, ErrorDetail = e.Message, Results = null };
            }

        }

        // POST: api/Contacts
        public ErrorReporting PostContacts(Contacts contacts)
        {
          try
          {
                Contacts contact = GetExisitingEntry(contacts.Email);

                if (!ModelState.IsValid)
                {
                    return new ErrorReporting() { Error = true, ErrorDetail = "Please fill in all required fields.", Results = null };

                }
                else if (!IsValidEmail(contacts.Email))
                {

                    return new ErrorReporting() { Error = true, ErrorDetail = "Please provide a valid email address.", Results = null };

                }
                else if (contact != null)
                {
                    return new ErrorReporting() { Error = true, ErrorDetail = "That email address '" + contacts.Email + "' has already been used.", Results = null };
                }

                db.Contacts.Add(contacts);
                db.SaveChanges();

                return new ErrorReporting() { Error = false, ErrorDetail = null, Results = contacts.ID };
          }
          catch (Exception e)
          {
                return new ErrorReporting() { Error = true, ErrorDetail = e.Message, Results = null };
          }
        }

        public Contacts GetExisitingEntry(string email)
        {
            Contacts contact = db.Contacts.FirstOrDefault(item => item.Email == email);

            return contact;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public bool IsValidEmail(string email)
        {
            return new EmailAddressAttribute().IsValid(email);
        }
    }
}