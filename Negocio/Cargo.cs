using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Cargo
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string company_name { get; set; }
        public string company_id { get; set; }
        public string amount { get; set; }
        public string status { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public List<object> Cargos { get; set; }

        public static Result AddL(Cargo cargo)
        {
           Result result = new Result();
            try
            {
                using ()
                {
                    Cargo cargo = new Cargo();

                    cargo.Id = cargo.Id;
                    cargo.name = cargo.name;
                    cargo.company_id = cargo.company_id;
                    cargo.amount = cargo.amount;
                    cargo.status = cargo.status;
                    cargo.created_at = cargo.created_at;

                    cargo.paid_at = cargo.paid_at;
                    

                    context.Cargas.Add(cargo);
                    context.SaveChanges();
                }
                result.Correct = true;
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }






    }
}
