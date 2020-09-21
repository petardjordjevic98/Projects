using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skola.Entiteti
{
    public class AdresaStanovanja
    {
        public virtual int Id { get; set; }
        public virtual Zaposleni Zaposleni { get; set; }
        public virtual String Adresa { get; set; }
    }
}
