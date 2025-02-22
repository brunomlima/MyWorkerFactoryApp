using System;
using System.Collections.Generic;

namespace MyWorkerFactoryApp.Configurations
{
    public class WorkerConfig
    {
        public string NivelLog { get; set; } = "Information";
        public List<ServicoConfig> Servicos { get; set; } = [];
    }

    public class ServicoConfig
    {
        public string Nome { get; set; } = string.Empty;
        public bool Ativo { get; set; }
        public int TempoEsperaMs { get; set; }
        public HorarioConfig? Horario { get; set; }
    }

    public class HorarioConfig
    {
        public string Inicio { get; set; } = string.Empty;
        public string Fim { get; set; }= string.Empty;

        public bool EstaDentroDoHorario()
        {
            var agora = DateTime.Now.TimeOfDay;
            return TimeSpan.TryParse(Inicio, out var inicio) &&
                   TimeSpan.TryParse(Fim, out var fim) &&
                   agora >= inicio && agora <= fim;
        }
    }
}
