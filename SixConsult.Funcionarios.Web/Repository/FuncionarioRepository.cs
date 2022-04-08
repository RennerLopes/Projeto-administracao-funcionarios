using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SixConsult.Funcionarios.Classes;
using SixConsult.Funcionarios.Interfaces;
using SixConsult.Funcionarios.Web.Data;

namespace SixConsult.Funcionarios.Web.Repository
{
    public class FuncionarioRepository : IRepositorio<FuncionarioModel>
    {
        private readonly FuncionarioContext _context;

        public FuncionarioRepository(FuncionarioContext context)
        {
            _context = context;
        }

        public void Atualiza(int Id, FuncionarioModel entidade)
        {
            _context.Update(entidade);
        }

        public void Insere(FuncionarioModel entidade)
        {
            _context.Add(entidade);
        }

        public async Task<IEnumerable<FuncionarioModel>> Lista()
        {
            return await _context.Funcionarios
            .Include(Funcionario => Funcionario.telefones)
            .ToListAsync();
        }

        public void Remover(FuncionarioModel entidade)
        {
            //_context.Include().Where(_ => _.FuncionarioModelId == entidade.Id);
            //var tt = _context.Funcionarios.OrderBy(e => e.nome).Include(e => e.telefones).First();
            //_context.Telefones.All(_ => _ == entidade.Id);
            _context.Remove(entidade);
        }

        public int ProximoId()
        {
            throw new NotImplementedException();
        }

        public async Task<FuncionarioModel> RetornaPorId(int Id)
        {
            return await _context.Funcionarios
                .Where(_ => _.Id == Id).Include(Funcionario => Funcionario.telefones).FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}