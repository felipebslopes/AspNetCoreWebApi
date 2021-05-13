﻿using AutoMapper;
using SmartSchool.API.Helpers;
using SmartSchool.API.Models;
using SmartSchool.API.V1.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.V1.Profiles
{
    public class SmartSchoolProfile : Profile
    {
        public SmartSchoolProfile()
        {
            CreateMap<Aluno, AlunoDto>()
                .ForMember(
                dest => dest.Nome, opt=>
                opt.MapFrom(src => $"{src.Nome} {src.Sobrenome}")
                )
                .ForMember( 
                    dest => dest.Idade,
                    opt => opt.MapFrom(src => src.DataNasc.GetCurrentAge())
                    ) ;

            CreateMap<Professor, ProfessorDto>()
              .ForMember(
              dest => dest.Nome, opt =>
              opt.MapFrom(src => $"{src.Nome} {src.Sobrenome}")
              );

            
            CreateMap<AlunoDto, Aluno>();
            CreateMap<ProfessorDto, Professor>();
            CreateMap<Aluno, AlunoRegistrarDto>().ReverseMap();
            CreateMap<Professor, ProfessorRegistrarDto>().ReverseMap();
        }
    }
}
