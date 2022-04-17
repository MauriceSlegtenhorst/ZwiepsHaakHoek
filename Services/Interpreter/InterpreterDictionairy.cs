namespace ZwiepsHaakHoek.Services.Interpreter
{
    public class InterpreterDictionairy
    {
        public string this[string language, string key, params string[] formatParams]
        {
            get 
            {
                return key switch
                {
                    "About" => language switch
                    {
                        "nl" => NL_ABOUT,
                        "de" => DE_ABOUT,
                        _ => NL_ABOUT,
                    },
                    "Contact" => language switch
                    {
                        "nl" => NL_CONTACT,
                        "de" => DE_CONTACT,
                        _ => NL_CONTACT,
                    },
                    "Credits" => language switch
                    {
                        "nl" => NL_CREDITS,
                        "de" => DE_CREDITS,
                        _ => NL_CREDITS,
                    },
                    "Home" => language switch
                    {
                        "nl" => NL_HOME,
                        "de" => DE_HOME,
                        _ => NL_HOME,
                    },
                    "LoadingPageContent" => language switch
                    {
                        "nl" => (formatParams is not null && formatParams.Length is 1)
                        ? string.Format(NL_LOADING_PAGE_CONTENT, formatParams)
                        : NL_LOADING_PAGE_CONTENT.Replace("{0} ", string.Empty),
                        "de" => (formatParams is not null && formatParams.Length is 1)
                        ? string.Format(NL_LOADING_PAGE_CONTENT, formatParams)
                        : DE_LOADING_PAGE_CONTENT.Replace("{0} ", string.Empty),
                        _ => (formatParams is not null && formatParams.Length is 1)
                        ? string.Format(NL_LOADING_PAGE_CONTENT, formatParams)
                        : NL_LOADING_PAGE_CONTENT.Replace("{0} ", string.Empty),
                    },
                    "Products" => language switch
                    {
                        "nl" => NL_PRODUCTS,
                        "de" => DE_PRODUCTS,
                        _ => NL_PRODUCTS,
                    },
                    "Price" => language switch
                    {
                        "nl" => (formatParams is not null && formatParams.Length is 1) 
                        ? string.Format("{0}: {1} {2}", formatParams.Prepend(NL_CurrencyLogo).Prepend(NL_PRICE).ToArray())
                        : NL_PRICE,
                        "de" => (formatParams is not null && formatParams.Length is 1)
                        ? string.Format("{0}: {1} {2}", formatParams.Prepend(DE_PRICE).Append(DE_CurrencyLogo).ToArray())
                        : DE_PRICE,
                        _ => (formatParams is not null && formatParams.Length is 1)
                        ? string.Format("{0}: {1} {2}", formatParams.Prepend(NL_CurrencyLogo).Prepend(NL_PRICE).ToArray())
                        : NL_PRICE,
                    },
                    _ => throw new KeyNotFoundException($"No translation found for key: \"{ key }\"."),
                };
            }
        }

        private const string NL_ABOUT = "Over mij";
        private const string DE_ABOUT = "Über mich";

        private const string NL_CONTACT = "Contact";
        private const string DE_CONTACT = "Kontakt";

        private const string NL_CREDITS = "Credits";
        private const string DE_CREDITS = "Credits";

        private const string NL_HOME = "Home";
        private const string DE_HOME = "Home";

        private const string NL_LOADING_PAGE_CONTENT = "Bezig met laden van de {0} pagina...";
        private const string DE_LOADING_PAGE_CONTENT = "Die {0} Seite wird geladen...";

        private const string NL_PRODUCTS = "Producten";
        private const string DE_PRODUCTS = "Produkte";

        private const string NL_PRICE = "Prijs";
        private const string DE_PRICE = "Preis";

        private const string NL_CurrencyLogo = "&#8364;";
        private const string DE_CurrencyLogo = "CHF";
    }
}
