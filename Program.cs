using System;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            var indiceAluno = 0;
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "x")
            {
                switch (opcaoUsuario)
                {

                    case "1":
                        Console.WriteLine("Favor informar nome do aluno: ");
                        var aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe a nota do aluno: ");

                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }
                        else
                        {
                            throw new ArgumentException("O valor da nota deve ser decimal");
                        }

                        alunos[indiceAluno] = aluno;
                        indiceAluno++;

                        break;

                    case "2":
                        foreach (var al in alunos)
                        {
                            {
                                if (!string.IsNullOrEmpty(al.Nome))
                                    Console.WriteLine($"ALUNO: {al.Nome} - NOTA: {al.Nota}");
                            }
                        }
                        break;

                    case "3":

                        decimal notaTotal = 0;
                        var nrAlunos = 0;

                        for (int i = 0; i < alunos.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal = notaTotal + alunos[i].Nota;
                                nrAlunos++;
                            }
                        }

                        var mediaGeral = notaTotal / nrAlunos;
                        Conceitos conceitoGeral;

                        if (mediaGeral < 2)
                        {
                            conceitoGeral = Conceitos.E;
                        }
                        else if (mediaGeral < 4)
                        {
                            conceitoGeral = Conceitos.D;
                        }
                        else if (mediaGeral < 6)
                        {
                            conceitoGeral = Conceitos.C;
                        }
                        else if (mediaGeral < 8)
                        {
                            conceitoGeral = Conceitos.B;
                        }
                        else
                        {
                            conceitoGeral = Conceitos.A;
                        }

                        Console.WriteLine($"MÉDIA GERAL: {mediaGeral} - CONCEITO: {conceitoGeral}");

                        break;
                    default:
                        throw new ArgumentOutOfRangeException();

                }
                Console.WriteLine("Informe a opção desejada: ");
                Console.WriteLine("1 - Inserir novo aluno");
                Console.WriteLine("2 - Listar alunos");
                Console.WriteLine("3 - Calcular média geral");
                Console.WriteLine("x- Sair");
                Console.WriteLine();

                opcaoUsuario = ObterOpcaoUsuario();

            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada: ");
            Console.WriteLine("1 - Inserir novo aluno");
            Console.WriteLine("2 - Listar alunos");
            Console.WriteLine("3 - Calcular média geral");
            Console.WriteLine("x- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}