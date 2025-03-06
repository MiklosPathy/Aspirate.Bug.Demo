using Aspire.Hosting;
using Aspire.Hosting.ApplicationModel;

namespace MyabiDigital.XlmRoberta.Hosting
{
    public sealed class RobertaResource(string name) : ContainerResource(name), IResourceWithServiceDiscovery
    {
        internal const string HttpEndpointName = "http";
        internal const int RobertaInnerPort = 8080;
        internal const int RobertaOuterPort = 7080;
    }
}
