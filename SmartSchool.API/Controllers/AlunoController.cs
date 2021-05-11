using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Data;
using SmartSchool.API.Dtos;
using SmartSchool.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public AlunoController( IRepository repository, IMapper mapper) {
         
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/<AlunoController>
        [HttpGet]
        public IActionResult Get()
        {
            var alunos = _repository.GetAllAlunos(true);  
            return Ok(_mapper.Map<IEnumerable<AlunoDto>>(alunos));
        }

        // GET api/<AlunoController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _repository.GetAlunoById(id);
            if (aluno != null)
            {
                var alunoDto = _mapper.Map<AlunoDto>(aluno);
                return Ok(alunoDto);
            }
            else
            {
                return BadRequest("Aluno não encontrado");
            }
        }

        //[HttpGet("ByName")]
        //public IActionResult GetByName(string nome, string sobrenome)
        //{
        //    var aluno =  _repository..FirstOrDefault(x => x.Nome == nome && x.Sobrenome == sobrenome);
        //    if (aluno != null)
        //    {
        //        return Ok(aluno);
        //    }
        //    else
        //    {
        //        return BadRequest("Aluno não encontrado");
        //    }
        //}

        [HttpPost]
        public IActionResult Post(AlunoRegistrarDto model)
        {
            var aluno = _mapper.Map<Aluno>(model);
            _repository.Add(aluno);

           if( _repository.SaveChanges())
            return Created($"/api/aluno/{model.Id}", _mapper.Map<AlunoDto>(aluno));
            else
            {
                return BadRequest("Aluno não cadastrado");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id , AlunoRegistrarDto model)
        {
            var aluno = _repository.GetAlunoById(id);
            if (aluno == null)
            {
                return BadRequest("Aluno não encontrado");
            }

            _mapper.Map(model, aluno);

            _repository.Update(aluno);
            if (_repository.SaveChanges())
                 return Created($"/api/aluno/{model.Id}", _mapper.Map<AlunoDto>(aluno));
            else
            {
                return BadRequest("Aluno não atualizado");
            }
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, AlunoRegistrarDto model)
        {
            var aluno = _repository.GetAlunoById(id);
            if (aluno == null)
            {
                return BadRequest("Aluno não encontrado");
            }
            _mapper.Map(model, aluno);
            _repository.Update(aluno);
            if (_repository.SaveChanges())
               return Created($"/api/aluno/{model.Id}", _mapper.Map<AlunoDto>(aluno));
            else
            {
                return BadRequest("Aluno não atualizado");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
             var aluno = _repository.GetAlunoById(id);
            if (aluno == null)
            {
                return BadRequest("Aluno não encontrado");
            }
            _repository.Delete(aluno);
            if (_repository.SaveChanges())
                return Ok(aluno);
            else
            {
                return BadRequest("Aluno não deletado");
            }
        }

     
    
    }
}
