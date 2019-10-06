using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabSOGrauA
{
    public abstract class AlgoritmoEscalonamento
    {
        // Lista de processos a serem processados
        protected List<PCB> processos = new List<PCB>();
        
        //Lista de processos admitidos
        protected List<PCB> admitidos = new List<PCB>();

        //Tempo decorrido da simulação
        protected int tempo;

        //Tempo usado para trocas de contexto
        protected int tempoTrocaContexto;

        //tamanho atual o qual nao pode passar de 20 (Mb)
        protected int tamanhoAtual;
        
        //processo sendo executado atualmente
        protected PCB pAtual;

        //Executa simulação 
        public abstract void run();

        //Imprime estatísticas
        public abstract void printStats();
        
        public AlgoritmoEscalonamento(List<PCB> p)
        {
            processos = p;
            admitidos = new List<PCB>();
            tempo = 0;
            tamanhoAtual = 0;
        }
    }
}
