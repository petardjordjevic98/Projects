using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asocijacije
{
  public   class Ass
    {
        public string a1 { get; set; }
        public string a2 { get; set; }
        public string a3 { get; set; }
        public string a4 { get; set; }
        public List<string >a  { get; set; }

        public string b1 { get; set; }
        public string b2 { get; set; }
        public string b3 { get; set; }
        public string b4 { get; set; }
        public List<string> b { get; set; }


        public string c1 { get; set; }
        public string c2 { get; set; }
        public string c3 { get; set; }
        public string c4 { get; set; }
        public List<string> c { get; set; }
        public string d1 { get; set; }
        public string d2 { get; set; }
        public string d3 { get; set; }
        public string d4 { get; set; }
        public List<string> d { get; set; }
        public List<string> konacno { get; set; }
        public Ass(string A1,string A2,string A3,string A4,List<string> A, string B1, string B2, string B3, string B4,List<string> B,string C1
            ,string C2,string C3, string C4, List<string> C,string D1,string D2,string D3,string D4,List<string> D, List<string> K)
        {
            a1 = A1;
            a2 = A2;
            a3 = A3;
            a4 = A4;
            a = A;

            b1 = B1;
            b2 = B2;
            b3 = B3;
            b4 = B4;
            b = B;

            d1 = D1;
            d2 = D2;
            d3 = D3;
            d4 = D4;
            konacno = K;

            c1 = C1;
            c2 = C2;
            c3 = C3;
            c4 = C4;
            
            c = C;
            d= D;

        }
    }
}
