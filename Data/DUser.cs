using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GamaExamFullstack.Data
{
    public abstract class DUser
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string username { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string name { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string password { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string institute { get; set; }

        public bool isLoggedIn = false;
    }

    public class DCreator : DUser
    {
        public ICollection<Contest> CreatedContest { get; set; }
    }

    public class DParticipant : DUser
    {
    }
}
