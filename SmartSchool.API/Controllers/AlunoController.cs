using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Data;
using SmartSchool.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly SmartCotext _context;

        public AlunoController(SmartCotext context) {
            this._context = context;
        }

        // GET: api/<AlunoController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Alunos);
        }

        // GET api/<AlunoController>/5
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(x => x.Id == id);
            if (aluno != null)
            {
                return Ok(aluno);
            }
            else
            {
                return BadRequest("Aluno não encontrado");
            }
        }

        [HttpGet("ByName")]
        public IActionResult GetByName(string nome, string sobrenome)
        {
            var aluno = _context.Alunos.FirstOrDefault(x => x.Nome == nome && x.Sobrenome == sobrenome);
            if (aluno != null)
            {
                return Ok(aluno);
            }
            else
            {
                return BadRequest("Aluno não encontrado");
            }
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _context.Add(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id , Aluno aluno)
        {
            var alu = _context.Alunos.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (alu == null)
            {
                return BadRequest("Aluno não encontrado");
            }
           
            _context.Update(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var alu = _context.Alunos.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (alu == null)
            {
                return BadRequest("Aluno não encontrado");
            }
            _context.Update(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
             var aluno = _context.Alunos.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if(aluno == null)
            {
                return BadRequest("Aluno não encontrado");
            }
            _context.Remove(aluno);
            _context.SaveChanges();
            return Ok();
        }

     
    
    }
}
