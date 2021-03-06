﻿// <auto-generated />
using System;
using BlackboardDatabase.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BlackBoard.Migrations
{
    [DbContext(typeof(BlackboardDbContext))]
    [Migration("20190412124029_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BlackBoard.Models.ContentLink", b =>
                {
                    b.Property<int>("ContentLinkId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ContentAreaId");

                    b.Property<string>("Link")
                        .IsRequired();

                    b.Property<string>("Type")
                        .IsRequired();

                    b.HasKey("ContentLinkId");

                    b.HasIndex("ContentAreaId");

                    b.ToTable("ContentLink");
                });

            modelBuilder.Entity("BlackboardDatabase.Models.Assignment", b =>
                {
                    b.Property<int>("AssignmentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Attempt");

                    b.Property<string>("CourseName")
                        .IsRequired();

                    b.Property<int>("Grade");

                    b.Property<DateTime>("HandinDeadline");

                    b.Property<int>("ParticipantsAllowed");

                    b.Property<int>("TeacherAUID");

                    b.HasKey("AssignmentId");

                    b.HasIndex("CourseName");

                    b.HasIndex("TeacherAUID");

                    b.ToTable("Assignments");

                    b.HasData(
                        new
                        {
                            AssignmentId = 111,
                            Attempt = 2,
                            CourseName = "F19-I4SWD",
                            Grade = 7,
                            HandinDeadline = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ParticipantsAllowed = 5,
                            TeacherAUID = 777777
                        },
                        new
                        {
                            AssignmentId = 222,
                            Attempt = 2,
                            CourseName = "F19-I4DAB",
                            Grade = 4,
                            HandinDeadline = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ParticipantsAllowed = 5,
                            TeacherAUID = 999999
                        },
                        new
                        {
                            AssignmentId = 333,
                            Attempt = 5,
                            CourseName = "F19-I4DAB",
                            Grade = 10,
                            HandinDeadline = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ParticipantsAllowed = 10,
                            TeacherAUID = 999999
                        });
                });

            modelBuilder.Entity("BlackboardDatabase.Models.AssignmentStudent", b =>
                {
                    b.Property<int>("StudentAUID");

                    b.Property<int>("AssignmentId");

                    b.HasKey("StudentAUID", "AssignmentId");

                    b.HasIndex("AssignmentId");

                    b.ToTable("AssignmentStudents");

                    b.HasData(
                        new
                        {
                            StudentAUID = 111111,
                            AssignmentId = 111
                        },
                        new
                        {
                            StudentAUID = 111111,
                            AssignmentId = 222
                        },
                        new
                        {
                            StudentAUID = 111111,
                            AssignmentId = 333
                        },
                        new
                        {
                            StudentAUID = 222222,
                            AssignmentId = 111
                        },
                        new
                        {
                            StudentAUID = 222222,
                            AssignmentId = 222
                        },
                        new
                        {
                            StudentAUID = 333333,
                            AssignmentId = 333
                        },
                        new
                        {
                            StudentAUID = 444444,
                            AssignmentId = 333
                        },
                        new
                        {
                            StudentAUID = 444444,
                            AssignmentId = 111
                        });
                });

            modelBuilder.Entity("BlackboardDatabase.Models.ContentArea", b =>
                {
                    b.Property<int>("ContentAreaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseContentId");

                    b.Property<int>("FolderId");

                    b.Property<string>("TextBlock");

                    b.HasKey("ContentAreaId");

                    b.HasIndex("CourseContentId");

                    b.HasIndex("FolderId");

                    b.ToTable("ContentAreas");

                    b.HasData(
                        new
                        {
                            ContentAreaId = 1,
                            CourseContentId = 1,
                            FolderId = 1,
                            TextBlock = "1Random content text (1,1)"
                        },
                        new
                        {
                            ContentAreaId = 2,
                            CourseContentId = 1,
                            FolderId = 1,
                            TextBlock = "2Random content text (1,1)"
                        },
                        new
                        {
                            ContentAreaId = 3,
                            CourseContentId = 1,
                            FolderId = 1,
                            TextBlock = "3Random content text (1,1)"
                        },
                        new
                        {
                            ContentAreaId = 4,
                            CourseContentId = 1,
                            FolderId = 2,
                            TextBlock = "Random content text (1,2)"
                        },
                        new
                        {
                            ContentAreaId = 5,
                            CourseContentId = 1,
                            FolderId = 3,
                            TextBlock = "1Random content text (1,3)"
                        },
                        new
                        {
                            ContentAreaId = 6,
                            CourseContentId = 1,
                            FolderId = 3,
                            TextBlock = "2Random content text (1,3)"
                        },
                        new
                        {
                            ContentAreaId = 7,
                            CourseContentId = 2,
                            FolderId = 4,
                            TextBlock = "Random content text (2,4)"
                        },
                        new
                        {
                            ContentAreaId = 8,
                            CourseContentId = 2,
                            FolderId = 5,
                            TextBlock = "1Random content text (2,5)"
                        },
                        new
                        {
                            ContentAreaId = 9,
                            CourseContentId = 2,
                            FolderId = 6,
                            TextBlock = "2Random content text (2,6)"
                        },
                        new
                        {
                            ContentAreaId = 10,
                            CourseContentId = 3,
                            FolderId = 7,
                            TextBlock = "Random content text (3,7)"
                        },
                        new
                        {
                            ContentAreaId = 11,
                            CourseContentId = 3,
                            FolderId = 8,
                            TextBlock = "1Random content text (3,8)"
                        },
                        new
                        {
                            ContentAreaId = 12,
                            CourseContentId = 3,
                            FolderId = 9,
                            TextBlock = "2Random content text (3,9)"
                        });
                });

            modelBuilder.Entity("BlackboardDatabase.Models.Course", b =>
                {
                    b.Property<string>("CourseName")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CourseContentId");

                    b.HasKey("CourseName");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            CourseName = "F19-I4DAB",
                            CourseContentId = 0
                        },
                        new
                        {
                            CourseName = "F19-I4GUI",
                            CourseContentId = 0
                        },
                        new
                        {
                            CourseName = "F19-I4SWD",
                            CourseContentId = 0
                        });
                });

            modelBuilder.Entity("BlackboardDatabase.Models.CourseContent", b =>
                {
                    b.Property<int>("CourseContentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CourseName")
                        .IsRequired();

                    b.HasKey("CourseContentId");

                    b.HasIndex("CourseName")
                        .IsUnique();

                    b.ToTable("CourseContents");

                    b.HasData(
                        new
                        {
                            CourseContentId = 1,
                            CourseName = "F19-I4DAB"
                        },
                        new
                        {
                            CourseContentId = 2,
                            CourseName = "F19-I4GUI"
                        },
                        new
                        {
                            CourseContentId = 3,
                            CourseName = "F19-I4SWD"
                        });
                });

            modelBuilder.Entity("BlackboardDatabase.Models.CourseStudent", b =>
                {
                    b.Property<string>("CourseName");

                    b.Property<int>("StudentAUID");

                    b.Property<int>("Grade");

                    b.Property<string>("Status")
                        .IsRequired();

                    b.HasKey("CourseName", "StudentAUID");

                    b.HasIndex("StudentAUID");

                    b.ToTable("CourseStudents");

                    b.HasData(
                        new
                        {
                            CourseName = "F19-I4DAB",
                            StudentAUID = 111111,
                            Grade = 0,
                            Status = "Aktiv"
                        },
                        new
                        {
                            CourseName = "F19-I4GUI",
                            StudentAUID = 111111,
                            Grade = 0,
                            Status = "Aktiv"
                        },
                        new
                        {
                            CourseName = "F19-I4SWD",
                            StudentAUID = 111111,
                            Grade = 0,
                            Status = "Aktiv"
                        },
                        new
                        {
                            CourseName = "F19-I4DAB",
                            StudentAUID = 222222,
                            Grade = 0,
                            Status = "Aktiv"
                        },
                        new
                        {
                            CourseName = "F19-I4GUI",
                            StudentAUID = 222222,
                            Grade = 0,
                            Status = "Aktiv"
                        },
                        new
                        {
                            CourseName = "F19-I4SWD",
                            StudentAUID = 222222,
                            Grade = 0,
                            Status = "Aktiv"
                        },
                        new
                        {
                            CourseName = "F19-I4DAB",
                            StudentAUID = 333333,
                            Grade = 0,
                            Status = "Aktiv"
                        },
                        new
                        {
                            CourseName = "F19-I4GUI",
                            StudentAUID = 333333,
                            Grade = 0,
                            Status = "Aktiv"
                        },
                        new
                        {
                            CourseName = "F19-I4SWD",
                            StudentAUID = 333333,
                            Grade = 0,
                            Status = "Aktiv"
                        },
                        new
                        {
                            CourseName = "F19-I4DAB",
                            StudentAUID = 444444,
                            Grade = 0,
                            Status = "Aktiv"
                        },
                        new
                        {
                            CourseName = "F19-I4GUI",
                            StudentAUID = 444444,
                            Grade = 0,
                            Status = "Aktiv"
                        },
                        new
                        {
                            CourseName = "F19-I4SWD",
                            StudentAUID = 444444,
                            Grade = 0,
                            Status = "Aktiv"
                        });
                });

            modelBuilder.Entity("BlackboardDatabase.Models.Folder", b =>
                {
                    b.Property<int>("FolderId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseContentId");

                    b.Property<string>("FolderName")
                        .IsRequired();

                    b.HasKey("FolderId");

                    b.HasIndex("CourseContentId");

                    b.ToTable("Folders");

                    b.HasData(
                        new
                        {
                            FolderId = 1,
                            CourseContentId = 1,
                            FolderName = "Assignments"
                        },
                        new
                        {
                            FolderId = 2,
                            CourseContentId = 1,
                            FolderName = "0 Pre-Course"
                        },
                        new
                        {
                            FolderId = 3,
                            CourseContentId = 1,
                            FolderName = "1.1 Introduction"
                        },
                        new
                        {
                            FolderId = 4,
                            CourseContentId = 2,
                            FolderName = "Introduktion"
                        },
                        new
                        {
                            FolderId = 5,
                            CourseContentId = 2,
                            FolderName = "Lektionsplan"
                        },
                        new
                        {
                            FolderId = 6,
                            CourseContentId = 2,
                            FolderName = "01 Intro and .Net architecture"
                        },
                        new
                        {
                            FolderId = 7,
                            CourseContentId = 3,
                            FolderName = "Week -1   : Optional: Self study of C#"
                        },
                        new
                        {
                            FolderId = 8,
                            CourseContentId = 3,
                            FolderName = "Week 0    : Interfaces(Self-study)"
                        },
                        new
                        {
                            FolderId = 9,
                            CourseContentId = 3,
                            FolderName = "Week 01.1 : Introduction to the course and agile software development"
                        });
                });

            modelBuilder.Entity("BlackboardDatabase.Models.Student", b =>
                {
                    b.Property<int>("AUID");

                    b.Property<DateTime>("BirthDate");

                    b.Property<DateTime>("EnrollmentDate");

                    b.Property<DateTime>("GraduationDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("AUID");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            AUID = 111111,
                            BirthDate = new DateTime(1995, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EnrollmentDate = new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GraduationDate = new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Morten"
                        },
                        new
                        {
                            AUID = 222222,
                            BirthDate = new DateTime(1995, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EnrollmentDate = new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GraduationDate = new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Andreas"
                        },
                        new
                        {
                            AUID = 333333,
                            BirthDate = new DateTime(1996, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EnrollmentDate = new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GraduationDate = new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Troels"
                        },
                        new
                        {
                            AUID = 444444,
                            BirthDate = new DateTime(1997, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EnrollmentDate = new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GraduationDate = new DateTime(2019, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Frederik"
                        });
                });

            modelBuilder.Entity("BlackboardDatabase.Models.Teacher", b =>
                {
                    b.Property<int>("AUID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("AUID");

                    b.ToTable("Teachers");

                    b.HasData(
                        new
                        {
                            AUID = 999999,
                            BirthDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Henrik"
                        },
                        new
                        {
                            AUID = 888888,
                            BirthDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Poul"
                        },
                        new
                        {
                            AUID = 777777,
                            BirthDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Michael"
                        });
                });

            modelBuilder.Entity("BlackboardDatabase.Models.TeacherCourse", b =>
                {
                    b.Property<string>("CourseName");

                    b.Property<int>("TeacherAUID");

                    b.Property<string>("Role")
                        .IsRequired();

                    b.HasKey("CourseName", "TeacherAUID");

                    b.HasIndex("TeacherAUID");

                    b.ToTable("TeacherCourses");

                    b.HasData(
                        new
                        {
                            CourseName = "F19-I4DAB",
                            TeacherAUID = 999999,
                            Role = "Primær"
                        },
                        new
                        {
                            CourseName = "F19-I4GUI",
                            TeacherAUID = 888888,
                            Role = "Primær"
                        },
                        new
                        {
                            CourseName = "F19-I4SWD",
                            TeacherAUID = 999999,
                            Role = "Primær"
                        },
                        new
                        {
                            CourseName = "F19-I4SWD",
                            TeacherAUID = 777777,
                            Role = "Primær"
                        });
                });

            modelBuilder.Entity("BlackBoard.Models.ContentLink", b =>
                {
                    b.HasOne("BlackboardDatabase.Models.ContentArea", "ContentArea")
                        .WithMany("ContentLinks")
                        .HasForeignKey("ContentAreaId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("BlackboardDatabase.Models.Assignment", b =>
                {
                    b.HasOne("BlackboardDatabase.Models.Course", "Course")
                        .WithMany("Assignments")
                        .HasForeignKey("CourseName")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BlackboardDatabase.Models.Teacher", "Teacher")
                        .WithMany("Assignments")
                        .HasForeignKey("TeacherAUID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("BlackboardDatabase.Models.AssignmentStudent", b =>
                {
                    b.HasOne("BlackboardDatabase.Models.Assignment", "Assignment")
                        .WithMany("AssignmentStudents")
                        .HasForeignKey("AssignmentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BlackboardDatabase.Models.Student", "Student")
                        .WithMany("AssignmentStudents")
                        .HasForeignKey("StudentAUID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("BlackboardDatabase.Models.ContentArea", b =>
                {
                    b.HasOne("BlackboardDatabase.Models.CourseContent", "CourseContent")
                        .WithMany("ContentAreas")
                        .HasForeignKey("CourseContentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BlackboardDatabase.Models.Folder", "Folder")
                        .WithMany("ContentAreas")
                        .HasForeignKey("FolderId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("BlackboardDatabase.Models.CourseContent", b =>
                {
                    b.HasOne("BlackboardDatabase.Models.Course", "Course")
                        .WithOne("CourseContent")
                        .HasForeignKey("BlackboardDatabase.Models.CourseContent", "CourseName")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("BlackboardDatabase.Models.CourseStudent", b =>
                {
                    b.HasOne("BlackboardDatabase.Models.Course", "Course")
                        .WithMany("CourseStudents")
                        .HasForeignKey("CourseName")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BlackboardDatabase.Models.Student", "Student")
                        .WithMany("CourseStudents")
                        .HasForeignKey("StudentAUID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("BlackboardDatabase.Models.Folder", b =>
                {
                    b.HasOne("BlackboardDatabase.Models.CourseContent", "CourseContent")
                        .WithMany("Folders")
                        .HasForeignKey("CourseContentId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("BlackboardDatabase.Models.TeacherCourse", b =>
                {
                    b.HasOne("BlackboardDatabase.Models.Course", "Course")
                        .WithMany("TeacherCourses")
                        .HasForeignKey("CourseName")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BlackboardDatabase.Models.Teacher", "Teacher")
                        .WithMany("TeacherCourses")
                        .HasForeignKey("TeacherAUID")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
