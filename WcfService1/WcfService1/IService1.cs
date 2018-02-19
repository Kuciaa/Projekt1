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
          BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "slist")]
        string GetSList();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "klist")]
        string GetKList();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "hlist")]
        string GetHList();
        /*
         [OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
         //   BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "json/{id}")]
        CSiatkarz GetSiatkarz (int id);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "json/{nazwa}")]
        string GetKlub (string nazwa);

        [OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
        //    BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "json/{nazwah}")]
        CHala GetHala (string nazwah);

        */
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "addsiatkarz?id={ids}&imie={imie}&nazwisko={nazwisko}&wiek={wieks}&wzrost={wzrosts}&pozycja={pozycja}&klub={klub}")]
        string AddSiatkarz(string ids, string imie, string nazwisko, string wieks, string wzrosts, string pozycja, string klub);
        
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "addklub?nazwa={nazwa}&rok_zalozenia={rok_zalozenias}&trener={trener}&hala={hala}&maskotka={maskotka}")]
        string AddKlub(string nazwa, string rok_zalozenias, string trener, string hala, string maskotka);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "addhala?nazwah={nazwah}&miasto={miasto}&liczba_miejsc={liczba_miejscs}")]
        string AddHala(string nazwah, string miasto, string liczba_miejscs);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "editsiatkarz?id={ids}&wiek={wieks}&wzrost={wzrosts}&pozycja={pozycja}&klub={klub}")]
        void EditSiatkarz(string ids, string wieks, string wzrosts, string pozycja, string klub);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "editklub?nazwa={nazwa}&trener={trener}&hala={hala}&maskotka={maskotka}")]
        void EditKlub(string nazwa, string trener, string hala, string maskotka);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "edithala?nazwah={nazwah}&liczba_miejsc={liczba_miejscs}")]
        void EditHala(string nazwah, string liczba_miejscs);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "deletesiatkarz/{f}")]
        void DeleteSiatkarz(string f);

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
