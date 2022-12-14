using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Globalization;

namespace PresentacionUsuario.Controllers
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

        [HttpGet]
        public ActionResult GuardarInformacion()
        {
            Modelo.Result result = new Modelo.Result();
            try
            {

                string RutaArchivoCSV = (string)Session["RutaArchivoCSV"];

                Modelo.Cargo cargo = GetList(RutaArchivoCSV);

                foreach (Modelo.Cargo cargoItem in cargo.Cargos)
                {
                    cargoItem.company_id = "cbf1c8b09cd5b549416d49d220a40cbd317f952e";
                    var resultAdd = Negocio.Transacciones.Add(cargoItem);
                }

            }
            catch (Exception ex)
            {

            }

            return View();
        }


        public Modelo.Cargo GetList(string filePath)
        {
            Modelo.Cargo cargo = new Modelo.Cargo();
            cargo.Cargos = new List<object>();

            string csvData = System.IO.File.ReadAllText(filePath);

            foreach (string row in csvData.Split('\n'))
            {

                if (!string.IsNullOrEmpty(row))
                {

                    var datos = row.Split(',');
                    if (datos[0] != "id")
                    {
                        cargo.Cargos.Add(new Modelo.Cargo
                        {
                            Id = datos[0],
                            company_name = datos[1],
                            company_id = datos[2],
                            amount = datos[3],
                            status = datos[4],
                            created_at = datos[5],
                            paid_at = datos[6],
                        });
                    }

                }
            }

            return cargo;
        }


        public string LeerCSV(HttpPostedFileBase postedFile)
        {
            Modelo.Cargo cargo = new Modelo.Cargo();
            string filePath = "";
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

                Session["RutaArchivoCSV"] = filePath;

            }

            return filePath;
        }

        [HttpPost]
        public ActionResult CarAll(HttpPostedFileBase postedFile)
        {
            Modelo.Cargo cargo = new Modelo.Cargo();
            cargo.Cargos = new List<object>();

            string filePath = LeerCSV(postedFile);

            cargo = GetList(filePath);


            return View(cargo);
        }





    }
}

