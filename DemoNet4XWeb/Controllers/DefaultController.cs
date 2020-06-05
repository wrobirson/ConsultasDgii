using DemoNet4XWeb.Models;
using Octetus.ConsultasDgii.ConsultasWeb;
using Octetus.ConsultasDgii.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoNet4XWeb.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View(new ConsultaDgiiModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ConsultaDgiiModel model)
        {
            if (ModelState.IsValid)
            {
                DgiiScraper dgiiScraper = new DgiiScraper();
                model.Response = dgiiScraper.Execute(new DgiiQueryRequest
                {
                    Rnc = model.RncOCedula
                });

                if (!model.Response.IsOk)
                {
                    ModelState
                        .AddModelError(nameof(model.RncOCedula), "El RNC/Cédula ingresado no esta registrado.");
                }
            }

            return View(model);
        }
    }
}