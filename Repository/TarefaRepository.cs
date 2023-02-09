using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sistema_Gerenciador_Tarefas_Dio.Context;
using Sistema_Gerenciador_Tarefas_Dio.Dto;
using Sistema_Gerenciador_Tarefas_Dio.Models;

namespace Sistema_Gerenciador_Tarefas_Dio.Repository
{
    public class TarefaRepository
    {
        private readonly OrganizadorContext _context;
        
        public TarefaRepository(OrganizadorContext context)
        {
            _context = context;
        }

        public void CriarTarefa(Tarefa tarefa)
        {
            _context.Tarefas.Add(tarefa);
            _context.SaveChanges();
        }
        public void DeletarTarefa(Tarefa tarefa)
        {
        _context.Tarefas.Remove(tarefa);
        _context.SaveChanges();
        }
        public Tarefa AtualizarTarefa(Tarefa tarefa)
        {
        _context.Tarefas.Update(tarefa);
        _context.SaveChanges();

        return tarefa;
        }

        public Tarefa ObterPorId(int id)
        {
        var tarefa = _context.Tarefas.Find(id);
        return tarefa;
        }
        public List<Tarefa> ObterTodos()
        {
          var Tarefa = _context.Tarefas.ToList();
          return Tarefa;
        }


        public List<ObterTarefasDto> ObterPorTitulo(string titulo)
        {
            var tarefa = _context.Tarefas.Where(x => x.Titulo.Contains(titulo))
                                                .Select(x => new ObterTarefasDto(x))
                                                .ToList();
            return tarefa;
        }
        public List<ObterTarefasDto> ObterPorData(DateTime data)
        {
            var tarefa = _context.Tarefas.Where(x => x.Data.Date == data.Date)
                                                .Select(x => new ObterTarefasDto(x))
                                                .ToList();                            
            return tarefa;
        }
        public List<ObterTarefasDto> ObterPorStatus(EnumStatusTarefa status)
        {
            var tarefa = _context.Tarefas.Where(x => x.Status == status)
                                                .Select(x => new ObterTarefasDto(x))
                                                .ToList();
            return tarefa;
        }


    }
}