using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabSOGrauA
{
    public class FCFS : AlgoritmoEscalonamento
    {

        public FCFS(List<PCB> p) : base(p)
        {
            //executar o contrutor da classe pai

        }

        public override void run()
        {
            while (true)
            {
                //1.Fazer admissao de novos jobs
                admissao();

                //2.Escalonar processos no estado P
                if (escalonar())
                {
                    //3.Trocar contexto se for o caso
                    trocar_contexto();
                }

                //4.Executar processo escolhido
                executar();

                //5.Incrementar tempo de quem nao executou
                processa_nao_escalonados();

                //6. Condição de parada da simulação
                if (condicao_parada())
                {

                }
                else
                {
                    return;
                }
            }
        }

        void admissao()
        {
            //percorre todos os processos
            for (int i = 0; i < processos.Count; i++)
            {
                if (processos[i].Estado == 'P' && !admitidos.Contains(processos[i]))
                {
                    //so admitite ate tamanho max de 20
                    if (tamanhoAtual + processos[i].Tamanho <= 20)
                    {
                        //registra o momento em que o job foi admitido
                        processos[i].T_admissao = tempo;

                        //atualiza o valor do tamanho atual
                        tamanhoAtual += processos[i].Tamanho;

                        //adiciona o processo na lista de adimtido
                        admitidos.Add(processos[i]);
                    }
                    else
                    {
                        //para de percorrer os processos pois ja esta no tamanho maximo
                        return;
                    }
                }
            }
        }

        bool escalonar()
        {
            if (pAtual == null)
            {
                tempo++;
                foreach (PCB processoAdmitido in admitidos)
                {
                    if (processoAdmitido.Estado == 'P')
                    {
                        pAtual = processoAdmitido;
                        return true;
                    }
                    else
                    {
                        throw new Exception("Eu ACHO q nao deveria ter acontecido isso");
                    }
                }
            }
            return false;
        }

        void trocar_contexto()
        {
            pAtual.Estado = 'E';

            //remove da lista para ficar mais facil de manipular
            admitidos.Remove(pAtual);
            
            tempo++;
            tempoTrocaContexto++;
        }

        void executar()
        {
            if (pAtual != null)
            {
                int rndNum = new Random().Next(101);
                //rndNum = 1000;

                if (rndNum < pAtual.Io_percent)
                {
                    //bloqueia
                    pAtual.Estado = 'B';

                    //
                    //tamanhoAtual -= pAtual.Tamanho;

                    //registra o tempo que falta para o processo voltar a ficar Pronto
                    pAtual.T_bloqueio = 20;

                    pAtual = null;
                }
                else
                {
                    pAtual.T_falta--;
                    if (pAtual.T_falta == 0)
                    {
                        pAtual.Estado = 'T';

                        //registra o momento em que o job terminou de executar
                        pAtual.T_termino = tempo;

                        //abre espaço para mais processo serem admitidos
                        tamanhoAtual -= pAtual.Tamanho;

                        //admitidos.Remove(pAtual);
                        pAtual = null;
                    }
                }
            }
        }

        void processa_nao_escalonados()
        {
            foreach (PCB processoAdmitido in admitidos)
            {
                if (processoAdmitido.Estado == 'P')
                {
                    processoAdmitido.T_espera++;
                }
                else
                {
                    throw new Exception("algum processo que não deveria estar na lista de admitidos entrou");
                }
            }

            foreach (PCB processo in processos)
            {
                if (processo.Estado == 'B')
                {
                    processo.T_bloqueio--;

                    if (processo.T_bloqueio == 0)
                    {
                        processo.Estado = 'P';

                        //tamanhoAtual += processo.Tamanho;

                        admitidos.Add(processo);
                    }
                }
            }
        }

        bool condicao_parada()
        {
            foreach (PCB processo in processos)
            {
                if (processo.Estado != 'T')
                {
                    return true;
                }
            }
            return false;
        }

        public override void printStats()
        {
            float throughputMedio = (float)processos.Count / (float)tempo;
            float tempoEsperaTotal = 0;
            float tempoTurnaroundTotal = 0;
            foreach (PCB processo in processos)
            {
                tempoEsperaTotal += processo.T_espera;
                tempoTurnaroundTotal += processo.T_termino - processo.T_admissao;
            }

            Console.WriteLine("FIFO:");
            Console.WriteLine("Throughput médio (processos terminados por unidade de tempo):" + throughputMedio);
            Console.WriteLine("Tempo médio de espera:" + tempoEsperaTotal / processos.Count);
            Console.WriteLine("Tempo médio de turnaround (tempo entre início e fim do processo):" + tempoTurnaroundTotal / processos.Count);
            Console.WriteLine("Tempo total da simulação:" + tempo);
            Console.WriteLine("Percentual de uso da CPU para executar processos de usuário:" + Math.Round((tempo - tempoTrocaContexto) * 100.0f / tempo) + "%");
            Console.WriteLine("Percentual de uso da CPU para trocas de contexto:" + Math.Round(tempoTrocaContexto * 100.0f / tempo) + "%");
            Console.WriteLine("");
        }
    }
}
