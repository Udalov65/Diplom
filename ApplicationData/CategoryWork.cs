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
    
    public partial class CategoryWork
    {
        public CategoryWork()
        {
            this.PriceWork = new HashSet<PriceWork>();
        }
    
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    
        public virtual ICollection<PriceWork> PriceWork { get; set; }
    }
}
