using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    // UWAGA: możesz użyć polecenia „Zmień nazwę” w menu „Refaktoryzuj”, aby zmienić nazwę klasy „Service1” w kodzie, usłudze i pliku konfiguracji.
    // UWAGA: aby uruchomić klienta testowego WCF w celu przetestowania tej usługi, wybierz plik Service1.svc lub Service1.svc.cs w eksploratorze rozwiązań i rozpocznij debugowanie.
    public class Service1 : IService1
    {
        public CSiatkarz GetSiatkarz(int id)
        {
            SEntities context = new SEntities();
            var Siatkarze = (from p
                                 in context.Siatkarze
                             where p.Id == id
                             select p).FirstOrDefault();
            if (Siatkarze != null)
                return TranslateSiatkarzeToCSiatkarz(Siatkarze);
            else
            {
                return null;
            }
        }

        private CSiatkarz TranslateSiatkarzeToCSiatkarz(Siatkarze Siatkarze)
        {
            CSiatkarz siatkarz = new CSiatkarz();
            siatkarz.id = Siatkarze.Id;
            siatkarz.imie = Siatkarze.Imie;
            siatkarz.nazwisko = Siatkarze.Nazwisko;
            siatkarz.wiek = (int)Siatkarze.Wiek;
            siatkarz.wzrost = (int)Siatkarze.Wzrost;
            siatkarz.pozycja = Siatkarze.Pozycja;
            siatkarz.klub = Siatkarze.Klub;
            return siatkarz;

        }

        public CKlub GetKlub(string nazwa)
        {
            SEntities context = new SEntities();
            var Klub = (from p in context.Klub
                        where p.Nazwa == nazwa
                        select p).FirstOrDefault();
            if (Klub != null)
                return TranslateKlubToCKlub(Klub);
            else
            {
                return null;
            }
        }
        private CKlub TranslateKlubToCKlub(Klub kluby)
        {
            CKlub klub = new CKlub();
            klub.nazwa = kluby.Nazwa;
            klub.rok_zalozenia = (int)kluby.Rok_zalozenia;
            klub.trener = kluby.Trener;
            klub.hala = kluby.Hala;
            klub.maskotka = kluby.Maskotka;
            return klub;

        }

        public CHala GetHala(string nazwah)
        {
            SEntities context = new SEntities();
            var Hala = (from p in context.Hala
                        where p.Nazwa == nazwah
                        select p).FirstOrDefault();
            if (Hala != null)
                return TranslateHalaToCHala(Hala);
            else
            {
                return null;
            }
        }

        private CHala TranslateHalaToCHala(Hala hale)
        {
            CHala hala = new CHala();
            hala.nazwah = hale.Nazwa;
            hala.miasto = hale.Miasto;
            hala.liczba_miejsc = (int)hale.Liczba_miejsc;
            return hala;

        }

        public CSiatkarz AddSiatkarz(int id, string imie, string nazwisko, int wiek, int wzrost, string pozycja, string klub)
        {
            using (var context = new SEntities())
            {
                var nowy_s = new Siatkarze()
                {
                    Id = id,
                    Imie = imie,
                    Nazwisko = nazwisko,
                    Wiek = wiek,
                    Wzrost = wzrost,
                    Pozycja = pozycja,
                    Klub = klub
                };
            context.Siatkarze.Add(nowy_s);
            context.SaveChanges();
                return null;
             }
        }

        public CKlub AddKlub(string nazwa, int rok_zalozenia, string trener, string hala, string maskotka)
        {
            using (var context = new SEntities())
            {
                var nowy_k = new Klub()
                {
                    Nazwa = nazwa,
                    Rok_zalozenia = rok_zalozenia,
                    Trener = trener,
                    Hala = hala,
                    Maskotka = maskotka
                };
                context.Klub.Add(nowy_k);
                context.SaveChanges();
                return null;
            }
        }

        public CHala AddHala(string nazwah, string miasto, int liczba_miejsc)
        {
            using (var context = new SEntities())
            {
                var nowy_h = new Hala()
                {
                    Nazwa = nazwah,
                    Miasto = miasto,
                    Liczba_miejsc = liczba_miejsc
                };
                context.Hala.Add(nowy_h);
                context.SaveChanges();
                return null;
            }
        }

        public CSiatkarz DeleteSiatkarz(int id)
        {
            SEntities context = new SEntities();
            var Siatkarz = (from p in context.Siatkarze
                        where p.Id == id
                        select p).FirstOrDefault();
            if (Siatkarz != null)
            {

                context.Siatkarze.Remove(Siatkarz);
                context.SaveChanges();
                return null;
            }
            else
            {
                return null;
            }
        }

        public CKlub DeleteKlub(string nazwa)
        {
            SEntities context = new SEntities();
            var Klub = (from p in context.Klub
                        where p.Nazwa == nazwa
                        select p).FirstOrDefault();
            if (Klub != null)
            { 
                
                context.Klub.Remove(Klub);
                context.SaveChanges();
                return null;
            }
            else
            {
                return null; 
            }
        }

        public CHala DeleteHala(string nazwah)
        {
            SEntities context = new SEntities();
            var Hala = (from p in context.Hala
                        where p.Nazwa == nazwah
                        select p).FirstOrDefault();
            if ( Hala != null)
            {
                context.Hala.Remove(Hala);
                context.SaveChanges();
                return null;
            }
            else
            {
                return null;
            }
        }

        public CSiatkarz EditSiatkarz(int id)
        {
            throw new NotImplementedException();
        }

        public CKlub EditKlub(string nazwa)
        {
            throw new NotImplementedException();
        }

        public CHala EditHala(string nazwa)
        {
            throw new NotImplementedException();
        }


    }
}

    



