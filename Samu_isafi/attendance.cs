//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Samu_isafi
{
    using System;
    using System.Collections.Generic;
    
    public partial class attendance
    {
        public int id { get; set; }
        public Nullable<System.DateTime> clockIn { get; set; }
        public Nullable<System.DateTime> clockOut { get; set; }
        public string duration { get; set; }
        public string idUser { get; set; }
        public Nullable<bool> status { get; set; }
        public string nameUser { get; set; }
        public string phoneUser { get; set; }
        public string position { get; set; }
    }
}
