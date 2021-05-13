using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Helpers;
using SmartSchool.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.Data
{
    public class Repository : IRepository
    {
        private readonly SmartCotext _context;
       

        public Repository(SmartCotext context)
        {
            _context = context;
           
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
          
           
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public Aluno GetAlunoById(int id,bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;
            if (includeProfessor)
            {
                query = query.Include(a => a.AlunosDisciplinas).ThenInclude(x => x.Disciplina).ThenInclude(p => p.Professor);
            }
            query = query.AsNoTracking().OrderBy(x => x.Id).Where(aluno => aluno.Id == id);
            return query.FirstOrDefault();
        }

        public Aluno[] GetAllAlunos(bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;
            if (includeProfessor)
            {
                query = query.Include(a => a.AlunosDisciplinas).ThenInclude(x => x.Disciplina).ThenInclude(p => p.Professor);
            }
            query = query.AsNoTracking().OrderBy(x => x.Id);
            return query.ToArray();
        }

        public async Task<PageList<Aluno>> GetAllAlunosAsync(
            PageParams pageParams,
            bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;
            if (includeProfessor)
            {
                query = query.Include(a => a.AlunosDisciplinas)
                    .ThenInclude(x => x.Disciplina)
                    .ThenInclude(p => p.Professor);
            }
            query = query.AsNoTracking().OrderBy(x => x.Id);

            if (!string.IsNullOrEmpty(pageParams.Nome))
            {
                query = query.Where(aluno =>( aluno.Nome.ToUpper().Contains(pageParams.Nome.ToUpper()))
                                   ||( aluno.Sobrenome.ToUpper().Contains(pageParams.Nome.ToUpper())));
            }
            if(pageParams.Matricula > 0)
            {
                query = query.Where(aluno => aluno.Matricula == pageParams.Matricula);
            }
            if (pageParams.Ativo != null)
            {
                query = query.Where(aluno => aluno.Ativo == (pageParams.Ativo != 0));
            }

            return await PageList<Aluno>.CreateAsync(query,pageParams.PageNumber,pageParams.PageSize);
            //return await query.ToListAsync();
        }

        public Aluno[] GetAllAlunosByDisciplinaId(int id, bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;
            if (includeProfessor)
            {
                query = query.Include(a => a.AlunosDisciplinas).ThenInclude(x => x.Disciplina).ThenInclude(p => p.Professor);
            }
            query = query.AsNoTracking().OrderBy(x => x.Id).Where(x=> x.AlunosDisciplinas.Any(ad => ad.DisciplinaID == id));
            return query.ToArray();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public Professor[] GetAllProfessores(bool includeAlunos)
        {

            IQueryable<Professor> query = _context.Professores;
            if (includeAlunos)
            {
                query = query.Include(a => a.Disciplinas).ThenInclude(x => x.AlunosDisciplinas).ThenInclude(p => p.Aluno);
            }
            query = query.AsNoTracking().OrderBy(x => x.Id);
            return query.ToArray();
        }

        public Professor[] GetAllProfessoresByDisciplinaId(int id, bool includeAlunos = false)
        {
            IQueryable<Professor> query = _context.Professores;
            if (includeAlunos)
            {
                query = query.Include(a => a.Disciplinas).ThenInclude(x => x.AlunosDisciplinas).ThenInclude(p => p.Aluno);
            }
            query = query.AsNoTracking().OrderBy(aluno => aluno.Id).Where(aluno => aluno.Disciplinas.Any(ad => ad.AlunosDisciplinas.Any( q => q.DisciplinaID == id)));
            return query.ToArray();

        }

        public Professor GetProfessorById(int id, bool includeAlunos = false)
        {
            IQueryable<Professor> query = _context.Professores;
            if (includeAlunos)
            {
                query = query.Include(a => a.Disciplinas).ThenInclude(x => x.AlunosDisciplinas).ThenInclude(p => p.Aluno);
            }
            query = query.AsNoTracking().OrderBy(x => x.Id).Where(professor => professor.Id == id);
            return query.FirstOrDefault();
        }
    }
}

