using System;
using System.ComponentModel.DataAnnotations;


namespace Login.Models

{
    public class AlumniGroup
    {
        [Key]
        public int G_Id { get; set; } // Primary Key
        public string Name { get; set; } // Group Name
        public string Description { get; set; } // Group Description

        public UserGroup UserGroup { get; set; }
    }

}