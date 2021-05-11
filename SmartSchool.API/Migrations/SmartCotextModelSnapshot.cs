﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartSchool.API.Data;

namespace SmartSchool.API.Migrations
{
    [DbContext(typeof(SmartCotext))]
    partial class SmartCotextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0");

            modelBuilder.Entity("SmartSchool.API.Models.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Ativo")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataIni")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataNasc")
                        .HasColumnType("TEXT");

                    b.Property<int>("Matricula")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Alunos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ativo = true,
                            DataIni = new DateTime(2021, 5, 10, 20, 57, 17, 973, DateTimeKind.Local).AddTicks(8786),
                            DataNasc = new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Matricula = 1,
                            Nome = "Marta",
                            Sobrenome = "Kent",
                            Telefone = "33225555"
                        },
                        new
                        {
                            Id = 2,
                            Ativo = true,
                            DataIni = new DateTime(2021, 5, 10, 20, 57, 17, 974, DateTimeKind.Local).AddTicks(2811),
                            DataNasc = new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Matricula = 2,
                            Nome = "Paula",
                            Sobrenome = "Isabela",
                            Telefone = "3354288"
                        },
                        new
                        {
                            Id = 3,
                            Ativo = true,
                            DataIni = new DateTime(2021, 5, 10, 20, 57, 17, 974, DateTimeKind.Local).AddTicks(2874),
                            DataNasc = new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Matricula = 3,
                            Nome = "Laura",
                            Sobrenome = "Antonia",
                            Telefone = "55668899"
                        },
                        new
                        {
                            Id = 4,
                            Ativo = true,
                            DataIni = new DateTime(2021, 5, 10, 20, 57, 17, 974, DateTimeKind.Local).AddTicks(2953),
                            DataNasc = new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Matricula = 4,
                            Nome = "Luiza",
                            Sobrenome = "Maria",
                            Telefone = "6565659"
                        },
                        new
                        {
                            Id = 5,
                            Ativo = true,
                            DataIni = new DateTime(2021, 5, 10, 20, 57, 17, 974, DateTimeKind.Local).AddTicks(2959),
                            DataNasc = new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Matricula = 5,
                            Nome = "Lucas",
                            Sobrenome = "Machado",
                            Telefone = "565685415"
                        },
                        new
                        {
                            Id = 6,
                            Ativo = true,
                            DataIni = new DateTime(2021, 5, 10, 20, 57, 17, 974, DateTimeKind.Local).AddTicks(2968),
                            DataNasc = new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Matricula = 6,
                            Nome = "Pedro",
                            Sobrenome = "Alvares",
                            Telefone = "456454545"
                        },
                        new
                        {
                            Id = 7,
                            Ativo = true,
                            DataIni = new DateTime(2021, 5, 10, 20, 57, 17, 974, DateTimeKind.Local).AddTicks(2976),
                            DataNasc = new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Matricula = 7,
                            Nome = "Paulo",
                            Sobrenome = "José",
                            Telefone = "9874512"
                        });
                });

            modelBuilder.Entity("SmartSchool.API.Models.AlunoCurso", b =>
                {
                    b.Property<int>("AlunoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CursoId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataIni")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Nota")
                        .HasColumnType("INTEGER");

                    b.HasKey("AlunoId", "CursoId");

                    b.HasIndex("CursoId");

                    b.ToTable("AlunosCursos");
                });

            modelBuilder.Entity("SmartSchool.API.Models.AlunoDisciplina", b =>
                {
                    b.Property<int>("AlunoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DisciplinaID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataIni")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Nota")
                        .HasColumnType("INTEGER");

                    b.HasKey("AlunoId", "DisciplinaID");

                    b.HasIndex("DisciplinaID");

                    b.ToTable("AlunosDisciplinas");

                    b.HasData(
                        new
                        {
                            AlunoId = 1,
                            DisciplinaID = 2,
                            DataIni = new DateTime(2021, 5, 10, 20, 57, 17, 974, DateTimeKind.Local).AddTicks(5449)
                        },
                        new
                        {
                            AlunoId = 1,
                            DisciplinaID = 4,
                            DataIni = new DateTime(2021, 5, 10, 20, 57, 17, 974, DateTimeKind.Local).AddTicks(6891)
                        },
                        new
                        {
                            AlunoId = 1,
                            DisciplinaID = 5,
                            DataIni = new DateTime(2021, 5, 10, 20, 57, 17, 974, DateTimeKind.Local).AddTicks(6941)
                        },
                        new
                        {
                            AlunoId = 2,
                            DisciplinaID = 1,
                            DataIni = new DateTime(2021, 5, 10, 20, 57, 17, 974, DateTimeKind.Local).AddTicks(6944)
                        },
                        new
                        {
                            AlunoId = 2,
                            DisciplinaID = 2,
                            DataIni = new DateTime(2021, 5, 10, 20, 57, 17, 974, DateTimeKind.Local).AddTicks(6945)
                        },
                        new
                        {
                            AlunoId = 2,
                            DisciplinaID = 5,
                            DataIni = new DateTime(2021, 5, 10, 20, 57, 17, 974, DateTimeKind.Local).AddTicks(6951)
                        },
                        new
                        {
                            AlunoId = 3,
                            DisciplinaID = 1,
                            DataIni = new DateTime(2021, 5, 10, 20, 57, 17, 974, DateTimeKind.Local).AddTicks(6952)
                        },
                        new
                        {
                            AlunoId = 3,
                            DisciplinaID = 2,
                            DataIni = new DateTime(2021, 5, 10, 20, 57, 17, 974, DateTimeKind.Local).AddTicks(6954)
                        },
                        new
                        {
                            AlunoId = 3,
                            DisciplinaID = 3,
                            DataIni = new DateTime(2021, 5, 10, 20, 57, 17, 974, DateTimeKind.Local).AddTicks(6955)
                        },
                        new
                        {
                            AlunoId = 4,
                            DisciplinaID = 1,
                            DataIni = new DateTime(2021, 5, 10, 20, 57, 17, 974, DateTimeKind.Local).AddTicks(6959)
                        },
                        new
                        {
                            AlunoId = 4,
                            DisciplinaID = 4,
                            DataIni = new DateTime(2021, 5, 10, 20, 57, 17, 974, DateTimeKind.Local).AddTicks(6961)
                        },
                        new
                        {
                            AlunoId = 4,
                            DisciplinaID = 5,
                            DataIni = new DateTime(2021, 5, 10, 20, 57, 17, 974, DateTimeKind.Local).AddTicks(6963)
                        },
                        new
                        {
                            AlunoId = 5,
                            DisciplinaID = 4,
                            DataIni = new DateTime(2021, 5, 10, 20, 57, 17, 974, DateTimeKind.Local).AddTicks(6965)
                        },
                        new
                        {
                            AlunoId = 5,
                            DisciplinaID = 5,
                            DataIni = new DateTime(2021, 5, 10, 20, 57, 17, 974, DateTimeKind.Local).AddTicks(6967)
                        },
                        new
                        {
                            AlunoId = 6,
                            DisciplinaID = 1,
                            DataIni = new DateTime(2021, 5, 10, 20, 57, 17, 974, DateTimeKind.Local).AddTicks(6969)
                        },
                        new
                        {
                            AlunoId = 6,
                            DisciplinaID = 2,
                            DataIni = new DateTime(2021, 5, 10, 20, 57, 17, 974, DateTimeKind.Local).AddTicks(6971)
                        },
                        new
                        {
                            AlunoId = 6,
                            DisciplinaID = 3,
                            DataIni = new DateTime(2021, 5, 10, 20, 57, 17, 974, DateTimeKind.Local).AddTicks(6973)
                        },
                        new
                        {
                            AlunoId = 6,
                            DisciplinaID = 4,
                            DataIni = new DateTime(2021, 5, 10, 20, 57, 17, 974, DateTimeKind.Local).AddTicks(6977)
                        },
                        new
                        {
                            AlunoId = 7,
                            DisciplinaID = 1,
                            DataIni = new DateTime(2021, 5, 10, 20, 57, 17, 974, DateTimeKind.Local).AddTicks(6978)
                        },
                        new
                        {
                            AlunoId = 7,
                            DisciplinaID = 2,
                            DataIni = new DateTime(2021, 5, 10, 20, 57, 17, 974, DateTimeKind.Local).AddTicks(6980)
                        },
                        new
                        {
                            AlunoId = 7,
                            DisciplinaID = 3,
                            DataIni = new DateTime(2021, 5, 10, 20, 57, 17, 974, DateTimeKind.Local).AddTicks(6982)
                        },
                        new
                        {
                            AlunoId = 7,
                            DisciplinaID = 4,
                            DataIni = new DateTime(2021, 5, 10, 20, 57, 17, 974, DateTimeKind.Local).AddTicks(6983)
                        },
                        new
                        {
                            AlunoId = 7,
                            DisciplinaID = 5,
                            DataIni = new DateTime(2021, 5, 10, 20, 57, 17, 974, DateTimeKind.Local).AddTicks(6985)
                        });
                });

            modelBuilder.Entity("SmartSchool.API.Models.Curso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Cursos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Tecnologia da Informação"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Sistemas de Informação"
                        },
                        new
                        {
                            Id = 3,
                            Nome = "Ciência da Computação"
                        });
                });

            modelBuilder.Entity("SmartSchool.API.Models.Disciplina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CargaHoraria")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CursoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PrerequisitoId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PrerequistoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProfessorId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CursoId");

                    b.HasIndex("PrerequisitoId");

                    b.HasIndex("ProfessorId");

                    b.ToTable("Disciplinas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CargaHoraria = 0,
                            CursoId = 1,
                            Nome = "Matemática",
                            ProfessorId = 1
                        },
                        new
                        {
                            Id = 2,
                            CargaHoraria = 0,
                            CursoId = 3,
                            Nome = "Matemática",
                            ProfessorId = 1
                        },
                        new
                        {
                            Id = 3,
                            CargaHoraria = 0,
                            CursoId = 3,
                            Nome = "Física",
                            ProfessorId = 2
                        },
                        new
                        {
                            Id = 4,
                            CargaHoraria = 0,
                            CursoId = 1,
                            Nome = "Português",
                            ProfessorId = 3
                        },
                        new
                        {
                            Id = 5,
                            CargaHoraria = 0,
                            CursoId = 1,
                            Nome = "Inglês",
                            ProfessorId = 4
                        },
                        new
                        {
                            Id = 6,
                            CargaHoraria = 0,
                            CursoId = 2,
                            Nome = "Inglês",
                            ProfessorId = 4
                        },
                        new
                        {
                            Id = 7,
                            CargaHoraria = 0,
                            CursoId = 3,
                            Nome = "Inglês",
                            ProfessorId = 4
                        },
                        new
                        {
                            Id = 8,
                            CargaHoraria = 0,
                            CursoId = 1,
                            Nome = "Programação",
                            ProfessorId = 5
                        },
                        new
                        {
                            Id = 9,
                            CargaHoraria = 0,
                            CursoId = 2,
                            Nome = "Programação",
                            ProfessorId = 5
                        },
                        new
                        {
                            Id = 10,
                            CargaHoraria = 0,
                            CursoId = 3,
                            Nome = "Programação",
                            ProfessorId = 5
                        });
                });

            modelBuilder.Entity("SmartSchool.API.Models.Professor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Ativo")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataIni")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<int>("Registro")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Professores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ativo = true,
                            DataIni = new DateTime(2021, 5, 10, 20, 57, 17, 963, DateTimeKind.Local).AddTicks(3659),
                            Nome = "Lauro",
                            Registro = 1,
                            Sobrenome = "Oliveira"
                        },
                        new
                        {
                            Id = 2,
                            Ativo = true,
                            DataIni = new DateTime(2021, 5, 10, 20, 57, 17, 965, DateTimeKind.Local).AddTicks(4800),
                            Nome = "Roberto",
                            Registro = 2,
                            Sobrenome = "Soares"
                        },
                        new
                        {
                            Id = 3,
                            Ativo = true,
                            DataIni = new DateTime(2021, 5, 10, 20, 57, 17, 965, DateTimeKind.Local).AddTicks(4919),
                            Nome = "Ronaldo",
                            Registro = 3,
                            Sobrenome = "Marconi"
                        },
                        new
                        {
                            Id = 4,
                            Ativo = true,
                            DataIni = new DateTime(2021, 5, 10, 20, 57, 17, 965, DateTimeKind.Local).AddTicks(4926),
                            Nome = "Rodrigo",
                            Registro = 4,
                            Sobrenome = "Carvalho"
                        },
                        new
                        {
                            Id = 5,
                            Ativo = true,
                            DataIni = new DateTime(2021, 5, 10, 20, 57, 17, 965, DateTimeKind.Local).AddTicks(4931),
                            Nome = "Alexandre",
                            Registro = 5,
                            Sobrenome = "Montanha"
                        });
                });

            modelBuilder.Entity("SmartSchool.API.Models.AlunoCurso", b =>
                {
                    b.HasOne("SmartSchool.API.Models.Aluno", "Aluno")
                        .WithMany()
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartSchool.API.Models.Curso", "Curso")
                        .WithMany()
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SmartSchool.API.Models.AlunoDisciplina", b =>
                {
                    b.HasOne("SmartSchool.API.Models.Aluno", "Aluno")
                        .WithMany("AlunosDisciplinas")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartSchool.API.Models.Disciplina", "Disciplina")
                        .WithMany("AlunosDisciplinas")
                        .HasForeignKey("DisciplinaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SmartSchool.API.Models.Disciplina", b =>
                {
                    b.HasOne("SmartSchool.API.Models.Curso", "Curso")
                        .WithMany("Disciplinas")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartSchool.API.Models.Disciplina", "Prerequisito")
                        .WithMany()
                        .HasForeignKey("PrerequisitoId");

                    b.HasOne("SmartSchool.API.Models.Professor", "Professor")
                        .WithMany("Disciplinas")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
