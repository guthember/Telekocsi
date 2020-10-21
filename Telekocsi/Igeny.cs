using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telekocsi
{
  class Igeny
  {
    public string Azonosito { get; private set; }
    public string Indulas { get; private set; }
    public string Cel { get; private set; }
    public int Szemelyek { get; private set; }

    public Igeny(string azonosito, string indulas, string cel, int szemelyek)
    {
      Azonosito = azonosito;
      Indulas = indulas;
      Cel = cel;
      Szemelyek = szemelyek;
    }
  }
}
