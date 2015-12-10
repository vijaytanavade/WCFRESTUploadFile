using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFUploadService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUploadFileService" in both code and config file together.
    [ServiceContract]
    public interface IUploadFileService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        bool UploadFile(Stream file);
    }
}
