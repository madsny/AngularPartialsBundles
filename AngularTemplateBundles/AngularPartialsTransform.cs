using System.Web.Optimization;

namespace AngularPartialsBundles
{
    public class AngularPartialsTransform : IBundleTransform
    {
        private readonly string _moduleName;
        private readonly IBundleTransform _nextTransform;

        public AngularPartialsTransform(string moduleName, IBundleTransform nextTransform = null)
        {
            _moduleName = moduleName;
            _nextTransform = nextTransform ?? new JsMinify();

            RemoveLeadingSlash = false;
        }

        public bool RemoveLeadingSlash { get; set; }


        public void Process(BundleContext context, BundleResponse response)
        {
            if (!context.EnableOptimizations)
                return;

            var templateWriter = new TemplateCacheWriter(_moduleName);
            var templateContentReader = new PartialContentReader(RemoveLeadingSlash);
            foreach (var bundleFile in response.Files)
            {
                templateWriter.AddPartial(templateContentReader.GetName(bundleFile), templateContentReader.Read(bundleFile));
            }

            response.ContentType = "text/javascript";
            response.Content = templateWriter.WriteModule();

            _nextTransform.Process(context, response);

        }
    }
}
