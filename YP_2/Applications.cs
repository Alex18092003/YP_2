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
    
    public partial class Applications
    {
        public int kod_applications { get; set; }
        public string number_applications { get; set; }
        public System.DateTime date_of_creation { get; set; }
        public int kod_subscribers { get; set; }
        public int kod_service { get; set; }
        public int kod_service_view { get; set; }
        public int kod_service_type { get; set; }
        public int kod_statuse { get; set; }
        public Nullable<int> type_equipment { get; set; }
        public Nullable<int> kod_description { get; set; }
        public Nullable<System.DateTime> closing_date { get; set; }
        public int kod_problem_types { get; set; }
    
        public virtual DescriptionsProblems DescriptionsProblems { get; set; }
        public virtual ProblemTypes ProblemTypes { get; set; }
        public virtual Services Services { get; set; }
        public virtual ServicesTypes ServicesTypes { get; set; }
        public virtual ServicesView ServicesView { get; set; }
        public virtual Statuses Statuses { get; set; }
        public virtual Subscribers Subscribers { get; set; }
    }
}
