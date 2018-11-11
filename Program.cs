using System;
using System.Text;

namespace TestePratico
{
    class Program
    {
        static void Main(string[] args)
        {
            //Busca os arquivos
            string arquivo1 = System.IO.File.ReadAllText(@"C:\Temp\texto1.txt", Encoding.Default);

            string arquivo2 = System.IO.File.ReadAllText(@"C:\Temp\texto2.txt", Encoding.Default);

            var tratamento = new TratarTexto();

            //faz o tratamento dos arquivos removendo coisas desnecessárias e criando um array
            var texto1 = tratamento.RemoverCaracteresEspeciais(arquivo1)?.Split(' ');
            var texto2 = tratamento.RemoverCaracteresEspeciais(arquivo2)?.Split(' ');                     

            //Retorna os vocabulários
            var vocabulario1 = tratamento.RetornarVocabularioPalavrasIsoladas(texto1, texto2);
            var vocabulario2 = tratamento.RetornarVocabularioDuasPalavras(texto1, texto2);

            //Retorna a frequencia das palavras do vocabulário em cada texto
            var frequenciaVocabulario1NoTxt1 = tratamento.ObterFrequenciaVocabularioIsolado(texto1, vocabulario1);
            var frequenciaVocabulario1NoTxt2 = tratamento.ObterFrequenciaVocabularioIsolado(texto2, vocabulario1);

            var frequenciaVocabulario2NoTxt1 = tratamento.ObterFrequenciaVocabularioDuasPalavras(texto1, vocabulario2);
            var frequenciaVocabulario2NoTxt2 = tratamento.ObterFrequenciaVocabularioDuasPalavras(texto2, vocabulario2);

            //Formata os dados para a exibição e os exibe na tela
            ExibirDadosNaTela(tratamento.FormatarDadosParaExibicao("Vocabulário 1", vocabulario1));
            ExibirDadosNaTela(tratamento.FormatarDadosParaExibicao("Frequencia Vocabulário 1 no Texto 1", frequenciaVocabulario1NoTxt1));
            ExibirDadosNaTela(tratamento.FormatarDadosParaExibicao("Frequencia Vocabulário 1 no Texto 2", frequenciaVocabulario1NoTxt2));

            ExibirDadosNaTela(tratamento.FormatarDadosParaExibicao("Vocabulário 2", vocabulario2));
            ExibirDadosNaTela(tratamento.FormatarDadosParaExibicao("Frequencia Vocabulário 2 no Texto 1", frequenciaVocabulario2NoTxt1));
            ExibirDadosNaTela(tratamento.FormatarDadosParaExibicao("Frequencia Vocabulário 2 no Texto 2", frequenciaVocabulario2NoTxt2));

            Console.ReadKey();

            void ExibirDadosNaTela(string texto)
            {
                Console.WriteLine(texto);
            }
        }
    }
}
