//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MasterOK
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrderSet
    {
        public int id { get; set; }
        public int idClient { get; set; }
        public int idEmployee { get; set; }
        public int idProduct { get; set; }
        public string Date { get; set; }
    
        public virtual ClientsSet ClientsSet { get; set; }
        public virtual EmployeeSet EmployeeSet { get; set; }
        public virtual ProductSet ProductSet { get; set; }
    }
}
