using System.Linq;
using System;
using System.Collections.Generic;

namespace csv_converter
{
    public class ConteudoArquivo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; }
        public int Inicio1 { get; set; }
        public int Fim1 { get; set; }
        public int Valor1 { get; set; }
        public int Inicio2 { get; set; }
        public int Fim2 { get; set; }
        public int Valor2 { get; set; }
        public int Inicio3 { get; set; }
        public int Fim3 { get; set; }
        public int Valor3 { get; set; }
        public string LinhaArquivo { get; set; }

        public ConteudoArquivo()
        {
            Id = new Random().Next();
            Nome = new Random().Next().ToString();
            Data = DateTime.Now.AddDays(new Random().Next(0, 100));

            Inicio1 = new Random().Next();
            Fim1 = new Random().Next();
            Valor1 = new Random().Next();

            Inicio2 = new Random().Next();
            Fim2  = new Random().Next();
            Valor2  = new Random().Next();

            Inicio3 = new Random().Next();
            Fim3 = new Random().Next();
            Valor3  = new Random().Next();

            LinhaArquivo = $"{Id}, {Nome}, {Data.ToString("yyyy-MM-dd")}, {Inicio1}, {Fim1}, {Valor1}, {Inicio2}, {Fim2}, {Valor2}, {Inicio3}, {Fim3}, {Valor3}";
        }

        public ConteudoArquivo(int id, string nome, DateTime data, int inicio1, int fim1, int valor1, int inicio2, int fim2, int valor2, int inicio3, int fim3, int valor3)
        {
            Id = id;
            Nome = nome;
            Data = data;

            Inicio1 = inicio1;
            Fim1 = fim1;
            Valor1 = valor1;

            Inicio2 = inicio2;
            Fim2  = fim2;
            Valor2  = valor2;

            Inicio3 = inicio3;
            Fim3 = fim3;
            Valor3  = valor3;
        }

        public static implicit operator ConteudoArquivo(string linhaArquivo)
        {
            var data = linhaArquivo.Split(",");

            //Antes de fazer o parse é necessário fazer a validação de tipo
            return new ConteudoArquivo(
                int.Parse(data[0]),
                data[1],
                DateTime.Parse(data[2]),
                int.Parse(data[3]),
                int.Parse(data[4]),
                int.Parse(data[5]),
                int.Parse(data[6]),
                int.Parse(data[7]),
                int.Parse(data[8]),
                int.Parse(data[9]),
                int.Parse(data[10]),
                int.Parse(data[11])
            );
        }

        public IEnumerable<string> ObterNomesDosCampos()
        {
            return typeof(ConteudoArquivo).GetProperties().Select(x => x.Name);
        }
    }
}