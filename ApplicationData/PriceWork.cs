//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Diplom.ApplicationData
{
    using System;
    using System.Collections.Generic;
    
    public partial class PriceWork
    {
        public PriceWork()
        {
            this.WorkOfOrders = new HashSet<WorkOfOrders>();
        }
    
        public int WorkID { get; set; }
        public string Работа { get; set; }
        public string Единица { get; set; }
        public decimal Цена { get; set; }
        public int idCategory { get; set; }
    
        public virtual CategoryWork CategoryWork { get; set; }
        public virtual ICollection<WorkOfOrders> WorkOfOrders { get; set; }
    }
}
