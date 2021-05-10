using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Data;
using SmartSchool.API.Models;

namespace SmartSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {

        private readonly SmartCotext _context;
        private readonly IRepository _repository;
        public ProfessorController(SmartCotext context, IRepository repository)
        {
            this._context = context;
            _repository = repository;
        }

        // GET: api/<AlunoController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repository.GetAllProfessores());
        }

        // GET api/<AlunoController>/5
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var professor = _repository.GetProfessorById(id);
            if (professor != null)
            {
                return Ok(professor);
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
        public IActionResult Post(Professor professor)
        {
            _repository.Add(professor);
            if (_repository.SaveChanges())
                return Ok(professor);
            else
            {
                return BadRequest("Professor não cadastrado");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var prof = _repository.GetProfessorById(id);
            if (prof == null)
            {
                return BadRequest("Professor não encontrado");
            }

            _repository.Update(professor);
            if (_repository.SaveChanges())
            {
                return Ok(professor);
            }
            return BadRequest("Professor não atualizado");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var prof = _repository.GetProfessorById(id);
            if (prof == null)
            {
                return BadRequest("Professor não encontrado");
            }

            _repository.Update(professor);
            if (_repository.SaveChanges())
            {
                return Ok(professor);
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
