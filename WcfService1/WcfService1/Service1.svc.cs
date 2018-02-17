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
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CHala Gethala(CHala nazwah)
        {
            throw new NotImplementedException();
        }

        public CKLub GetKLub(CKLub nazwa)
        {
            throw new NotImplementedException();
        }

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
                    throw new Exception("Invalid product id");
        }
        private CSiatkarz TranslateSiatkarzeToCSiatkarz(Siatkarze Siatkarze)
        {
                CSiatkarz siatkarz = new CSiatkarz();
                siatkarz.id = Siatkarze.Id;
                return siatkarz;

        }
    }
}
