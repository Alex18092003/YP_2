//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace YP_2
{
    using System;
    using System.Collections.Generic;
    
    public partial class Districts
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Districts()
        {
            this.Subscribers = new HashSet<Subscribers>();
        }
    
        public int kod_district { get; set; }
        public string district { get; set; }
        public Nullable<decimal> square { get; set; }
        public Nullable<int> population { get; set; }
        public Nullable<int> number_metro_stations { get; set; }
        public Nullable<int> building_type { get; set; }
    
        public virtual BuildingType BuildingType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Subscribers> Subscribers { get; set; }
    }
}
