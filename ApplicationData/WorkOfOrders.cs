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
    
    public partial class WorkOfOrders
    {
        public int WorkOfOrdersID { get; set; }
        public int idOrder { get; set; }
        public int idWork { get; set; }
        public double Count { get; set; }
        public double Cost
        {
            get
            {
                return (double)PriceWork.Цена * Count;
            }
        }

        public virtual MagazineOrdersClients MagazineOrdersClients { get; set; }
        public virtual PriceWork PriceWork { get; set; }
    }
}
