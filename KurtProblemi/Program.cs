using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        // n değeri için kısıtlamanın kontrolü
        if (n < 5 || n > 2 * Math.Pow(10, 5))
        {
            Console.WriteLine("Geçersiz n değeri!");
            return;
        }

        string input = Console.ReadLine();
        string[] splittedInput = input.Split(' ');

        int[] dizi = new int[n];
        int index = 0;

        foreach (var part in splittedInput)
        {
            foreach (var ch in part)
            {
                int num = int.Parse(ch.ToString());

                // Numaranın 1-5 arasında olup olmadığını kontrol etme
                if (num < 1 || num > 5)
                {
                    Console.WriteLine("Geçersiz kurt türü ID'si!");
                    return;
                }

                dizi[index] = num;
                index++;
            }
        }

        int result = EnCokTespitEdilenTur(dizi);
        Console.WriteLine(result);
    }

    public static int EnCokTespitEdilenTur(int[] dizi)
    {
        Dictionary<int, int> turler = new Dictionary<int, int>();

        foreach (var tur in dizi)
        {
            if (turler.ContainsKey(tur))
            {
                turler[tur]++;
            }
            else
            {
                turler[tur] = 1;
            }
        }

        int maxSayi = 0;
        int minID = int.MaxValue;

        foreach (var item in turler)
        {
            if (item.Value > maxSayi)
            {
                maxSayi = item.Value;
                minID = item.Key;
            }
            else if (item.Value == maxSayi && item.Key < minID)
            {
                minID = item.Key;
            }
        }

        return minID;
    }
}
