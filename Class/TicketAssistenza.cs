class TicketAssistenza(long id, long clientId, DateOnly dataApertura, string priorita, int oreLavoro, decimal costoOrario) : Operazione(id, clientId)
{
    private DateOnly _dataApertura;
    private string _priorita;
    private int _oreLavoro;
    private decimal _costoOrario;
    public DateOnly Data { get => _dataApertura; set => _dataApertura = value; } = dataApertura;
    public string Priorita { 
        get => _priorita; 
        set { 
            if (value?.ToUpper() is "BASSO" or "MEDIO" or "ALTO")  _priorita = value.ToUpper();
            else throw new ArgumentException($"Priorità non valida: '{value}'. Usare BASSO, MEDIO o ALTO.");
        }
    } = priorita;
    public int OreLavoro { get => _oreLavoro; set => _oreLavoro = value; } = oreLavoro;
    public decimal CostoOrario { get => _costoOrario; set => _costoOrario = value; } = costoOrario;
    public decimal Totale { 
        get { 
            if (Priorita.Equals("ALTA", StringComparison.OrdinalIgnoreCase)) return OreLavoro * CostoOrario * 2;
            else return OreLavoro * CostoOrario;
        } 
    }
}