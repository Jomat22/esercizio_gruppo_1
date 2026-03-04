class Ordine(long id, long clientId, DateOnly data, string descrizione, int quantita, decimal prezzoUnitario) : Operazione(id, clientId)
{
    private DateOnly _data;
    private string _descrizione;
    private int _quantita;
    private decimal _prezzoUnitario;
    public DateOnly Data { get => _data; set => _data = value; } = data;
    public string Descrizione { get => _descrizione; set => _descrizione = value; } = descrizione;
    public int Quantita { get => _quantita; set => _quantita = value; } = quantita;
    public decimal PrezzoUnitario { get => _prezzoUnitario; set => _prezzoUnitario = value; } = prezzoUnitario;
    public decimal Totale => Quantita * PrezzoUnitario;
}