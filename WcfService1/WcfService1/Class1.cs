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
             public string _imie;
             public string _nazwisko;
             public int _wiek;
             public int _wzrost;
             public string _pozycja;
             public string _klub;
 
             public string imie
             {
                 get { return _imie; }
                 set { _imie = value; }
             }
 
             public string nazwisko
             {
                 get { return _nazwisko; }
                 set { _nazwisko = value; }
             }
 
             public int wiek
             {
                 get { return _wiek; }
                 set { _wiek = value; }
             }
 
             public int wzrost
             {
                 get { return _wzrost; }
                 set { _wzrost = value; }
             }
 
             public string pozycja
             {
                 get { return _pozycja; }
                 set { _pozycja = value; }
             }
 
             public string klub
             {
                 get { return _klub; }
                 set { _klub = value; }
             }
 
             public CSiatkarz(string imie, string nazwisko, int wiek, int wzrost, string pozycja, string klub)
             {
                 this._imie = imie;
                 this._nazwisko = nazwisko;
                 this._wiek = wiek;
                 this._wzrost = wzrost;
                 this._pozycja = pozycja;
                 this._klub = klub;
             }
 
         }
 
         class CKLub
         {
             public string _nazwa;
             public int _rok_zalozenia;
             public string _trener;
             public int _ilosc_osiagniec;
             public string _hala;
 
             public string nazwa
             {
                 get { return _nazwa; }
                 set { _nazwa = value; }
             }
 
             public int rok_zalozenia
             {
                 get { return _rok_zalozenia; }
                 set { _rok_zalozenia = value; }
             }
 
             public string trener
             {
                 get { return _trener; }
                 set { _trener = value; }
             }
 
             public int ilosc_osiagniec
             {
                 get { return _ilosc_osiagniec; }
                 set { _ilosc_osiagniec = value; }
             }
 
             public string hala
             {
                 get { return hala; }
                 set { _hala = value; }
             }
 
             public CKLub(string nazwa, int rok_zalozenia, string trener, int ilosc_osiagniec, string hala)
             {
                 this._nazwa = nazwa;
                 this._rok_zalozenia = rok_zalozenia;
                 this._trener = trener;
                 this._ilosc_osiagniec = ilosc_osiagniec;
                 this._hala = hala;
             }
         }

        class Chala
        {
            public string _nazwah;
            public string _miasto;
            public int _liczba_miejsc;

            public string nazwah
            {
                get { return _nazwah; }
                set { _nazwah = value; }
            }

            public string miasto
            {
                get { return _miasto; }
                set { _miasto = value; }
            }

            public int liczba_miejsc
            {
                get { return _liczba_miejsc; }
                set { _liczba_miejsc = value; }
            }

            public Chala(string nazwah, string miasto, int liczba_miejsc)
            {
                this._nazwah = nazwah;
                this._miasto = miasto;
                this._liczba_miejsc = liczba_miejsc;
            }
        }
    }
}