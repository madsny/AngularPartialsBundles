using System.Web.Optimization;

namespace AngularPartialsBundles.Example
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = true;

            bundles.Add(new ScriptBundle("~/bundles/lib")
                .Include("~/app/lib/angular.js")
                );
            bundles.Add(new ScriptBundle("~/bundles/app")
            .IncludeDirectory("~/app/js/", "*.js")
                );


            var angularTemplatesTransform = new AngularPartialsTransform("angularPartialsBundles");

            bundles.Add(new Bundle("~/bundles/partials", angularTemplatesTransform)
                .IncludeDirectory("~/app/partials/", "*.html", true)
                );

        }
    }
}