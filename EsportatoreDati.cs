using System;
using System.IO;
using System.Collections.Generic;

public static class EsportatoreDati
{
    public static void SalvaClienti(List<Anagrafica> lista)
    {
        string header = "Id;Nome/RagioneSociale;CodiceFiscale/IVA;Email";
        ScriviFile("clienti.csv", header, lista);
    }

    public static void SalvaOperazioni(List<Operazione> lista)
    {
        string header = "Id;Data;Descrizione;Quantita/Ore;Prezzo/Costo;Totale";
        ScriviFile("operazioni.csv", header, lista);
    }

    private static void ScriviFile<T>(string nomeFile, string intestazione, List<T> dati) where T : IEsportabile
    {
        try 
        {
            using (StreamWriter sw = new StreamWriter(nomeFile))
            {
                sw.WriteLine(intestazione);
                foreach (var item in dati)
                {
                    sw.WriteLine(item.ToCsvRow());
                }
            }
            Console.WriteLine($"Esportazione in {nomeFile} completata!");
        }
        catch (Exception ex)
        {
            //extra stampa errori
            File.AppendAllText("errori.csv", $"{DateTime.Now};Errore scrittura {nomeFile};{ex.Message}\n");
            Console.WriteLine("Errore durante l'export. Controlla errori.csv.");
        }
    }
}