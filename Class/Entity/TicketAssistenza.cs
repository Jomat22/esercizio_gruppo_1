class TicketAssistenza : Operazione
{
    private DateOnly _dataApertura;
    private string _priorita = string.Empty;
    private int _oreLavoro;
    private decimal _costoOrario;

    public DateOnly DataApertura { get => _dataApertura; set => _dataApertura = value; }
    public string Priorita { 
        get => _priorita; 
        set { 
            if (value?.ToUpper() is "BASSO" or "MEDIO" or "ALTO")  _priorita = value.ToUpper();
            else throw new ArgumentException($"Priorità non valida: '{value}'. Usare BASSO, MEDIO o ALTO.");
        }
    }
    public int OreLavoro { get => _oreLavoro; set => _oreLavoro = value; }
    public decimal CostoOrario { get => _costoOrario; set => _costoOrario = value; }
    public decimal Totale { 
        get { 
            if (Priorita.Equals("ALTO", StringComparison.OrdinalIgnoreCase)) return OreLavoro * CostoOrario * 2;
            else return OreLavoro * CostoOrario;
        } 
    }

    public TicketAssistenza(long id, long clientId, DateOnly dataApertura, string priorita, int oreLavoro, decimal costoOrario) : base(id, clientId)
    {
        DataApertura = dataApertura; Priorita = priorita; OreLavoro = oreLavoro; CostoOrario = costoOrario;
    }

    public override string ToCsvRow()
    {
        return $"Tipo: Ticket assistenza{TxtSpacing()}ID: {Id}{TxtSpacing()}ID Cliente: {ClientId}{TxtSpacing()}Data apertura: {DataApertura}{TxtSpacing()}Priorità: {Priorita}{TxtSpacing()}Ore lavoro: {OreLavoro}{TxtSpacing()}Costo orario: {CostoOrario}{TxtSpacing()}Totale: {Totale}";
    }

    public override string CalcolaTotale() { return $"{Totale}"; }
}