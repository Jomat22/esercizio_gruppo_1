class Anagrafica(long id, string email)
{
    private long _id;
    private string _email;

    public long Id 
    { get => _id; set => _id = value; } = id;
    public string Email { 
        get => _email;
        set
        {
            if (string.IsNullOrWhiteSpace(value) || !value.Contains('@'))
            {
                throw new ArgumentException($"Email non valida: '{value}'. Usare il carattere '@'.");
            } else _email = value;
        }
    } = email;
}