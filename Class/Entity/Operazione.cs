class Operazione
{
    private long _id;
    private long _clientId;

    public long Id { get => _id; set => _id = value; }
    public long ClientId { get => _clientId; set => _clientId = value; }

    public Operazione(long id, long clientId) { Id = id; ClientId = clientId; }
    public virtual string ToCsvRow() { return $""; }
    public virtual string CalcolaTotale() { return $""; }

    // Altro
    protected static string TxtSpacing()
    {
        byte leftPad = 5;
        byte rightPad = 5;
        char separator = '|';
        return $"{new string(' ', leftPad)}{separator}{new string(' ', rightPad)}";
    }
}