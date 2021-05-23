using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamaExamFullstack.Data
{
    public class QuestionAnswer
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "int")]
        public int QuestionNumber { get; set; }

        [Column(TypeName = "char(1)")]
        public char Answer { get; set; }


        [ForeignKey("ContestAttempt")]
        public int ContestAttemptId { get; set; }
        public ContestAttempt ContestAttempt { get; set; }
    }
}
