class ClienteAzienda : Anagrafica
{
    private string _ragioneSociale = string.Empty;
    private string _partitaIVA = string.Empty;
    private string _referente = string.Empty;

    public string RagioneSociale { get => _ragioneSociale; set => _ragioneSociale = value; }
    public string PartitaIVA { get => _partitaIVA; set => _partitaIVA = value; }
    public string Referente { get => _referente; set => _referente = value; }

    public ClienteAzienda(long id, string ragioneSociale, string partitaIVA, string email, string referente) : base(id, email)
    {
        RagioneSociale = ragioneSociale; PartitaIVA = partitaIVA; Referente = referente;
    }
    
    public override string ToCsvRow()
    {
        return $"Tipo: Cliente (Azienda){TxtSpacing()}ID: {Id}{TxtSpacing()}Email: {Email}{TxtSpacing()}Rag. sociale: {RagioneSociale}{TxtSpacing()}Partita IVA: {PartitaIVA}{TxtSpacing()}Referente: {Referente}";
    }
}