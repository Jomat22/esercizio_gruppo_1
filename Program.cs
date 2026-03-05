class Program
{
    static readonly Random random = new();
    static List<Anagrafica> listAnagrafica = [];
    static List<Operazione> listOperazione = [];

    public static void Main()
    {
        while (true)
        {
            int scelta;

            do {
                Console.Clear();
                Console.WriteLine("===== OFFICE FLOW =====");
                Console.WriteLine("1. Inserisci cliente");
                Console.WriteLine("2. Inserisci operazione");
                Console.WriteLine("3. Lista clienti");
                Console.WriteLine("4. Lista operazioni");
                Console.WriteLine("5. Export CSV");
                Console.WriteLine("6. Esci");
                Console.WriteLine("0. (DEBUG) Popola liste con dati finti");
            } while (!int.TryParse(Console.ReadLine()!, out scelta) || scelta is < 0 or > 6);
            
            try {
                switch (scelta)
                {
                    case 1:
                        InserisciCliente();
                        ContinueAndClear();
                        break;
                    case 2:
                        InserisciOperazione();
                        ContinueAndClear();
                        break;
                    case 3:
                        ListaAnagrafica();
                        ContinueAndClear();
                        break;
                    case 4:
                        ListaOperazioni();
                        ContinueAndClear();
                        break;
                    case 5:
                        ExportCsv();
                        ContinueAndClear();
                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine("Sessione terminata.");
                        ContinueAndClear();
                        return;
                    case 0:
                        SeedLists();
                        ContinueAndClear();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Errore, scelta non valida.");
                        ContinueAndClear();
                        break;
                }
            } catch (Exception ex) { Console.WriteLine($"Errore: {ex.Message}"); }
        }
    }

    // ========================= 1. Inserimento Cliente =========================
    private static void InserisciCliente()
    {
        try
        {
            int scelta;

            do {
                Console.Clear();
                Console.WriteLine("Tipo Anagrafica:\n1. Privato\n2. Azienda\n0. (Annulla)");
            } while (!int.TryParse(Console.ReadLine()!, out scelta) || scelta is < 0 or > 2);

            if (scelta is 0) {
                Console.Clear();
                Console.WriteLine("Operazione di inserimento annullata.");
                return;
            }

            long id = random.NextInt64();
            string email;

            do {
                Console.Clear();
                Console.Write("Email (*@): ");
                email = Console.ReadLine()!;
            } while (string.IsNullOrEmpty(email) || !email.Contains('@'));

            switch(scelta) {
                case 1:
                    string nome;
                    string cognome;
                    string codiceFiscale;
                    
                    do {
                        Console.Clear();
                        Console.Write("Nome: ");
                        nome = Console.ReadLine()!;
                    } while (string.IsNullOrEmpty(nome));
                    
                    do {
                        Console.Clear();
                        Console.Write("Cognome: ");
                        cognome = Console.ReadLine()!;
                    } while (string.IsNullOrEmpty(cognome));
                    
                    do {
                        Console.Clear();
                        Console.Write("Codice Fiscale (*16 char): ");
                        codiceFiscale = Console.ReadLine()!;
                    } while (string.IsNullOrEmpty(codiceFiscale) || codiceFiscale.Length is not 16);
                    
                    listAnagrafica.Add(new ClientePrivato(id, nome, cognome, codiceFiscale, email));
                    Console.WriteLine("Anagrafica creata con successo.");
                    break;
                case 2:
                    string ragioneSociale;
                    string partitaIVA;
                    string referente;
                    
                    do {
                        Console.Clear();
                        Console.Write("Ragione Sociale: ");
                        ragioneSociale = Console.ReadLine()!;
                    } while (string.IsNullOrEmpty(ragioneSociale));
                    
                    do {
                        Console.Clear();
                        Console.Write("Partita IVA (*11 char): ");
                        partitaIVA = Console.ReadLine()!;
                    } while (string.IsNullOrEmpty(partitaIVA));
                    
                    do {
                        Console.Clear();
                        Console.Write("Referente: ");
                        referente = Console.ReadLine()!;
                    } while (string.IsNullOrEmpty(referente));
                    
                    listAnagrafica.Add(new ClienteAzienda(id, ragioneSociale, partitaIVA, email, referente));
                    Console.WriteLine("Operazione creata con successo.");
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Tipo non valido.");
                    ContinueAndClear();
                    break;
            }
        } catch(Exception ex) { Console.WriteLine($"Errore durante la procedura di inserimento.\nException => {ex.Message}"); }
    }

    // ========================= 2. Inserimento Operazione =========================
    private static void InserisciOperazione()
    {
        try {
            int scelta;

            do {
                Console.Clear();
                Console.WriteLine("Tipo Operazione:\n1. Ordine\n2. Ticket Assistenza\n0. (Annulla)");
            } while (!int.TryParse(Console.ReadLine()!, out scelta) || scelta is < 0 or > 2);

            if (scelta is 0) {
                Console.Clear();
                Console.WriteLine("Operazione di inserimento annullata.");
                return;
            }

            long id = random.NextInt64();
            long clienteId;
            DateOnly data;

            do {
                Console.Clear();
                Console.Write("Cliente ID: ");
            } while (!long.TryParse(Console.ReadLine()!, out clienteId));
            
            do {
                Console.Clear();
                Console.Write("Data (yyyy-mm-dd): ");
            } while (!DateOnly.TryParse(Console.ReadLine()!, out data));

            switch(scelta) {
                case 1:
                    string descrizione;
                    int quantita;
                    decimal prezzoUnitario;

                    do {
                        Console.Clear();
                        Console.Write("Descrizione: ");
                        descrizione = Console.ReadLine()!;
                    } while (string.IsNullOrEmpty(descrizione));
                    
                    do {
                        Console.Clear();
                        Console.Write("Quantità: ");
                    } while (!int.TryParse(Console.ReadLine()!, out quantita) || quantita is < 0);
                    
                    do {
                        Console.Clear();
                        Console.Write("Prezzo Unitario: ");
                    } while (!decimal.TryParse(Console.ReadLine()!, out prezzoUnitario) || quantita is < 0);

                    listOperazione.Add(new Ordine(id, clienteId, data, descrizione, quantita, prezzoUnitario));
                    Console.WriteLine("Ordine creato con successo.");
                    break;
                case 2:
                    string priorita;
                    int oreLavoro;
                    decimal costoOrario;

                    do {
                        Console.Clear();
                        Console.Write("Livello priorità (Basso/Medio/Alto): ");
                        priorita = Console.ReadLine()!.ToUpper();
                    } while (string.IsNullOrEmpty(priorita) || priorita is not ("BASSO" or "MEDIO" or "ALTO"));

                    do {
                        Console.Clear();
                        Console.Write("Ore lavoro (Min: 1 / Max: 8): ");
                    } while (!int.TryParse(Console.ReadLine()!, out oreLavoro) || oreLavoro is < 1 or > 8);

                    do {
                        Console.Clear();
                        Console.Write("Costo orario (Min: 15€ / Max: 250€): ");
                    } while (!decimal.TryParse(Console.ReadLine()!, out costoOrario) || costoOrario is < 15 or > 250);

                    listOperazione.Add(new TicketAssistenza(id, clienteId, data, priorita, oreLavoro, costoOrario));
                    Console.WriteLine("Ticket assistenza creato con successo.");
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Tipo non valido.");
                    ContinueAndClear();
                    break;
            }
        } catch(Exception ex) { Console.WriteLine($"Errore durante la procedura di inserimento.\nException => {ex.Message}"); }
    }

    // ========================= 3. Lista Anagrafica =========================
    private static void ListaAnagrafica()
    {
        Console.Clear();
        if (listAnagrafica.Count is 0) { Console.Clear(); Console.WriteLine("La lista di clienti è attualmente vuota."); return; }
        Console.WriteLine(new string('-', 5) + "CLIENTI" + new string('-', 5));
        for (int i = 0; i < listAnagrafica.Count; i++) { Console.WriteLine($"{i+1}. " + listAnagrafica[i].ToCsvRow()); }
    }

    // ========================= 4. Lista Operazione =========================
    private static void ListaOperazioni()
    {
        Console.Clear();
        if (listOperazione.Count is 0) { Console.Clear(); Console.WriteLine("La lista di operazioni è attualmente vuota."); return; }
        Console.WriteLine(new string('-', 5) + "OPERAZIONI" + new string('-', 5));
        for (int i = 0; i < listOperazione.Count; i++) { Console.WriteLine($"{i+1}. " + listOperazione[i].ToCsvRow()); }
    }

    // ========================= 5. Esportazione CSV =========================
    private static void ExportCsv()
    {
        File.WriteAllLines("_out_clienti.csv", new List<string> { "Tipo;Id;IdCliente;Dati" }
            .Concat(listAnagrafica.ConvertAll(c => c.ToCsvRow())));

        File.WriteAllLines("_out_operazioni.csv", new List<string> { "Tipo;Id;IdCliente;Dati" }
            .Concat(listOperazione.ConvertAll(o => o.ToCsvRow())));

        Console.Clear();
        Console.WriteLine("File CSV generati con successo.");
    }

    // ========================= Test =========================
    public static void SeedLists()
    {
        try {
        Console.Clear();
        // Questo era troppo... insert generati.
        // --- 15 Inserimenti per ClientePrivato ---
        listAnagrafica.Add(new ClientePrivato(random.NextInt64(), "Mario", "Rossi", "RSSMRA80A01H501U", "mario.rossi@gmail.com"));
        listAnagrafica.Add(new ClientePrivato(random.NextInt64(), "Laura", "Bianchi", "BNCLRA85B41L219Z", "laura.b@outlook.it"));
        listAnagrafica.Add(new ClientePrivato(random.NextInt64(), "Luca", "Verdi", "VRDLCU90C12F205G", "luca.verdi88@libero.it"));
        listAnagrafica.Add(new ClientePrivato(random.NextInt64(), "Giulia", "Neri", "NREGLI92D50H501A", "giulia.neri@fastweb.it"));
        listAnagrafica.Add(new ClientePrivato(random.NextInt64(), "Marco", "Gialli", "GLLMRC75E15F839O", "marco.g@tiscali.it"));
        listAnagrafica.Add(new ClientePrivato(random.NextInt64(), "Elena", "Ferrari", "FRRLNE88R45L219X", "e.ferrari@alice.it"));
        listAnagrafica.Add(new ClientePrivato(random.NextInt64(), "Paolo", "Russo", "RSSPLA82S20H501W", "russo.paolo@virgilio.it"));
        listAnagrafica.Add(new ClientePrivato(random.NextInt64(), "Sara", "Romano", "RMNSRA95M60F205K", "sara.romano@me.com"));
        listAnagrafica.Add(new ClientePrivato(random.NextInt64(), "Andrea", "Gallo", "GLLNDR70T10H501M", "andrea.gallo@protonmail.com"));
        listAnagrafica.Add(new ClientePrivato(random.NextInt64(), "Sofia", "Costa", "CSTSFN89A41L219Y", "sofia.costa@live.it"));
        listAnagrafica.Add(new ClientePrivato(random.NextInt64(), "Matteo", "Fontana", "FNTMTT93B12F205P", "m.fontana@tin.it"));
        listAnagrafica.Add(new ClientePrivato(random.NextInt64(), "Chiara", "Barbieri", "BRBCHR91C50H501Q", "chiara.barbieri@icloud.com"));
        listAnagrafica.Add(new ClientePrivato(random.NextInt64(), "Davide", "Serra", "SRRDVD84D14F839V", "davide.serra@yahoo.com"));
        listAnagrafica.Add(new ClientePrivato(random.NextInt64(), "Alessia", "Moretti", "MRTLSS87E45L219J", "alessia.m@gmail.com"));
        listAnagrafica.Add(new ClientePrivato(random.NextInt64(), "Filippo", "Rizzo", "RZZFPP79R22H501L", "f.rizzo@outlook.com"));

        // --- 15 Inserimenti per ClienteAzienda ---
        listAnagrafica.Add(new ClienteAzienda(random.NextInt64(), "Tech Solutions Srl", "01234567890", "info@techsolutions.it", "Ing. Brambilla"));
        listAnagrafica.Add(new ClienteAzienda(random.NextInt64(), "Global Trading Spa", "09876543210", "amministrazione@globaltrading.com", "Dott.ssa Ferrari"));
        listAnagrafica.Add(new ClienteAzienda(random.NextInt64(), "Eco Green Energy", "01122334455", "contatti@ecogreen.it", "Mario Boschi"));
        listAnagrafica.Add(new ClienteAzienda(random.NextInt64(), "Ristorante Da Gigio", "05566778899", "prenotazioni@dagigio.it", "Luigi Bianchi"));
        listAnagrafica.Add(new ClienteAzienda(random.NextInt64(), "Informatica Forense", "04433221100", "legal@infoforense.it", "Avv. Esposito"));
        listAnagrafica.Add(new ClienteAzienda(random.NextInt64(), "Moda Italia Sas", "07788990011", "commerciale@modaitalia.it", "Sara Galli"));
        listAnagrafica.Add(new ClienteAzienda(random.NextInt64(), "Costruzioni Moderne", "02244668800", "cantieri@costruzioni.it", "Geom. Neri"));
        listAnagrafica.Add(new ClienteAzienda(random.NextInt64(), "Logistica Nord Srl", "03355779911", "trasporti@lognord.it", "Stefano Rossi"));
        listAnagrafica.Add(new ClienteAzienda(random.NextInt64(), "Bio Farmaceutica", "06677889922", "lab@biofarma.it", "Dott.ssa Moretti"));
        listAnagrafica.Add(new ClienteAzienda(random.NextInt64(), "Auto Officina 24h", "08899001122", "officina@auto24h.it", "Filippo Motori"));
        listAnagrafica.Add(new ClienteAzienda(random.NextInt64(), "Agenzia Viaggi", "09900112233", "booking@viaggiworld.it", "Alessia Voli"));
        listAnagrafica.Add(new ClienteAzienda(random.NextInt64(), "Panificio Del Corso", "01020304050", "pane@delcorso.it", "Pietro Fornai"));
        listAnagrafica.Add(new ClienteAzienda(random.NextInt64(), "Studio Grafico Pixel", "02030405060", "art@studiopixel.it", "Marco Creativo"));
        listAnagrafica.Add(new ClienteAzienda(random.NextInt64(), "Impianti Idraulici", "03040506070", "info@idroimpianti.it", "Davide Tubi"));
        listAnagrafica.Add(new ClienteAzienda(random.NextInt64(), "Assicurazioni Veloci", "04050607080", "polizze@veloci.it", "Chiara Sicura"));

        // --- 15 Inserimenti per Ordine ---
        listOperazione.Add(new Ordine(random.NextInt64(), random.NextInt64(), new DateOnly(2024, 1, 10), "Laptop Dell XPS", 1, 1200.50m));
        listOperazione.Add(new Ordine(random.NextInt64(), random.NextInt64(), new DateOnly(2024, 1, 12), "Monitor LG 27\"", 2, 250.00m));
        listOperazione.Add(new Ordine(random.NextInt64(), random.NextInt64(), new DateOnly(2024, 1, 15), "Tastiera Meccanica", 5, 89.99m));
        listOperazione.Add(new Ordine(random.NextInt64(), random.NextInt64(), new DateOnly(2024, 1, 20), "Cavi HDMI 2.1", 10, 15.00m));
        listOperazione.Add(new Ordine(random.NextInt64(), random.NextInt64(), new DateOnly(2024, 2, 01), "Stampante Laser HP", 1, 350.00m));
        listOperazione.Add(new Ordine(random.NextInt64(), random.NextInt64(), new DateOnly(2024, 2, 05), "Toner Nero", 3, 75.20m));
        listOperazione.Add(new Ordine(random.NextInt64(), random.NextInt64(), new DateOnly(2024, 2, 10), "Webcam 4K", 2, 110.00m));
        listOperazione.Add(new Ordine(random.NextInt64(), random.NextInt64(), new DateOnly(2024, 2, 15), "Mouse Wireless", 4, 45.00m));
        listOperazione.Add(new Ordine(random.NextInt64(), random.NextInt64(), new DateOnly(2024, 2, 20), "Hard Disk Esterno 2TB", 3, 95.00m));
        listOperazione.Add(new Ordine(random.NextInt64(), random.NextInt64(), new DateOnly(2024, 3, 01), "Sedia Ergonomica", 1, 280.00m));
        listOperazione.Add(new Ordine(random.NextInt64(), random.NextInt64(), new DateOnly(2024, 3, 05), "Cuffie Noise Cancelling", 2, 199.99m));
        listOperazione.Add(new Ordine(random.NextInt64(), random.NextInt64(), new DateOnly(2024, 3, 08), "Docking Station USB-C", 1, 150.00m));
        listOperazione.Add(new Ordine(random.NextInt64(), random.NextInt64(), new DateOnly(2024, 3, 10), "Smartphone Aziendale", 2, 600.00m));
        listOperazione.Add(new Ordine(random.NextInt64(), random.NextInt64(), new DateOnly(2024, 3, 12), "Tablet 10\"", 1, 450.00m));
        listOperazione.Add(new Ordine(random.NextInt64(), random.NextInt64(), new DateOnly(2024, 3, 15), "Router Wi-Fi 6", 1, 120.00m));

        // --- 15 Inserimenti per Ticket Assistenza ---
        listOperazione.Add(new TicketAssistenza(random.NextInt64(), random.NextInt64(), new DateOnly(2024, 1, 11), "BASSO", 2, 40.00m));
        listOperazione.Add(new TicketAssistenza(random.NextInt64(), random.NextInt64(), new DateOnly(2024, 1, 13), "ALTO", 1, 60.00m)); // Totale raddoppiato
        listOperazione.Add(new TicketAssistenza(random.NextInt64(), random.NextInt64(), new DateOnly(2024, 1, 16), "MEDIO", 3, 45.00m));
        listOperazione.Add(new TicketAssistenza(random.NextInt64(), random.NextInt64(), new DateOnly(2024, 1, 21), "BASSO", 4, 35.00m));
        listOperazione.Add(new TicketAssistenza(random.NextInt64(), random.NextInt64(), new DateOnly(2024, 2, 02), "ALTO", 2, 80.00m)); // Totale raddoppiato
        listOperazione.Add(new TicketAssistenza(random.NextInt64(), random.NextInt64(), new DateOnly(2024, 2, 06), "MEDIO", 5, 50.00m));
        listOperazione.Add(new TicketAssistenza(random.NextInt64(), random.NextInt64(), new DateOnly(2024, 2, 11), "BASSO", 1, 40.00m));
        listOperazione.Add(new TicketAssistenza(random.NextInt64(), random.NextInt64(), new DateOnly(2024, 2, 16), "ALTO", 8, 55.00m)); // Totale raddoppiato
        listOperazione.Add(new TicketAssistenza(random.NextInt64(), random.NextInt64(), new DateOnly(2024, 2, 21), "MEDIO", 2, 60.00m));
        listOperazione.Add(new TicketAssistenza(random.NextInt64(), random.NextInt64(), new DateOnly(2024, 3, 02), "BASSO", 3, 45.00m));
        listOperazione.Add(new TicketAssistenza(random.NextInt64(), random.NextInt64(), new DateOnly(2024, 3, 06), "ALTO", 4, 100.00m)); // Totale raddoppiato
        listOperazione.Add(new TicketAssistenza(random.NextInt64(), random.NextInt64(), new DateOnly(2024, 3, 09), "MEDIO", 6, 40.00m));
        listOperazione.Add(new TicketAssistenza(random.NextInt64(), random.NextInt64(), new DateOnly(2024, 3, 11), "BASSO", 2, 50.00m));
        listOperazione.Add(new TicketAssistenza(random.NextInt64(), random.NextInt64(), new DateOnly(2024, 3, 13), "ALTO", 1, 250.00m)); // Totale raddoppiato
        listOperazione.Add(new TicketAssistenza(random.NextInt64(), random.NextInt64(), new DateOnly(2024, 3, 16), "MEDIO", 3, 70.00m));

        Console.WriteLine("Liste popolate con successo.");
        } catch(Exception ex){ Console.Clear(); Console.WriteLine($"[SEEDING ERROR] Errore critico durante il popolamento: {ex.Message}"); }
    }

    public static void ContinueAndClear()
    {
        Console.WriteLine("\nPremere un tasto per continuare...");
        Console.Write("\x1b[3j");
        Console.ReadKey(true);
        Console.Clear();
    }
}