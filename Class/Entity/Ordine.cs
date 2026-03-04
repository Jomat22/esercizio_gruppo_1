class Ordine : Operazione
{
    private DateOnly _data;
    private string _descrizione = string.Empty;
    private int _quantita;
    private decimal _prezzoUnitario;

    public DateOnly Data { get => _data; set => _data = value; }
    public string Descrizione { get => _descrizione; set => _descrizione = value; }
    public int Quantita { get => _quantita; set => _quantita = value; }
    public decimal PrezzoUnitario { get => _prezzoUnitario; set => _prezzoUnitario = value; }
    public decimal Totale => Quantita * PrezzoUnitario;

    public Ordine(long id, long clientId, DateOnly data, string descrizione, int quantita, decimal prezzoUnitario) : base(id, clientId)
    {
        Data = data; Descrizione = descrizione; Quantita = quantita; PrezzoUnitario = prezzoUnitario;
    }

    public override string ToCsvRow()
    {
        return $"Tipo: Ordine{TxtSpacing()}ID: {Id}{TxtSpacing()}ID Cliente: {ClientId}{TxtSpacing()}Data: {Data}{TxtSpacing()}Descrizione: {Descrizione}{TxtSpacing()}Quantità: {Quantita}{TxtSpacing()}Prezzo unitario: {PrezzoUnitario}{TxtSpacing()}Totale: {Totale}";
    }

    public override string CalcolaTotale() { return $"{Totale}"; }
}