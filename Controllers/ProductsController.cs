using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductsController : Controller
    {
        UnitOfWork.UnitOfWork unitOfWork;

        public ProductsController()
        {
            unitOfWork = new UnitOfWork.UnitOfWork();
        }

        // GET: Products
        public ActionResult Index()
        {
            return View(unitOfWork.ProductsRepository.FindAll());
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            return View(unitOfWork.ProductsRepository.FindById(id));
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(Products products)
        {
            try
            {
                // TODO: Add insert logic here
                unitOfWork.ProductsRepository.Add(products);
                unitOfWork.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            return View(unitOfWork.ProductsRepository.FindById(id));
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Products products)
        {
            try
            {
                // TODO: Add update logic here
                unitOfWork.ProductsRepository.Edit(products);
                unitOfWork.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            return View(unitOfWork.ProductsRepository.FindById(id));
        }

        // POST: Products/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Products products)
        {
            try
            {
                // TODO: Add delete logic here
                unitOfWork.ProductsRepository.Remove(unitOfWork.ProductsRepository.FindById(id));
                unitOfWork.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
