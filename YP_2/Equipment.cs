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
    
    public partial class Equipment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Equipment()
        {
            this.Subscribers = new HashSet<Subscribers>();
        }
    
        public int kod_equipment { get; set; }
        public string seria_number { get; set; }
        public string name { get; set; }
    
        public virtual EquiomentType EquiomentType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Subscribers> Subscribers { get; set; }
    }
}
