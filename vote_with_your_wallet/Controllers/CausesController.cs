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
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            bool UserAuthenticated = (System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
            var causeToUpdate = db.Causes.First(cause => cause.Id == id);

            if (causeToUpdate != null && UserAuthenticated)
            {
                var userName = User.Identity.Name;
                var user = await UserManager.FindByNameAsync(userName);
                causeToUpdate.Supporters.Add(user);
                db.Causes.Attach(causeToUpdate);
                //db.Entry(causeToUpdate).CurrentValues.SetValues(causeToUpdate);
                db.SaveChanges();
            }

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

        // GET: Causes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cause cause = await db.Causes.FindAsync(id);
            if (cause == null)
            {
                return HttpNotFound();
            }
            return View(cause);
        }

        // POST: Causes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Title,CauseTarget,Description")] Cause cause)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cause).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cause);
        }

        // GET: Causes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cause cause = await db.Causes.FindAsync(id);
            if (cause == null)
            {
                return HttpNotFound();
            }
            return View(cause);
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
