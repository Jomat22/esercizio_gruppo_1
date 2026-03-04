using System;
using System.Collections.Generic;

public class GestoreOperazioni
{
    public void MostraLista(List<Operazione> operazioni)
    {
        Console.WriteLine("\n--- ELENCO OPERAZIONI ---");
        decimal totaleGenerale = 0;

        Console.WriteLine("DATA | TIPO | TOTALE");

        foreach (var op in operazioni)
        {
            decimal totaleRiga = op.CalcolaTotale();
            totaleGenerale += totaleRiga;

            Console.WriteLine(op.Data.ToShortDateString() + " | " + op.GetType().Name + " | " + totaleRiga + "€");
        }

        Console.WriteLine();
        Console.WriteLine("TOTALE COMPLESSIVO: " + totaleGenerale + "€");
    }
}