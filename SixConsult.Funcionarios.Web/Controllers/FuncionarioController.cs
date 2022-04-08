using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SixConsult.Funcionarios.Interfaces;
using SixConsult.Funcionarios.Classes;
using System.Security.Policy;
using System.Security.Cryptography;

namespace SixConsult.Funcionarios.Web.Controllers
{
    [Route("[controller]")]
    public class FuncionarioController : Controller
    {
        private readonly IRepositorio<FuncionarioModel> _repositorioFuncionario;

        public FuncionarioController(IRepositorio<FuncionarioModel> repositorioFuncionario)
        {
            _repositorioFuncionario = repositorioFuncionario;
        }

        [HttpGet("")]
        public async Task<IActionResult> Lista()
        {
            var funcionarios = await _repositorioFuncionario.Lista();
            return funcionarios.Any()
                ? Ok(funcionarios)
                : NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualiza(int id, [FromBody] FuncionarioModel model)
        {
            var hash = new Hash(SHA512.Create());
            var funcionarioBanco = await _repositorioFuncionario.RetornaPorId(id);
            if (funcionarioBanco == null) return NotFound("Funcionário não encontrado");

            funcionarioBanco.nome = model.nome ?? funcionarioBanco.nome;
            funcionarioBanco.sobrenome = model.sobrenome ?? funcionarioBanco.sobrenome;
            funcionarioBanco.email = model.email ?? funcionarioBanco.nome;
            funcionarioBanco.telefones = model.telefones ?? funcionarioBanco.telefones;
            funcionarioBanco.senha = hash.CriptografarSenha(model.senha) ?? funcionarioBanco.senha;
            return await _repositorioFuncionario.SaveChangesAsync()
                ? Ok("Usuário atualizado com sucesso")
                : BadRequest("Erro ao atualizar usuário");
        }

        [HttpPost("")]
        public async Task<IActionResult> Insere([FromBody] FuncionarioModel model)
        {
            var hash = new Hash(SHA512.Create());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            model.senha = hash.CriptografarSenha(model.senha);
            _repositorioFuncionario.Insere(model);
            return await _repositorioFuncionario.SaveChangesAsync()
                ? Ok(model)
                : BadRequest("Erro ao salvar usuário");
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Consulta(int id)
        {
            var funcionario = await _repositorioFuncionario.RetornaPorId(id);
            return funcionario != null
                ? Ok(funcionario)
                : NotFound("Usuário não encontrado");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(int Id)
        {
            var funcionarioBanco = await _repositorioFuncionario.RetornaPorId(Id);
            if (funcionarioBanco == null) return NotFound("Usuário não encontrado");

            _repositorioFuncionario.Remover(funcionarioBanco);

            return await _repositorioFuncionario.SaveChangesAsync()
                ? Ok("Usuário deleteado com sucesso")
                : BadRequest("Erro ao deletar usuário");
        }
    }
}