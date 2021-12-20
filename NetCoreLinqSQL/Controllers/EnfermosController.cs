using Microsoft.AspNetCore.Mvc;
using NetCoreLinqSQL.Data;
using NetCoreLinqSQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreLinqSQL.Controllers
{
    public class EnfermosController : Controller
    {
        EnfermosContext context;

        //constructor
        public EnfermosController()
        {
            this.context = new EnfermosContext();
        }
        public IActionResult TodosEnfermos()
        {
            List<Enfermo> enfermos = this.context.GetEnfermos();
            return View(enfermos);
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Delete(string idenfermo) 
        {
            
        }
    }
}
