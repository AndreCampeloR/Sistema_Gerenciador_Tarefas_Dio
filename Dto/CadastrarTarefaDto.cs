using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sistema_Gerenciador_Tarefas_Dio.Models;

namespace Sistema_Gerenciador_Tarefas_Dio.Dto
{
    public class CadastrarTarefaDto
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public EnumStatusTarefa Status { get; set; }
    }
}