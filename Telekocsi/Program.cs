using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Telekocsi
{
  class Program
  {
    static List<Auto> autok = new List<Auto>();
    static List<Igeny> igenyek = new List<Igeny>();

    static public void Beolvasas()
    {
      StreamReader a = new StreamReader("autok.csv");
      a.ReadLine();
      while (!a.EndOfStream)
      {
        string[] adat = a.ReadLine().Split(';');
        autok.Add(new Auto(adat[0], adat[1], adat[2], adat[3], Convert.ToInt32(adat[4])));
      }
      a.Close();

      StreamReader i = new StreamReader("igenyek.csv");
      i.ReadLine();
      while (!i.EndOfStream)
      {
        string[] adat = i.ReadLine().Split(';');
        igenyek.Add(new Igeny(adat[0], adat[1], adat[2], Convert.ToInt32(adat[3])));
      }
      i.Close();
    }

    static public void HanyHirdeto()
    {
      //ismétlődik-e rendszám? (csak ellenőrzés)
      //var lista = from a in autok
      //            group a by a.Rendszam into temp
      //            select temp;

      //foreach (var l in lista)
      //{
      //  if (l.Count() > 1)
      //  {
      //    Console.WriteLine($"{l.Key} - {l.Count()}");
      //  }
      //}

      Console.WriteLine("2. feladat");
      Console.WriteLine($"   {autok.Count} autós hirdet fuvart");
    }

    static public void BpMiskolcFerohely()
    {
      Console.WriteLine("3. feladat");
      int ferohely = 0;
      foreach (var a in autok)
      {
        if (a.Indulas == "Budapest" && a.Cel == "Miskolc")
        {
          ferohely += a.Ferohely;
        }
      }

      Console.WriteLine($"   Összesen {ferohely} férőhelyet hirdettek az autósok Budapestről Miskolcra");
    }

    static void Main(string[] args)
    {
      Beolvasas();
      HanyHirdeto();
      BpMiskolcFerohely();

      Console.ReadKey();
    }
  }
}
