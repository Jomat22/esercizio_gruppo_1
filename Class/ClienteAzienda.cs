class ClienteAzienda(long id, string email, string ragioneSociale, string partitaIVA, string referente) : Anagrafica(id, email)
{
    private string _ragioneSociale;
    private string _partitaIVA;
    private string _referente;

    public string RagioneSociale { get => _ragioneSociale; set => _ragioneSociale = value; } = ragioneSociale;
    public string PartitaIVA { get => _partitaIVA; set => _partitaIVA = value; } = partitaIVA;
    public string Referente { get => _referente; set => _referente = value; } = referente;

}