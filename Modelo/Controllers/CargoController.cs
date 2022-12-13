using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace Modelo.Controllers
{
    public class CargoController : Controller
    {
        
        public ActionResult Index()
        {
            return View(new Negocio.Cargo());
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase postedFile)
        {
            Negocio.Cargo customers = new Negocio.Cargo();


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
                foreach (string row in csvData.Split("\n"))
                {
                    if (!string.IsNullOrEmpty(row))
                    {
                        customers.Add(new Cargo
                        {
                            Id = Convert.ToInt32(row.Split(",")[0]),
                            name = row.Split(",")[1],
                            company_id = row.Split(",")[3],
                            amount = row.Split(",")[4],
                            status = row.Split(",")[5],
                            created_at = row.Split(",")[6],
                            paid_at = row.Split(",")[7],
                        });
                    }
                }
            }
            return View(customers);
        }

    }
}

}