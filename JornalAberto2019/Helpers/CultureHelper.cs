using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace JornalAberto2019.Helpers
{
    /**
     * Adaptado de http://afana.me/archive/2011/01/14/aspnet-mvc-internationalization.aspx/
     */
    public static class CultureHelper
    {
        // lista de linguagens implementadas
        private static readonly List<string> _cultures = new List<string>
        {
            "en", // linguagem por defeito
            "pt",

        };

        public static string GetImplementedCulture(string name)
        {
            // se a header for null, retorna a linguagem generica
            if (string.IsNullOrEmpty(name))
                return GetDefaultCulture();

            // obtem a linguagem neutra da header (ex: pt-XX)
            var generic = GetNeutralCulture(name).ToLower();
            // se a linguagem existir na nossa lista, retorna-a
            if (_cultures.Contains(generic))
                return generic;

            // se não existir é porque não está implementada
            // retorna a linguagem por defeito
            return GetDefaultCulture();
        }

        // retorna a liguagem por defeito (primeira na lista)
        public static string GetDefaultCulture()
        {
            return _cultures[0];
        }

        // retorna a linguagem atual
        public static string GetCurrentCulture()
        {
            return Thread.CurrentThread.CurrentCulture.Name;
        }

        // retorna a linguagem neutra
        public static string GetNeutralCulture(string name)
        {
            if (!name.Contains("-")) return name;

            return name.Split('-')[0];
        }
    }
}