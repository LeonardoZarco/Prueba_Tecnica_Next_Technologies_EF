using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Modelo;


namespace Presentacion.Controllers
{
    public class CargoController : Controller
    {
        [HttpGet]
        public ActionResult CarAll()
        {
            
            Modelo.Cargo cargo = new Modelo.Cargo();
            cargo.Cargos = new List<object>();
            return View(cargo);
        }

        [HttpPost]
        
        public ActionResult CarAll(HttpPostedFileBase postedFile)
        {
            Modelo.Cargo cargo = new Modelo.Cargo();


            string filePath = string.Empty;
            if (postedFile != null)
            {
                string path = Server.MapPath("~/Insert/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                filePath = path + Path.GetFileName(postedFile.FileName);
                string extension = Path.GetExtension(postedFile.FileName);
                postedFile.SaveAs(filePath);

                string csvData = System.IO.File.ReadAllText(filePath);
                //var list= csvData.Split()
                foreach (string row in csvData.Split('\n'))
                {
                    if (!string.IsNullOrEmpty(row))
                    {
                        cargo.Cargos.Add(new Modelo.Cargo
                        {
                            Id = row.Split(',')[0],
                            company_name = row.Split(',')[1],
                            company_id = row.Split(',')[2],
                            amount = row.Split(',')[3],
                            status = row.Split(',')[4],
                            created_at = row.Split(',')[5],
                            paid_at= row.Split(',')[6],
                            updated_at = row.Split(',')[7],
                        });
                    }
                }
            }
            return View(cargo);
        }





    }
}

