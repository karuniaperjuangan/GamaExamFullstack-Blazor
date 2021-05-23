using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamaExamFullstack.Data
{
    public class DBExamContext : DbContext
    {
        public DBExamContext(DbContextOptions<DBExamContext> options):base(options)
        {

        }

        public DbSet<DCreator> dCreators { get; set; }
        public DbSet<DParticipant> dParticipants { get; set; }
        public DbSet<Question> dQuestions { get; set; }
        public DbSet<Contest> dContests { get; set; }
        public DbSet<ContestAttempt> dContestsAttempt { get; set; }
        public DbSet<QuestionAnswer> QuestionAnswer { get; set; }



        

    }
}
