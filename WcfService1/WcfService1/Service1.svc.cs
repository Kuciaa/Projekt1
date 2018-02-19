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
        public string GetSList()
        {
            SEntities context = new SEntities();
            var S = (from p in context.Siatkarze
                                 select p).ToList();
            List<Siatkarze> lstSReturn = new List<Siatkarze>();
            foreach (Siatkarze item in S)
            {
                lstSReturn.Add(item);
            }
            string wynik = "";
            foreach (Siatkarze s in lstSReturn)
            {
                wynik += s.Id;
                wynik += "|" + s.Imie;
                wynik += "|" + s.Nazwisko;
                wynik += "|" + s.Wiek;
                wynik += "|" + s.Wzrost;
                wynik += "|" + s.Pozycja;
                wynik += "|" + s.Klub + "#";
            }
            return wynik;
        }

        public string GetKList()
        {
            SEntities context = new SEntities();
            var K = (from p in context.Klub
                     select p).ToList();
            List<Klub> lstKReturn = new List<Klub>();
            foreach (Klub item in K)
            {
                lstKReturn.Add(item);
            }
            string wynik = "";
            foreach (Klub k in lstKReturn)
            {
                wynik += k.Nazwa;
                wynik += "|" + k.Rok_zalozenia;
                wynik += "|" + k.Trener;
                wynik += "|" + k.Hala;
                wynik += "|" + k.Maskotka + "#";
            }
            return wynik;
        }

        public string GetHList()
        {
            SEntities context = new SEntities();
            var H = (from p in context.Hala
                     select p).ToList();
            List<Hala> lstHReturn = new List<Hala>();
            foreach (Hala item in H)
            {
                lstHReturn.Add(item);
            }
            string wynik = "";
            foreach (Hala h in lstHReturn)
            {
                wynik += h.Nazwa;
                wynik += "|" + h.Miasto;
                wynik += "|" + h.Liczba_miejsc+ "#";
            }
            return wynik;
        }

        /*
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

        public string GetKlub(string nazwa)
        {
            SEntities context = new SEntities();
            var Klub = (from p in context.Klub
                        where p.Nazwa == nazwa
                        select p).FirstOrDefault();
            //if (Klub != null)
                return "ok";
               // return TranslateKlubToCKlub(Klub);
           // else
            //{
            //    return null;
           // }
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
        */
        public string AddSiatkarz(string ids, string imie, string nazwisko, string wieks, string wzrosts, string pozycja, string klub)
        {
            int id = Int32.Parse(ids);
            int wiek = Int32.Parse(wieks);
            int wzrost = Int32.Parse(wzrosts);
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

                CSiatkarz siatkarz = new CSiatkarz();
                siatkarz.id = nowy_s.Id;
                siatkarz.imie = nowy_s.Imie;
                siatkarz.nazwisko = nowy_s.Nazwisko;
                siatkarz.wiek = (int)nowy_s.Wiek;
                siatkarz.wzrost = (int)nowy_s.Wzrost;
                siatkarz.pozycja = nowy_s.Pozycja;
                siatkarz.klub = nowy_s.Klub;
                return siatkarz.id.ToString();
            }
        }

        public string AddKlub(string nazwa, string rok_zalozenias, string trener, string hala, string maskotka)
        {
            int rok_zalozenia = Int32.Parse(rok_zalozenias);
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

                CKlub klub = new CKlub();
                klub.nazwa = nowy_k.Nazwa;
                klub.rok_zalozenia = (int)nowy_k.Rok_zalozenia;
                klub.trener = nowy_k.Trener;
                klub.hala = nowy_k.Hala;
                klub.maskotka = nowy_k.Maskotka;
                return klub.nazwa.ToString();
            }
        }

        public string AddHala(string nazwah, string miasto, string liczba_miejscs)
        {
            int liczba_miejsc = Int32.Parse(liczba_miejscs);
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

                CHala hala = new CHala();
                hala.nazwah = nowy_h.Nazwa;
                hala.miasto = nowy_h.Miasto;
                hala.liczba_miejsc = (int)nowy_h.Liczba_miejsc;
                return hala.nazwah.ToString();
            }
        }

        public void EditSiatkarz(string ids, string wieks, string wzrosts, string pozycja, string klub)
        {
            int id = Int32.Parse(ids);
            int wiek = Int32.Parse(wieks);
            int wzrost = Int32.Parse(wzrosts);
            SEntities context = new SEntities();
            var Siatkarze = (from p
                                 in context.Siatkarze
                             where p.Id == id
                             select p).FirstOrDefault();
            if (Siatkarze != null)
            {
                if (wiek == 0)
                {
                    Siatkarze.Wiek = Siatkarze.Wiek;
                }
                else Siatkarze.Wiek = wiek;

                if (wzrost == 0)
                {
                    Siatkarze.Wzrost = Siatkarze.Wzrost;
                }
                else Siatkarze.Wzrost = wzrost;

                if (pozycja == null)
                {
                    Siatkarze.Pozycja = Siatkarze.Pozycja;
                }
                else Siatkarze.Pozycja = pozycja;

                if (klub == null)
                {
                    Siatkarze.Klub = Siatkarze.Klub;
                }
                else Siatkarze.Klub = klub;
            }
            context.SaveChanges();
        }

        public void EditKlub(string nazwa, string trener, string hala, string maskotka)
        {
            SEntities context = new SEntities();
            var Klub = (from p in context.Klub
                        where p.Nazwa == nazwa
                        select p).FirstOrDefault();
            if (Klub != null)
            {
                if (trener == null)
                {
                    Klub.Trener = Klub.Trener;
                }
                else Klub.Trener = trener;

                if (hala == null)
                {
                    Klub.Hala = Klub.Hala;
                }
                else Klub.Hala = hala;

                if (maskotka == null)
                {
                    Klub.Maskotka = Klub.Maskotka;
                }
                else Klub.Maskotka = maskotka;
            }
            context.SaveChanges();

        }

        public void EditHala(string nazwah, string liczba_miejscs)
        {
            int liczba_miejsc = Int32.Parse(liczba_miejscs);
            SEntities context = new SEntities();
            var Hala = (from p in context.Hala
                        where p.Nazwa == nazwah
                        select p).FirstOrDefault();
            if (Hala != null)
            {
                if (liczba_miejsc == 0)
                {
                    Hala.Liczba_miejsc = Hala.Liczba_miejsc;
                }
                else Hala.Liczba_miejsc = liczba_miejsc;
            }
            context.SaveChanges();
        }



        public void DeleteSiatkarz(string f)
        {
            int id = Int32.Parse(f);
            SEntities context = new SEntities();
            var Siatkarz = (from p in context.Siatkarze
                            where p.Id == id
                            select p).FirstOrDefault();
            if (Siatkarz != null)
            {

                context.Siatkarze.Remove(Siatkarz);
                context.SaveChanges();
            }
        }




    }
}

    



