//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WheelyRev.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Shops
    {
        public int shopId { get; set; }
        public string shopName { get; set; }
        public string shopAddress { get; set; }
        public string contact { get; set; }
        public Nullable<int> userId { get; set; }
    
        public virtual Users Users { get; set; }
    }
}