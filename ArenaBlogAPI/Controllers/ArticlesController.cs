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
    public class ArticlesController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: api/Articles
        public ErrorReporting GetArticles()
        {
            
            try
            {
                List<Articles> ArticlesList = db.Articles.ToList();

                return new ErrorReporting() { Error = false, ErrorDetail = null, Results = ArticlesList };
            }
            catch (Exception e)
            {
                return new ErrorReporting() { Error = true, ErrorDetail = e.Message, Results = null };
            }
      
        }

        // GET: api/Articles/5
        public ErrorReporting GetArticles(int id)
        {
            try
            {
                Articles articles = db.Articles.FirstOrDefault(article => article.ID == id);
                if (articles == null)
                {

                    return new ErrorReporting() { Error = true, ErrorDetail = NotFound(), Results = null };
                }

                return new ErrorReporting() { Error = false, ErrorDetail = null, Results = articles };
            }
            catch(Exception e)
            {
                return new ErrorReporting() { Error = true, ErrorDetail = e.Message, Results = null };
            }

        }

        // PUT: api/Articles/5
        public ErrorReporting PutArticles(int id, Articles articles)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return new ErrorReporting() { Error = true, ErrorDetail = BadRequest(ModelState), Results = null };
                }

                if (id != articles.ID)
                {
                    return new ErrorReporting() { Error = true, ErrorDetail = BadRequest(), Results = null };
                }

                db.Entry(articles).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticlesExists(id))
                    {
                        return new ErrorReporting() { Error = true, ErrorDetail = NotFound(), Results = null };
                    }
                    else
                    {
                        throw;
                    }
                }

                return new ErrorReporting() { Error = false, ErrorDetail = null, Results = id };
            }
            catch(Exception e)
            {
                return new ErrorReporting() { Error = true, ErrorDetail = e.Message, Results = null };
            }
        }

        // POST: api/Articles
        public ErrorReporting PostArticles(Articles articles)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return new ErrorReporting() { Error = true, ErrorDetail = "Please fill in all required fields.", Results = null };
                }

                db.Articles.Add(articles);
                db.SaveChanges();

                return new ErrorReporting() { Error = false, ErrorDetail = null, Results = articles.ID };
            }
            catch (Exception e)
            {
                return new ErrorReporting() { Error = true, ErrorDetail = e.Message, Results = null };
            }
        }

        // DELETE: api/Articles/5
        public ErrorReporting DeleteArticles(int id)
        {
            try
            {
                Articles articles = db.Articles.FirstOrDefault(article => article.ID == id);
                if (articles == null)
                {
                    return new ErrorReporting() { Error = true, ErrorDetail = NotFound(), Results = null };
                }

                db.Articles.Remove(articles);
                db.SaveChanges();

                return new ErrorReporting() { Error = false, ErrorDetail = null, Results = id };
            } 
            catch (Exception e)
            {
                return new ErrorReporting() { Error = true, ErrorDetail = e.Message, Results = null };
            }

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        private bool ArticlesExists(int id)
        {
            return db.Articles.Count(e => e.ID == id) > 0;
        }
    }
}