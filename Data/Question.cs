using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamaExamFullstack.Data
{
    public class Question
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        public string QuestionText { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string Answers_A { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string Answers_B { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string Answers_C { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string Answers_D { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string Answers_E { get; set; }

        [Column(TypeName = "nvarchar(300)")]
        public string? imageURL { get; set; }

        [Column(TypeName = "char(1)")]
        public char TrueAnswer { get; set; }
        
        [ForeignKey("Contest")]
        public int ContestId { get; set; }
        public Contest Contest { get; set; }
    }
}
