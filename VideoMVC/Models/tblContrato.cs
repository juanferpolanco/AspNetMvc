//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VideoMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblContrato
    {
        public int idContrato { get; set; }
        public int idCliente { get; set; }
        public decimal montoContrato { get; set; }
        public System.DateTime fechaContrato { get; set; }
    
        public virtual tblCliente tblCliente { get; set; }
    }
}
