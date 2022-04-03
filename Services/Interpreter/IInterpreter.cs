namespace ZwiepsHaakHoek.Services.Interpreter
{
    public interface IInterpreter
    {
        public string this[string key, params string[] formatParams] { get; }
    }
}
