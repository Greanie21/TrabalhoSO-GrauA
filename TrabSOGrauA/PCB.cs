using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabSOGrauA
{
    public class PCB
    {
        int pid;        // PID
        char estado;    // E, P, B, T ->Executando, Pronto, Bloqueado, Terminado
        int tamanho;    // tamanho em MB; máquina tem 20 MB
        int io_percent; // probabilidade de fazer IO durante execução
        int t_execucao; // tempo total de execução do processo
        int t_admissao; // momento em que o job foi admitido
        int t_espera;   // tempo em que o job ficou no estado Pronto
        int t_termino;  // momento em que o job terminou de executar
        int t_bloqueio; // tempo em que o job ficou bloqueado ->tempo que falta para um processo Bloqueado voltar a ficar Pronto
        int t_falta;    // tempo de CPU que falta para o processo terminar a execução

        public PCB(int pid, int tamanho, int io_percent, int t_execucao)
        {
            this.pid = pid;
            estado = 'P';
            this.tamanho = tamanho;
            this.io_percent = io_percent;
            this.t_execucao = t_execucao;
            t_admissao = 0;
            t_espera = 0;
            t_termino = 0;
            t_bloqueio = 0;
            t_falta = t_execucao;
        }

        PCB()
        {

        }

        public String toString()
        {
            return pid + ", " +
                estado + ", " +
                tamanho + ", " +
                io_percent + ", " +
                t_execucao + ", " +
                t_admissao + ", " +
                t_espera + ", " + t_termino + ", " + t_bloqueio + ", " + t_falta;
        }

        public int Pid { get => pid; set => pid = value; }
        public char Estado { get => estado; set => estado = value; }
        public int Tamanho { get => tamanho; set => tamanho = value; }
        public int Io_percent { get => io_percent; set => io_percent = value; }
        public int T_execucao { get => t_execucao; set => t_execucao = value; }
        public int T_admissao { get => t_admissao; set => t_admissao = value; }
        public int T_espera { get => t_espera; set => t_espera = value; }
        public int T_termino { get => t_termino; set => t_termino = value; }
        public int T_bloqueio { get => t_bloqueio; set => t_bloqueio = value; }
        public int T_falta { get => t_falta; set => t_falta = value; }
    }
}
