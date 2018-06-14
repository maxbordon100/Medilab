﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MediLab.Models;
using MediLab.Controllers.MyClasses;
using System.Web.Routing;

namespace MediLab.Controllers
{
    public class ImagenController : Controller
    {

        MedicinaEntities db;
        public ImagenController()
        {
            db = new MedicinaEntities();

        }
        public ActionResult Index(ResultSet response=null,int page=1,int pageSize=5)
        {
           
           if (page <= 0)
            {
                page = 1;
            }
            if (pageSize <= 0)
            {
                pageSize = 5;
            }
            int totalRecord = db.Imagen.Count();
            ViewBag.dbcount= (totalRecord / pageSize) + ((totalRecord % pageSize) > 0 ? 1 : 0);
            var imagenes = db.Imagen.OrderBy(s => s.Id).Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return View(imagenes.AsEnumerable());        
        }
     
      

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        { try
            {
                ResultSet response = new ResultSet();
                /* MedicinaEntities db = new MedicinaEntities();
                 Topico topico = new Topico()
                 {
                     Nombre = collection["Nombre"],
                     Descripcion = collection["Descripcion"]


                 };
                db.Topico.Add(topico);
                db.SaveChanges();
                response.Code = 1;
                response.Msg = String.Format("Se creó el topico {0}", topico.Nombre);     */
                return RedirectToAction("Index", new RouteValueDictionary(response));

            }
            catch
            {
                return View();
            }            
        }
        public ActionResult Edit(int id)
        {
            
            Imagen imagen = db.Imagen.Where(s => s.Id.Equals(id)).First();            
            return View(imagen);
        }
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                ResultSet response = new ResultSet();
               /* MedicinaEntities db = new MedicinaEntities();           
                Topico topico = db.Topico.Where(s => s.Id.Equals(id)).First();
                topico.Nombre = collection["Nombre"];
                topico.Descripcion = collection["Descripcion"];
                db.SaveChanges();
                response.Code = 1;
                response.Msg = String.Format("Se editó el topico {0}", topico.Nombre); */
                return RedirectToAction("Index", new RouteValueDictionary(response));
                
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Details(int id)
        {
            MedicinaEntities db = new MedicinaEntities();
            Topico topico = db.Topico.Where(s => s.Id.Equals(id)).First();
            return View(topico);
        }
        public ActionResult Delete(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}