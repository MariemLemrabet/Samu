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
    
    public partial class emergencycall
    {
        public int id { get; set; }
        public string patientName { get; set; }
        public string description { get; set; }
        public string status { get; set; }
        public Nullable<System.DateTime> createAt { get; set; }
        public Nullable<bool> isByCall { get; set; }
        public string addBy { get; set; }
        public string createBy { get; set; }
        public string phoneNumber { get; set; }
        public string address { get; set; }
        public string sex { get; set; }
        public string patientType { get; set; }
        public Nullable<int> patientCount { get; set; }
        public string accidentType { get; set; }
        public string subCategoryId { get; set; }
    }
}
