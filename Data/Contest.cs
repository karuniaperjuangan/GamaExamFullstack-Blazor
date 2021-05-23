using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamaExamFullstack.Data
{
    public class Contest
    {
        [Key]
        public int Id { get; set; } // id di database itu nanti jadinya int apa string yak? :v sementara int aja dulu lah ya wkwk
        [Column(TypeName = "nvarchar(50)")]
        public string Title { get; set; }
        [Column(TypeName = "int")]
        public int Duration { get; set; } // menit
        [Column(TypeName = "int")]
        public int NumOfQuestion { get; set; }
        [Column(TypeName = "datetime2(7)")]
        public DateTime StartTime { get; set; }
        [Column(TypeName = "datetime2(7)")]
        public DateTime EndTime { get; set; }

        [ForeignKey("DCreator")]
        public int CreatorId { get; set; }
        public DCreator Creator { get; set; }

        // public List<Question> Questions { get; set; } // -> ini berarti gajadi ada kan ya
        public ICollection<Question> Questions { get; set; }
    }
}
