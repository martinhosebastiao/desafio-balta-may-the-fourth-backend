using System;
using System.Text.RegularExpressions;

namespace StarWars.API.Common.Utilities
{
    public static class Extract
    {
        public static int IdFromUrl(string? input)
        {
            if (input is null)
            {
                return 0;
            }

            input = input?.Replace("https://swapi.py4e.com/api/starships/", "");

            // Cria um padrão regex para encontrar apenas dígitos numéricos
            Regex regex = new Regex(@"\d+");

            var result = regex.Matches(input!).FirstOrDefault();

            // Extrai os números da string de entrada
            var IdExtraido = int.Parse(result?.Value ?? "0");

            return IdExtraido;
        }
    }
}

