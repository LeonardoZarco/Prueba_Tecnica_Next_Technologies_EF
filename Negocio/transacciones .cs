using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Transacciones
    {

        public static Modelo.Result Add(Modelo.Cargo cargo)
        {
            Modelo.Result result = new Modelo.Result();
            try
            {
                using (Acceso_De_Datos.NT_GroupEntities context = new Acceso_De_Datos.NT_GroupEntities())
                {
                    Acceso_De_Datos.transaccione cargoL = new Acceso_De_Datos.transaccione();


                    cargoL.Id = cargo.Id;
                    cargoL.company_id = cargo.company_id;
                    cargoL.amount = decimal.Parse(cargo.amount);
                    cargoL.status = cargo.status;
                    cargoL.created_at = DateTime.ParseExact(cargo.created_at, "yyyy-MM-dd", null);

                    //Nullable<DateTime> paid_at = null;
                    //if (cargo.paid_at != "\r\r")
                    //{
                    //    paid_at = DateTime.ParseExact(cargo.paid_at, "yyyy-MM-dd", null);
                    //    cargoL.paid_at = paid_at;
                    //}                 
                    cargoL.paid_at = DateTime.Now;
                    cargoL.updated_at = DateTime.Now;


                    if (cargo != null)
                    {
                        context.transacciones.Add(cargoL);
                        context.SaveChanges();
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }


    }
}
