using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GamaExamFullstack.Data
{
    public class ContestAttempt
    {
        [Key]
        public int Id { get; set; }

        public ICollection<QuestionAnswer> AnswerCollection { get; set; }

        [Column(TypeName = "int")]
        public int RightAnswer { get; set; }

        [Column(TypeName = "float(24)")]
        public float score { get; set; }

        [ForeignKey("Contest")]
        public int ContestId { get; set; }
        public Contest Contest { get; set; }

        [ForeignKey("DParticipant")]
        public int ParticipantId { get; set; }
        public DParticipant Participant { get; set; }
    }
}
