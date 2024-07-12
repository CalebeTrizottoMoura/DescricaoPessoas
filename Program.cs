using System;
using System.ComponentModel.Design;
using System.Globalization;
using System.Reflection;
using System.Runtime;

namespace MyApp {
    internal class Program {
        static void Main(string[] args) {
            CultureInfo CI = CultureInfo.InvariantCulture;

            DateTime dataAtual = DateTime.Now;

            string nome;
            int controle = 0;

            Console.WriteLine("===== Dados Pessoais =====");

            do {
                Console.Write("Nome: ");
                nome = Console.ReadLine();

                if (long.TryParse(nome, out _)) {
                    Console.WriteLine("Por favor, digite um nome válido.");
                    controle = 1;
                }
                else {
                    controle = 0;
                }
            } while (controle == 1);

            string nascimentoStr;

            do {
                Console.Write("Data de nascimento (DD/MM/AAAA): ");
                nascimentoStr = Console.ReadLine();

                if (nascimentoStr.Length == 8 && long.TryParse(nascimentoStr, out _)) {
                    nascimentoStr = nascimentoStr.Insert(2, "/").Insert(5, "/");
                    controle = 0;
                }
                else if (nascimentoStr.Contains('/')) {
                    controle = 0;
                }
                else {
                    Console.WriteLine("Por favor, digite uma data de nascimento válida");
                    controle = 1;
                }
            } while (controle == 1);

            double altura;

            do {
                Console.Write("Altura: ");
                string stringAltura = Console.ReadLine();

                if (double.TryParse(stringAltura, NumberStyles.Number, CI, out altura)) {
                    controle = 0;
                }
                else {
                    Console.WriteLine("Por favor, digite uma altura válida.");
                    controle = 1;
                }
            } while (controle == 1);

            Console.Write("Endereço: ");
            string endereco = Console.ReadLine();

            DateTime dataNascimento = DateTime.ParseExact(nascimentoStr, "dd/MM/yyyy", CI);

            int idade = dataAtual.Year - dataNascimento.Year;

            if (dataNascimento.Month > dataAtual.Month) {
                idade--;
            }
            else if (dataNascimento.Month == dataAtual.Month) {
                if (dataNascimento.Day > dataAtual.Day) {
                    idade--;
                }
            }

            Console.WriteLine($"\n{nome} nasceu em {dataNascimento.ToString("dd/MM/yyyy")} e possui {idade} anos de idade.");
            Console.WriteLine($"Além disso, {nome} tem {altura.ToString("F2", CI)} m de altura e " +
                $"atualmente reside neste endereço: {endereco}");
        }
    }
}