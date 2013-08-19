using System.Web;
using System.Web.Optimization;

namespace AngularPartialsBundles
{
    public static class AngularPartials
    {
        public static IHtmlString Render(string path)
        {
            if (BundleTable.EnableOptimizations)
                return Scripts.Render(path);
            return null;
        }
    }
}
