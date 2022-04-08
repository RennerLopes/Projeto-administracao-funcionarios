using System.Collections.Generic;
using System.Threading.Tasks;
using SixConsult.Funcionarios.Classes;

namespace SixConsult.Funcionarios.Interfaces
{
    public interface IRepositorio<T>
    {
        Task<IEnumerable<T>> Lista();
        //List<T> Lista();
        Task<T> RetornaPorId(int Id);
        void Insere(T entidade);
        void Remover(T entidade);
        void Atualiza(int Id, T entidade);
        int ProximoId();

        Task<bool> SaveChangesAsync();
    }
}