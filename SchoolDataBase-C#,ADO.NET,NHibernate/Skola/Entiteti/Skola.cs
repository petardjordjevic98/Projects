using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skola.Entiteti
{
    public class Skola
    {
        public virtual int Id { get; set; }
        public virtual NastavnoOsoblje Nastavnik { get; set; }
        public virtual String skola { get; set; }
    }
}
