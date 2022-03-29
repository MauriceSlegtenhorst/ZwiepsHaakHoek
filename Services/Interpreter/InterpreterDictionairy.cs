namespace ZwiepsHaakHoek.Services.Interpreter
{
    public class InterpreterDictionairy
    {
        public string this[string language, string key]
        {
            get 
            {
                return key switch
                {
                    "About" => language switch
                    {
                        "nl" => NL_ABOUT,
                        "de" => DE_ABOUT,
                        _ => throw new KeyNotFoundException(LanguageNotFound(language)),
                    },
                    "Contact" => language switch
                    {
                        "nl" => NL_CONTACT,
                        "de" => DE_CONTACT,
                        _ => throw new KeyNotFoundException(LanguageNotFound(language)),
                    },
                    "Credits" => language switch
                    {
                        "nl" => NL_CREDITS,
                        "de" => DE_CREDITS,
                        _ => throw new KeyNotFoundException(LanguageNotFound(language)),
                    },
                    "Home" => language switch
                    {
                        "nl" => NL_HOME,
                        "de" => DE_HOME,
                        _ => throw new KeyNotFoundException(LanguageNotFound(language)),
                    },
                    "LoadingPageContent" => language switch
                    {
                        "nl" => NL_LOADING_PAGE_CONTENT,
                        "de" => DE_LOADING_PAGE_CONTENT,
                        _ => throw new KeyNotFoundException(LanguageNotFound(language)),
                    },
                    "Products" => language switch
                    {
                        "nl" => NL_PRODUCTS,
                        "de" => DE_PRODUCTS,
                        _ => throw new KeyNotFoundException(LanguageNotFound(language)),
                    },
                    _ => throw new KeyNotFoundException($"No translation found for key: \"{ key }\"."),
                };
            }
        }

        private string LanguageNotFound(string language) => $"Language: \"{language}\" is not supported.";

        private const string NL_ABOUT = "Over mij";
        private const string DE_ABOUT = "Über mich";

        private const string NL_CONTACT = "Contact";
        private const string DE_CONTACT = "Kontakt";

        private const string NL_CREDITS = "Credits";
        private const string DE_CREDITS = "Credits";

        private const string NL_HOME = "Home";
        private const string DE_HOME = "Home";

        private const string NL_LOADING_PAGE_CONTENT = "Bezig met laden van de pagina...";
        private const string DE_LOADING_PAGE_CONTENT = "Die Seite wird geladen...";

        private const string NL_PRODUCTS = "Producten";
        private const string DE_PRODUCTS = "Produkte";
    }
}
