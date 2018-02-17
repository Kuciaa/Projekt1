using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    // UWAGA: możesz użyć polecenia „Zmień nazwę” w menu „Refaktoryzuj”, aby zmienić nazwę interfejsu „IService1” w kodzie i pliku konfiguracji.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CSiatkarz GetSiatkarz (int id);

        [OperationContract]
        CKLub GetKLub (string nazwa);

        [OperationContract]
        CHala Gethala (string nazwah);

        // TODO: dodaj tutaj operacje usługi
    }


    // Użyj kontraktu danych, jak pokazano w poniższym przykładzie, aby dodać typy złożone do operacji usługi.
    [DataContract]
    public class CSiatkarz
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string imie { get; set; }
        [DataMember]
        public string nazwisko { get; set; }
        [DataMember]
        public int wiek { get; set; }
        [DataMember]
        public int wzrost { get; set; }
        [DataMember]
        public string pozycja { get; set; }
        [DataMember]
        public string klub { get; set; }
    }

    [DataContract]
    public class CKLub
    {
        [DataMember]
        public string nazwa { get; set; }
        [DataMember]
        public int rok_zalozenia { get; set; }
        [DataMember]
        public string trener { get; set; }
        [DataMember]
        public string hala { get; set; }
        [DataMember]
        public string maskotka { get; set; }
    }

    [DataContract]
    public class CHala
    {
        [DataMember]
        public string nazwah { get; set; }
        [DataMember]
        public string miasto { get; set; }
        [DataMember]
        public int liczba_miejsc { get; set; }
    }

}
