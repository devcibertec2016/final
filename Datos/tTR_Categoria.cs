//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class tTR_Categoria
    {
        public tTR_Categoria()
        {
            this.tTR_Producto = new HashSet<tTR_Producto>();
        }
    
        public int iIdCategoria { get; set; }
        public string vNombreCategoria { get; set; }
        public Nullable<int> iEstado { get; set; }
        public int iEstadoEliminar { get; set; }
    
        public virtual ICollection<tTR_Producto> tTR_Producto { get; set; }
    }
}
