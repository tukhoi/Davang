using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

namespace Davang.ErrorStore
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IErrorStoreService" in both code and config file together.
    [ServiceContract]
    public interface IErrorStoreService
    {
        //[OperationContract]
        //[WebGet(UriTemplate="/collect?errorTime={errorTime}&message={message}&type={type}&source={source}&details={details}&appMemoryUsage={appMemoryUsage}&appMemoryLimit={appMemoryLimit}&deviceMemory={deviceMemory}&firmwareVerions={firmwareVersion}&hardwareVersion={hardwareVersion}&manufacturer={manufacturer}&name={name}")]
        //void Collect(string errorTime, string message, string type, string source, string details, 
        //    long appMemoryUsage, long appMemoryLimit, long deviceMemory, string firmwareVersion, string hardwareVersion,
        //    string manufacturer, string name);

        [OperationContract]
        [WebInvoke(UriTemplate="/test/", Method="GET")]
        string Test();
    }
}
