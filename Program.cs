using System.Text;
using System.Net.Mime;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace csv_converter
{
    class Program
    {
        static void Main(string[] args)
        {
            var caminhoArquivoCsv = $"{Directory.GetCurrentDirectory()}/arquivo.csv";

            if(!File.Exists(caminhoArquivoCsv))
                return;

            var arquivoCsv = File.ReadAllLines(caminhoArquivoCsv);

            if(arquivoCsv.Length == 0)
                CriarArquivo();

            var arquivoConvertido = LerArquivo(arquivoCsv);

            var obterNomesDosCampos = new ConteudoArquivo().ObterNomesDosCampos();
        }

        public static IEnumerable<ConteudoArquivo> LerArquivo(IEnumerable<string> arquivoCsv)
        {
            var conteudosArquivos = new List<ConteudoArquivo>();

            foreach(var linha in arquivoCsv)
            {
                //A mágica acontece aqui, atribuo uma string a uma lista do tipo ConteudoArquivo.
                conteudosArquivos.Add(linha);
            }

            return conteudosArquivos;
        }

        public static void CriarArquivo()
        {
            var conteudoArquivos = new List<ConteudoArquivo>()
            {
                new ConteudoArquivo(),
                new ConteudoArquivo(),
                new ConteudoArquivo(),
                new ConteudoArquivo(),
                new ConteudoArquivo(),
                new ConteudoArquivo(),
                new ConteudoArquivo(),
                new ConteudoArquivo(),
                new ConteudoArquivo(),
            };

            File.WriteAllLines("arquivo.csv", conteudoArquivos.Select(x => x.LinhaArquivo), Encoding.UTF8);
        }
    }
}
