//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TreeViewProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_notes
    {
        public int Note_Id { get; set; }
        public string Note_Name { get; set; }
        public Nullable<int> Note_ParentId { get; set; }
        public Nullable<int> Note_IsActive { get; set; }
    }
}
