using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SampleService
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/GetdataJSON/{Searchid}")]
        List<clsListdata> GetdataJSON(string Searchid);

        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/PostdataJSON")]
        List<clsLeadDataSuccess> PostdataJSON(clsListdata p);
    }

    [DataContract]
    public class clsListdata
    {
        [DataMember]       
        public string ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string ErrorMessage { get; set; }

        [DataMember]
        public string imgString { get; set; }
    }
    [DataContract]
    public class clsLeadDataSuccess
    {
        [DataMember]
        public string ErrorMessage { get; set; }
        [DataMember]
        public string SuccessMessage { get; set; }
    }
    }
