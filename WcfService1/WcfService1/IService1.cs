using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "json/{id}")]
        CSiatkarz GetSiatkarz (int id);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "json/{id}")]
        CKlub GetKlub (string nazwa);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "json/{id}")]
        CHala GetHala (string nazwah);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "json/{id}")]
        CSiatkarz AddSiatkarz(int id, string imie, string nazwisko, int wiek, int wzrost, string pozycja, string klub);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "json/{id}")]
        CKlub AddKlub(string nazwa, int rok_zalozenia, string trener, string hala, string maskotka);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "json/{id}")]
        CHala AddHala(string nazwah, string miasto, int liczba_miejsc);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "json/{id}")]
        void DeleteSiatkarz (int id);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "json/{id}")]
        void EditSiatkarz (int id, int wiek, int wzrost, string pozycja, string klub);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "json/{id}")]
        void EditKlub (string nazwa, string trener, string hala, string maskotka);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "json/{id}")]
        void EditHala (string nazwah, int liczba_miejsc);

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
    public class CKlub
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
