﻿// <auto-generated />
using GamaExamFullstack.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GamaExamFullstack.Migrations
{
    [DbContext(typeof(DBExamContext))]
    [Migration("20210524152106_Web Migration")]
    partial class WebMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GamaExamFullstack.Data.Contest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreatorId")
                        .HasColumnType("int");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int>("NumOfQuestion")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.ToTable("dContests");
                });

            modelBuilder.Entity("GamaExamFullstack.Data.ContestAttempt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ContestId")
                        .HasColumnType("int");

                    b.Property<int>("ParticipantId")
                        .HasColumnType("int");

                    b.Property<int>("RightAnswer")
                        .HasColumnType("int");

                    b.Property<float>("score")
                        .HasColumnType("float(24)");

                    b.HasKey("Id");

                    b.HasIndex("ContestId");

                    b.HasIndex("ParticipantId");

                    b.ToTable("dContestsAttempt");
                });

            modelBuilder.Entity("GamaExamFullstack.Data.DCreator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("institute")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("username")
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("dCreators");
                });

            modelBuilder.Entity("GamaExamFullstack.Data.DParticipant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("institute")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("username")
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("dParticipants");
                });

            modelBuilder.Entity("GamaExamFullstack.Data.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Answers_A")
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Answers_B")
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Answers_C")
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Answers_D")
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Answers_E")
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("ContestId")
                        .HasColumnType("int");

                    b.Property<int>("QuestionNumber")
                        .HasColumnType("int");

                    b.Property<string>("QuestionText")
                        .HasColumnType("nvarchar(400)");

                    b.Property<string>("TrueAnswer")
                        .IsRequired()
                        .HasColumnType("char(1)");

                    b.HasKey("Id");

                    b.HasIndex("ContestId");

                    b.ToTable("dQuestions");
                });

            modelBuilder.Entity("GamaExamFullstack.Data.QuestionAnswer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("char(1)");

                    b.Property<int>("ContestAttemptId")
                        .HasColumnType("int");

                    b.Property<int>("QuestionNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ContestAttemptId");

                    b.ToTable("QuestionAnswer");
                });

            modelBuilder.Entity("GamaExamFullstack.Data.Contest", b =>
                {
                    b.HasOne("GamaExamFullstack.Data.DCreator", "Creator")
                        .WithMany("CreatedContest")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("GamaExamFullstack.Data.ContestAttempt", b =>
                {
                    b.HasOne("GamaExamFullstack.Data.Contest", "Contest")
                        .WithMany()
                        .HasForeignKey("ContestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GamaExamFullstack.Data.DParticipant", "Participant")
                        .WithMany()
                        .HasForeignKey("ParticipantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contest");

                    b.Navigation("Participant");
                });

            modelBuilder.Entity("GamaExamFullstack.Data.Question", b =>
                {
                    b.HasOne("GamaExamFullstack.Data.Contest", "Contest")
                        .WithMany("Questions")
                        .HasForeignKey("ContestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contest");
                });

            modelBuilder.Entity("GamaExamFullstack.Data.QuestionAnswer", b =>
                {
                    b.HasOne("GamaExamFullstack.Data.ContestAttempt", "ContestAttempt")
                        .WithMany("AnswerCollection")
                        .HasForeignKey("ContestAttemptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContestAttempt");
                });

            modelBuilder.Entity("GamaExamFullstack.Data.Contest", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("GamaExamFullstack.Data.ContestAttempt", b =>
                {
                    b.Navigation("AnswerCollection");
                });

            modelBuilder.Entity("GamaExamFullstack.Data.DCreator", b =>
                {
                    b.Navigation("CreatedContest");
                });
#pragma warning restore 612, 618
        }
    }
}
