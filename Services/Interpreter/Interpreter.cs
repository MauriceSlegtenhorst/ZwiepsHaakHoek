using System.Globalization;

namespace ZwiepsHaakHoek.Services.Interpreter
{
    public class Interpreter : IInterpreter
    {
        private readonly InterpreterDictionairy _interpreterDictionairy = new();

        public string this[string key, params string[] formatParams] => _interpreterDictionairy[CultureInfo.DefaultThreadCurrentUICulture.Name, key, formatParams];
    }
}
