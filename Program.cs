using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<Anagrafica> clienti = new List<Anagrafica>();
    static List<Operazione> operazioni = new List<Operazione>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n===== OFFICE FLOW =====");
            Console.WriteLine("1. Inserisci cliente");
            Console.WriteLine("2. Inserisci operazione");
            Console.WriteLine("3. Lista clienti");
            Console.WriteLine("4. Lista operazioni");
            Console.WriteLine("5. Export CSV");
            Console.WriteLine("6. Esci");

            Console.Write("Scelta: ");
            string scelta = Console.ReadLine();

            try
            {
                switch (scelta)
                {
                    case "1":
                        InserisciCliente();
                        break;
                    case "2":
                        InserisciOperazione();
                        break;
                    case "3":
                        ListaClienti();
                        break;
                    case "4":
                        ListaOperazioni();
                        break;
                    case "5":
                        ExportCsv();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Scelta non valida.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore: {ex.Message}");
            }
        }
    }

    // ========================= CLIENTI =========================

    static void InserisciCliente()
    {
        Console.WriteLine("1 - Privato");
        Console.WriteLine("2 - Azienda");
        string tipo = Console.ReadLine();

        int id = IdGenerator.NextId();

        if (tipo == "1")
        {
            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Cognome: ");
            string cognome = Console.ReadLine();

            Console.Write("Codice Fiscale: ");
            string cf = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            clienti.Add(new ClientePrivato(id, nome, cognome, cf, email));
        }
        else if (tipo == "2")
        {
            Console.Write("Ragione Sociale: ");
            string ragione = Console.ReadLine();

            Console.Write("Partita IVA: ");
            string piva = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Referente: ");
            string referente = Console.ReadLine();

            clienti.Add(new ClienteAzienda(id, ragione, piva, email, referente));
        }
        else
        {
            Console.WriteLine("Tipo non valido.");
        }
    }

    static void ListaClienti()
    {
        Console.WriteLine("\n--- CLIENTI ---");

        foreach (var c in clienti)
        {
            Console.WriteLine(c.ToCsvRow());
        }
    }

    // ========================= OPERAZIONI =========================

    static void InserisciOperazione()
    {
        Console.WriteLine("1 - Ordine");
        Console.WriteLine("2 - Ticket Assistenza");
        string tipo = Console.ReadLine();

        int id = IdGenerator.NextId();

        Console.Write("Cliente ID: ");
        int clienteId = int.Parse(Console.ReadLine());

        Console.Write("Data (yyyy-mm-dd): ");
        DateTime data = DateTime.Parse(Console.ReadLine());

        if (tipo == "1")
        {
            Console.Write("Descrizione: ");
            string descrizione = Console.ReadLine();

            Console.Write("Quantità: ");
            int quantita = int.Parse(Console.ReadLine());

            Console.Write("Prezzo Unitario: ");
            decimal prezzo = decimal.Parse(Console.ReadLine());

            operazioni.Add(new Ordine(id, clienteId, data, descrizione, quantita, prezzo));
        }
        else if (tipo == "2")
        {
            Console.Write("Priorità (Bassa/Media/Alta): ");
            string priorita = Console.ReadLine();

            Console.Write("Ore lavoro: ");
            int ore = int.Parse(Console.ReadLine());

            Console.Write("Costo orario: ");
            decimal costo = decimal.Parse(Console.ReadLine());

            operazioni.Add(new TicketAssistenza(id, clienteId, data, ore, costo, priorita));
        }
        else
        {
            Console.WriteLine("Tipo non valido.");
        }
    }

    static void ListaOperazioni()
    {
        Console.WriteLine("\n--- OPERAZIONI ---");

        foreach (var op in operazioni)
        {
            Console.WriteLine($"{op.Id} - Cliente {op.ClienteId} - Totale: {op.CalcolaTotale()}");
        }
    }

    // ========================= EXPORT CSV =========================

    static void ExportCsv()
    {
        File.WriteAllLines("clienti.csv",
            new List<string> { "Id;Tipo;Dati" }
            .Concat(clienti.ConvertAll(c => c.ToCsvRow())));

        File.WriteAllLines("operazioni.csv",
            new List<string> { "Id;Tipo;ClienteId;Data;Totale" }
            .Concat(operazioni.ConvertAll(o => o.ToCsvRow())));

        Console.WriteLine("File CSV generati con successo.");
    }
}