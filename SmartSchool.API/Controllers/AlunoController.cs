using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        public List<Aluno> Alunos = new List<Aluno>()
        {
            new Aluno()
            {
                Id = 1,
                Nome = "Marcus",
                Telefone = "31293819234"
            },
             new Aluno()
            {
                Id = 2,
                Nome = "Ana",
                Telefone = "545423424"
            },
               new Aluno()
            {
                Id = 3,
                Nome = "Marta",
                Telefone = "43423423432"
            }
        };
        public AlunoController() { }

        // GET: api/<AlunoController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Alunos);
        }

        // GET api/<AlunoController>/5
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = Alunos.FirstOrDefault(x => x.Id == id);
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
            var aluno = Alunos.FirstOrDefault(x => x.Nome == nome && x.Sobrenome == sobrenome);
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
            return Ok(aluno);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id , Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }

     
    
    }
}
