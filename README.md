# TrabalhoSO-GrauA
Trabalho da cadeira de Sistemas Operacionais feita em 2019/2 programado em C#

# Discrição do Trabalho:
Programe um simulador de escalonador de processos que receba como parâmetro um arquivo texto contendo os dados dos processos e calcule algumas estatísticas para cada algoritmo:
*FCFS (FIFO)
*SJF não preemptivo
*Round Robin com quantum = 2 unidades de tempo (u.t.)
*Round Robin com quantum = 5 u.t.
*Round Robin com quantum = 10 u.t.

# Como Funciona:
Os 3 algoritmos são classes diferentes filhas de um mesmo pai, o qual pega a lista de processos (e o quantum especifico no caso do RR) e tem o metodos base "run()" o qual em todos os casos chama os metodos de admitir novos processos, entao escalona processos, faz a troca de contexto se necessario, executa o processo escolhido, incrementa o tempo de processos nao executados, e checa se todos os processos ja foram terminados.

# Instruções para execução:
Ao executar o projeto ele irá pedir o nome do arquivo para ler os processos, o qual deve estar localizado na pasta "bin -> Debug", caso não seja digitado um nome de arquivo valido ele irá checar se o arquivo de exemplo "jobs.txt" ainda existe, caso exista ele irá informar que o nome é digitado é invalido e ira avisar que será usado o arquivo de exemplo para a execução, rodando o programa e mostrando algumas informações sobre cada algoritmo de escalonamento. Caso o nome digitado seja invalido e o programa não encontre o arquivo de exemplo ele irá avisar que provavelmente ocorreu algum problema pois tanto o nome digitado é invalido e o arquivo teste não foi encontrado, e o programa irá acabar.
