using System.ComponentModel.DataAnnotations.Schema;

namespace Login.Models
{
    public class UserGroup
    {
        public int UserGroupId { get; set; } // Primary Key

        [ForeignKey("UserTbl")]
        public string UserRoll { get; set; }  // Foreign key referencing UserTbl.RollNum (string)

        [ForeignKey("AlumniGroup")]
        public int GroupId { get; set; }  // Foreign key referencing AlumniGroup.GId (int)

        // Navigation properties for relationships
        public UserTbl UserTbl { get; set; } // Navigation property
        public AlumniGroup AlumniGroup { get; set; } // Navigation property
    }
}
