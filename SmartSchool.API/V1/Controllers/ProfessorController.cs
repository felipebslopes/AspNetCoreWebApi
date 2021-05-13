using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Data;

using SmartSchool.API.Models;
using SmartSchool.API.V1.Dtos;

namespace SmartSchool.API.V1.Controllers
{
    [Route("api/v{verson:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IRepository _repository;
        public ProfessorController(IRepository repository, IMapper mapper)
        {
          
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/<AlunoController>
        [HttpGet]
        public IActionResult Get()
        {
            var professores = _repository.GetAllProfessores();
            return Ok(_mapper.Map<IEnumerable<ProfessorDto>>(professores));
        }

        // GET api/<AlunoController>/5
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var professor = _repository.GetProfessorById(id);
            if (professor != null)
            {
                var professorDto = _mapper.Map<ProfessorDto>(professor);
                return Ok(professorDto);
            }
            else
            {
                return BadRequest("Aluno não encontrado");
            }
        }

        //[HttpGet("ByName")]
        //public IActionResult GetByName(string nome)
        //{
        //    var professor = _context.Professores.FirstOrDefault(x => x.Nome == nome);
        //    if (professor != null)
        //    {
        //        return Ok(professor);
        //    }
        //    else
        //    {
        //        return BadRequest("Aluno não encontrado");
        //    }
        //}

        [HttpPost]
        public IActionResult Post(ProfessorRegistrarDto model)
        {
            var professor = _mapper.Map<Professor>(model);
            _repository.Add(professor);
            if (_repository.SaveChanges())
                return Created($"/api/professor/{model.Id}", _mapper.Map<ProfessorDto>(professor));
            else
            {
                return BadRequest("Professor não cadastrado");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, ProfessorRegistrarDto model)
        {
            var professor = _repository.GetProfessorById(id);
            if (professor == null)
            {
                return BadRequest("Professor não encontrado");
            }
            _mapper.Map(model, professor);
            _repository.Update(professor);
            if (_repository.SaveChanges())
            {
                return Created($"/api/professor/{model.Id}", _mapper.Map<ProfessorDto>(professor));
            }
            return BadRequest("Professor não atualizado");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, ProfessorRegistrarDto model)
        {
            var professor = _repository.GetProfessorById(id);
            if (professor == null)
            {
                return BadRequest("Professor não encontrado");
            }
            _mapper.Map(model, professor);
            _repository.Update(professor);
            if (_repository.SaveChanges())
            {
                return Created($"/api/professor/{model.Id}", _mapper.Map<ProfessorDto>(professor));
            }
            return BadRequest("Professor não atualizado");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var prof = _repository.GetProfessorById(id);
            if (prof == null)
            {
                return BadRequest("Professor não encontrado");
            }
            _repository.Delete(prof);
            if (_repository.SaveChanges())
            {
                return Ok("Professor deletado");
            }
            return BadRequest("Professor não deletado");
        }
    }
}
