//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Acceso_De_Datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class transaccione
    {
        public string Id { get; set; }
        public string company_id { get; set; }
        public decimal amount { get; set; }
        public string status { get; set; }
        public System.DateTime created_at { get; set; }
        public Nullable<System.DateTime> paid_at { get; set; }
        public System.DateTime updated_at { get; set; }
    
        public virtual company company { get; set; }
    }
}
