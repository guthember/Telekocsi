using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

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

    static public void UtvonalLegtobbFerohely()
    {
      //Dictionary<string, int> utvonalak = new Dictionary<string, int>();

      //foreach (var a in autok)
      //{
      //  if ( !utvonalak.ContainsKey(a.Utvonal))
      //  {
      //    utvonalak.Add(a.Utvonal, a.Ferohely);
      //  }
      //  else
      //  {
      //    utvonalak[a.Utvonal] = utvonalak[a.Utvonal] + a.Ferohely;
      //  }
      //}

      int max = 0;
      string utv = "";

      //foreach (var u in utvonalak)
      //{
      //  if (u.Value > max)
      //  {
      //    max = u.Value;
      //    utv = u.Key;
      //  }
      //}

      var utvonalak = from a in autok
                      orderby a.Utvonal
                      group a by a.Utvonal into temp
                      select temp;

      foreach (var ut in utvonalak)
      {
        int fh = ut.Sum( x => x.Ferohely );
        if (max < fh)
        {
          max = fh;
          utv = ut.Key;
        }
        //Console.WriteLine($"{ut.Key} -> {ut.Count()}");
      }


      Console.WriteLine("4. feladat");
      Console.WriteLine($"   {max} - {utv}");

    }

    static public void IgenyAuto()
    {
      Console.WriteLine("5. feladat");

      foreach (var igeny in igenyek)
      {
        int i = igeny.VanAuto(autok);
        
        if (i > -1)
        {
          Console.WriteLine($"{igeny.Azonosito}=>{autok[i].Rendszam}");
        }
      }

      Console.WriteLine();
    }

    static public void Utasuzenet()
    {
      StreamWriter file = new StreamWriter("utasuzenetek.txt");

      foreach (var igeny in igenyek)
      {
        int i = igeny.VanAuto(autok);

        if (i > -1)
        {
          file.WriteLine($"{igeny.Azonosito}: Rendszám: {autok[i].Rendszam}, Telefonszám: {autok[i].Tel}");
        }
        else
        {
          file.WriteLine($"{igeny.Azonosito}: Sajnos nem sikerült autót találni");
        }
      }


      file.Close();
    }


    static void Main(string[] args)
    {
      Beolvasas();
      HanyHirdeto();
      BpMiskolcFerohely();
      UtvonalLegtobbFerohely();
      IgenyAuto();
      Utasuzenet();

      Console.ReadKey();
    }
  }
}
