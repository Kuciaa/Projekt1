using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfService1
{
    public class Class1
    {
       class CSiatkarz
         {
            public int id { get; set; }
            public string imie { get; set; }
            public string nazwisko { get; set; }
            public int wiek { get; set; }
            public int wzrost { get; set; }
            public string pozycja { get; set; }
            public string klub { get; set; }
         }
 
         class CKLub
         {
            public string nazwa { get; set; }
            public int rok_zalozenia { get; set; }
            public string trener { get; set; }
            public string hala { get; set; }
            public string maskotka { get; set; }
         }

        class Chala
        {
            public string nazwah { get; set; }
            public string miasto { get; set; }
            public int liczba_miejsc { get; set; }
        }
    }
}