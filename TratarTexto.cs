using System.Collections.Generic;
using System.Linq;

namespace TestePratico
{
    /// <summary>
    /// Classe responsavel pelo tratamento dos textos
    /// </summary>
    public class TratarTexto
    {
        /// <summary>
        /// Retorna o vocabulário de palavras isoladas
        /// </summary>
        /// <param name="texto1"></param>
        /// <param name="texto2"></param>
        /// <returns></returns>
        public string[] RetornarVocabularioPalavrasIsoladas(string[] texto1, string[] texto2)
        {
            if (texto1.Count() == 0)
                return null;

            var retorno = new List<string>();

            for (int i = 0; i < texto1.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(texto1[i]) && VerificarSeEPalavra(texto1[i].ToCharArray()[0]))
                {
                    if (!retorno.Contains(texto1[i].ToLower()))
                        retorno.Add(texto1[i].ToLower());
                }
            }

            for (int i = 0; i < texto2.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(texto2[i]) && VerificarSeEPalavra(texto2[i].ToCharArray()[0]))
                {
                    if (!retorno.Contains(texto2[i].ToLower()))
                        retorno.Add(texto2[i].ToLower());
                }
            }

            return retorno.ToArray();
        }

        /// <summary>
        /// Retorna o vocabulário de duas palavras
        /// </summary>
        /// <param name="texto1"></param>
        /// <param name="texto2"></param>
        /// <returns></returns>
        public string[] RetornarVocabularioDuasPalavras(string[] texto1, string[] texto2)
        {
            if (texto1.Count() == 0)
                return null;

            var retorno = new List<string>();

            for (int i = 0; i < texto1.Length -1; i++)
            {
                if (!string.IsNullOrWhiteSpace(texto1[i]) && VerificarSeEPalavra(texto1[i].ToCharArray()[0]))
                {
                    if (!retorno.Contains($"{texto1[i].ToLower()} {texto1[i + 1].ToLower()}"))
                        retorno.Add($"{texto1[i].ToLower()} {texto1[i + 1].ToLower()}");
                }
            }

            for (int i = 0; i < texto2.Length - 1; i++)
            {
                if (!string.IsNullOrWhiteSpace(texto2[i]) && VerificarSeEPalavra(texto2[i].ToCharArray()[0]))
                {
                    if (!retorno.Contains($"{texto2[i].ToLower()} {texto2[i + 1].ToLower()}"))
                        retorno.Add($"{texto2[i].ToLower()} {texto2[i + 1].ToLower()}");
                }
            }

            return retorno.ToArray();
        }

        /// <summary>
        /// Valida se a primeiro caractere do é uma letra
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
        private bool VerificarSeEPalavra(char texto)
        {
            if (char.IsLetter(texto))
                return true;

            return false;
        }

        /// <summary>
        /// Remove os caracteres especiais do texto
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="permitirEspaco"></param>
        /// <returns></returns>
        public string RemoverCaracteresEspeciais(string texto, bool permitirEspaco = true)
        {
            string retorno;

            texto = texto.Replace('-', ' ').Replace("  ", " ");

            if (permitirEspaco)
                retorno = System.Text.RegularExpressions.Regex.Replace(texto, @"[^0-9a-zA-ZéúíóáÉÚÍÓÁèùìòàÈÙÌÒÀõãñÕÃÑêûîôâÊÛÎÔÂëÿüïöäËYÜÏÖÄçÇ\s]+?", string.Empty);
            else
                retorno = System.Text.RegularExpressions.Regex.Replace(texto, @"[^0-9a-zA-ZéúíóáÉÚÍÓÁèùìòàÈÙÌÒÀõãñÕÃÑêûîôâÊÛÎÔÂëÿüïöäËYÜÏÖÄçÇ]+?", string.Empty);

            return retorno;
        }

        /// <summary>
        /// Retorna a frequencia do vocabulário isolado em um texto
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="vocabulario"></param>
        /// <returns></returns>
        public int[] ObterFrequenciaVocabularioIsolado(string[] texto, string[] vocabulario)
        {
            var retorno = new List<int>();

            for (int i = 0; i < vocabulario.Length; i++)
            {
                var contador = 0;

                for (int j = 0; j  < texto.Length; j ++)
                {
                    if (vocabulario[i] == texto[j].ToLower())
                    {
                        contador++;
                    }
                }

                retorno.Add(contador);
            }

            return retorno.ToArray();
        }

        /// <summary>
        /// Retorna a frequencia  do vocabulário de duas palavras em um texto
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="vocabulario"></param>
        /// <returns></returns>
        public int[] ObterFrequenciaVocabularioDuasPalavras(string[] texto, string[] vocabulario)
        {
            var retorno = new List<int>();

            for (int i = 0; i < vocabulario.Length; i++)
            {
                var contador = 0;

                for (int j = 0; j < texto.Length -1; j++)
                {
                    if (vocabulario[i] == $"{texto[j].ToLower()} {texto[j+1].ToLower()}")
                    {
                        contador++;
                    }
                }

                retorno.Add(contador);
            }

            return retorno.ToArray();
        }

        /// <summary>
        /// Formata os dados para a exibição
        /// </summary>
        /// <param name="descricao"></param>
        /// <param name="dados"></param>
        /// <returns></returns>
        public string FormatarDadosParaExibicao(string descricao, string[] dados)
        {
            var retorno = string.Empty;

            retorno = $"{descricao} - [{string.Join(",", dados)}]";

            return retorno;
        }

        /// <summary>
        /// Formata os dados para exibição
        /// </summary>
        /// <param name="descricao"></param>
        /// <param name="dados"></param>
        /// <returns></returns>
        public string FormatarDadosParaExibicao(string descricao, int[] dados)
        {
            var retorno = string.Empty;

            retorno = $"{descricao} - [{string.Join(",", dados)}]";

            return retorno;
        }
    }
}
