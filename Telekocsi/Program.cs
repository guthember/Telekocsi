using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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


    static void Main(string[] args)
    {
      Beolvasas();
    }
  }
}
