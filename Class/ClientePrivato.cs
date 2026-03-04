class ClientePrivato(long id, string email, string nome, string cognome, string codiceFiscale) : Anagrafica(id, email)
{
    private string _nome;
    private string _cognome;
    private string _codiceFiscale;

    public string Nome { get => _nome; set => _nome = value; } = nome;
    public string Cognome { get => _cognome; set => _cognome = value; } = cognome;
    public string CodiceFiscale { get => _codiceFiscale; set => _codiceFiscale = value; } = codiceFiscale;

    public override string ToCsvRow()
    {
        return $"ID: {ID}\tEmail: {Email}\tNome: {Nome}\tCognome: {Cognome}\tCodice Fiscale: {CodiceFiscale}";
    }
}