using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sistema_Gerenciador_Tarefas_Dio.Context;
using Sistema_Gerenciador_Tarefas_Dio.Dto;
using Sistema_Gerenciador_Tarefas_Dio.Models;
using Sistema_Gerenciador_Tarefas_Dio.Repository;

namespace Sistema_Gerenciador_Tarefas_Dio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly TarefaRepository _repository;

        public TarefaController(TarefaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var tarefa = _repository.ObterPorId(id);

            if(tarefa is not null)
            {
               var tarefaDto = new ObterTarefasDto(tarefa);
               return Ok(tarefaDto);
            }
            else
            {
               return NotFound(new {Mesagem = "Tarefa não encontrado"});
            }
        }

        [HttpGet("ObterTodos")]
        public IActionResult ObterTodos()
        {
            var tarefa = _repository.ObterTodos();

            if(tarefa is not null)
            {
               return Ok(tarefa);
            }
            else
            {
            return NotFound(new {Mesagem = "Tarefa não encontrado"});
            }
        }

        [HttpGet("ObterPorTitulo")]
        public IActionResult ObterPorTitulo(string titulo)
        {
            var tarefa = _repository.ObterPorTitulo(titulo);

            if(tarefa is not null)
            {
               return Ok(tarefa);
            }
            else
            {
            return NotFound(new {Mesagem = "Tarefa não encontrado"});
            }
        }

        [HttpGet("ObterPorData")]
        public IActionResult ObterPorData(DateTime data)
        {
            var tarefa =  _repository.ObterPorData(data);
             if(tarefa is not null)
            {
               return Ok(tarefa);
            }
            else
            {
            return NotFound(new {Mesagem = "Tarefa não encontrado"});
            }
        }

        [HttpGet("ObterPorStatus")]
        public IActionResult ObterPorStatus(EnumStatusTarefa status)
        {
            var tarefa = _repository.ObterPorStatus(status);
            if(tarefa is not null)
            {
               return Ok(tarefa);
            }
            else
            {
            return NotFound(new {Mesagem = "Tarefa não encontrado"});
            }
        }

        [HttpPost]
        public IActionResult CriarTarefa(CadastrarTarefaDto dto)
        {
             var tarefa = new Tarefa(dto);

            _repository.CriarTarefa(tarefa);

            return Ok(tarefa);
            
            if (tarefa.Data == DateTime.MinValue)
                return BadRequest(new { Erro = "A data da tarefa não pode ser vazia" });
                return CreatedAtAction(nameof(ObterPorId), new { id = tarefa.Id }, tarefa);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarTarefa(int id, AtualizarTarefaDto dto)
        {
            var tarefa = _repository.ObterPorId(id);

            if (tarefa == null)
                return NotFound();

            if (tarefa.Data == DateTime.MinValue)
                return BadRequest(new { Erro = "A data da tarefa não pode ser vazia" });

             if(tarefa is not null)
            {
                tarefa.MapearAtualizarTarefaDto(dto);
                _repository.AtualizarTarefa(tarefa);
                
                return Ok(tarefa);
            }
            else
            {
                return NotFound(new { Mensagem = "Tarefa não encontrado"});   
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var tarefa = _repository.ObterPorId(id);

            if(tarefa is not null)
            {
                _repository.DeletarTarefa(tarefa);
                
                return NoContent();
            }
            else
            {
                return NotFound(new { Mensagem = "Tarefa não encontrado"});   
            }
        }
    }
}
