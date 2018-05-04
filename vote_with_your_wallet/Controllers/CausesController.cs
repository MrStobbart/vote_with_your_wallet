using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using vote_with_your_wallet.Entities;
using vote_with_your_wallet.Models;
using Microsoft.AspNet.Identity.Owin;

namespace vote_with_your_wallet.Controllers
{
    public class CausesController : Controller
    {
        private ApplicationDb _db;
        public ApplicationDb db
        {
            get
            {
                return _db ?? HttpContext.GetOwinContext().GetUserManager<ApplicationDb>();
            }
            private set
            {
                _db = value;
            }
        }

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: Causes/Support/5
        public async Task<ActionResult> Support(int? id)
        {

            bool UserAuthenticated = (System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
            Cause causeToUpdate = db.Causes.FirstOrDefault(cause => cause.Id == id);

            if (id == null || causeToUpdate == null || !UserAuthenticated)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var userName = User.Identity.Name;
            var user = await UserManager.FindByNameAsync(userName);

            // Only add user as support when cause is not already supported by the user
            var alreadySupported = causeToUpdate.Supporters.FirstOrDefault(u => u.UserName == userName);
            if(alreadySupported != null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    
            }


            causeToUpdate.Supporters.Add(user);
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        // GET: Causes/Create
        public ActionResult Create()
        {
            return RedirectToAction("Index", "Home");
        }

        // POST: Causes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(NewCauseViewModel model)
        {
            if (ModelState.IsValid)
            {
                Cause cause = new Cause();
                cause.Title = model.Title;
                cause.CauseTarget = model.CauseTarget;
                cause.Description = model.Description;

                db.Causes.Add(cause);
                await db.SaveChangesAsync();
                await Support(cause.Id);

                return RedirectToAction("Index", "Home");
            }

            TempData["NewCauseViewModel"] = model;
            return RedirectToAction("Index", "Home");
        }


        // GET: Causes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {

            bool UserAuthenticated = (System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
            Cause causeToDelete = db.Causes.FirstOrDefault(cause => cause.Id == id);

            if (id == null || causeToDelete == null || !UserAuthenticated)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            db.Causes.Remove(causeToDelete);
            await db.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        // POST: Causes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Cause cause = await db.Causes.FindAsync(id);
            db.Causes.Remove(cause);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
