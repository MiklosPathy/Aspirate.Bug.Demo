using Aspire.Hosting;
using Aspire.Hosting.ApplicationModel;

namespace MyabiDigital.XlmRoberta.Hosting{
    public static class RobertaResourceBuilderExtensions
    {
        public static IResourceBuilder<RobertaResource> AddRoberta(
            this IDistributedApplicationBuilder builder,
            string name,
            int? httpPort = null)
        {
            // The AddResource method is a core API within .NET Aspire and is
            // used by resource developers to wrap a custom resource in an
            // IResourceBuilder<T> instance. Extension methods to customize
            // the resource (if any exist) target the builder interface.
            var resource = new RobertaResource(name);

            return builder.AddResource(resource)
                          .WithImage(RobertaContainerImageTags.Image)
                          .WithImageRegistry(RobertaContainerImageTags.Registry)
                          .WithImageTag(RobertaContainerImageTags.Tag)
                          .WithDockerfile("robertaexposed")
                          .WithHttpEndpoint(
                              targetPort: RobertaResource.RobertaInnerPort,
                              port: httpPort,
                              name: RobertaResource.HttpEndpointName)
                          ;
        }
    }

    internal static class RobertaContainerImageTags
    {
        internal const string Registry = "docker.io";
        internal const string Image = "miyabidigital/multilingual-e5-large";
        internal const string Tag = "latest";
    }
}
