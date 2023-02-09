using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sistema_Gerenciador_Tarefas_Dio.Dto;

namespace Sistema_Gerenciador_Tarefas_Dio.Models
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public EnumStatusTarefa Status { get; set; }

         public Tarefa()
        {

        }

        public Tarefa(CadastrarTarefaDto dto)
        {
            Titulo = dto.Titulo;
            Descricao = dto.Descricao;
            Data = dto.Data;
            Status = dto.Status;

        }

         public void MapearAtualizarTarefaDto(AtualizarTarefaDto dto)
        {
            Titulo = dto.Titulo;
            Descricao = dto.Descricao;
            Data = dto.Data;
            Status = dto.Status;
        }
    }
}