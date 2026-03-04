using System.Linq.Expressions;
using System.Xml;

class ClientePrivato : Anagrafica
{
    private string _nome = string.Empty;
    private string _cognome = string.Empty;
    private string _codiceFiscale = string.Empty;

    public string Nome { get => _nome; set => _nome = value; }
    public string Cognome { get => _cognome; set => _cognome = value; }
    public string CodiceFiscale { get => _codiceFiscale; set => _codiceFiscale = value; }

    public ClientePrivato(long id, string nome, string cognome, string codiceFiscale, string email) : base(id, email)
    {
        Nome = nome; Cognome = cognome; CodiceFiscale = codiceFiscale;
    }

    public override string ToCsvRow()
    { 
        return $"Tipo: Cliente (Privato){TxtSpacing()}ID: {Id}{TxtSpacing()}Email: {Email}{TxtSpacing()}Nome: {Nome}{TxtSpacing()}Cognome: {Cognome}{TxtSpacing()}Codice fiscale: {CodiceFiscale}";
    }
}