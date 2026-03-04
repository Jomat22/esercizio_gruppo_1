class Anagrafica
{
    private long _id;
    private string _email = string.Empty;

    public long Id { get => _id; set => _id = value; }
    public string Email { 
        get => _email;
        set
        {
            if (string.IsNullOrWhiteSpace(value) || !value.Contains('@'))
            {
                throw new ArgumentException($"Email non valida: '{value}'. Usare il carattere '@'.");
            } else _email = value;
        }
    }

    public Anagrafica(long id, string email) { Id = id; Email = email; }
    public virtual string ToCsvRow() { return $""; }

    // Altro
    protected static string TxtSpacing()
    {
        byte leftPad = 5;
        byte rightPad = 5;
        char separator = '|';
        return $"{new string(' ', leftPad)}{separator}{new string(' ', rightPad)}";
    }
}