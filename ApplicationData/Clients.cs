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
    
    public partial class Clients
    {
        public Clients()
        {
            this.MagazineOrdersClients = new HashSet<MagazineOrdersClients>();
        }
    
        public int ClientID { get; set; }
        public string ФИО { get; set; }
        public string Паспортные_данные { get; set; }
        public string Адрес { get; set; }
        public string Номер_телефона { get; set; }
    
        public virtual ICollection<MagazineOrdersClients> MagazineOrdersClients { get; set; }
    }
}
