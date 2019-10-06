using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabSOGrauA
{
    class Program
    {
       static string nomeArquivo;

        static void Main()
        {
            Console.WriteLine("Escreva o nome do arquivo que contem os processos:");
            nomeArquivo = Console.ReadLine();
            if(!File.Exists(nomeArquivo))
            {
                if (File.Exists("jobs.txt"))
                {
                    Console.WriteLine("Arquivo não encontrado, o código será executado com o codigo usando o arquivo exemplo.");
                    Console.WriteLine("Pressione qualquer tecla para continuar");
                    Console.ReadLine();

                    nomeArquivo = "jobs.txt";
                }
                else
                {
                    Console.WriteLine("Verificar os arquivos no diretorio, é possivel que algum erro tenha ocorrido.");
                    Console.ReadLine();

                    //acaba o codigo
                    return;
                }
            }
            Console.Clear();

            //se chegou até aqui é pq ta tudo ok
            FCFS fcfs = new FCFS(CarregarProcessos());
            fcfs.run();
            fcfs.printStats();

            SJF sjf = new SJF(CarregarProcessos());
            sjf.run();
            sjf.printStats();

            RR rr = new RR(CarregarProcessos(), 2);
            rr.run();
            rr.printStats();

            rr = new RR(CarregarProcessos(), 5);
            rr.run();
            rr.printStats();

            rr = new RR(CarregarProcessos(), 10);
            rr.run();
            rr.printStats();

            Console.ReadLine();
        }

        static List<PCB> CarregarProcessos()
        {
            List<PCB> processos = new List<PCB>();
            using (StreamReader sr = new StreamReader(nomeArquivo))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (!line.Contains("#") /*se não eh comentario*/)
                    {
                        string[] values = line.Split(',');
                        //processos.add(Arrays.asList(values));
                        PCB pcb = new PCB(int.Parse(values[0]), int.Parse(values[1]), int.Parse(values[2]), int.Parse(values[3]));
                        processos.Add(pcb);
                    }
                    else
                    {
                        //Console.WriteLine("pid,estado,tamanho,io_percent,t_execucao,t_admissao,t_espera,t_termino,t_bloqueio,t_falta");
                    }
                }
            }
            return processos;
        }
    }

}
