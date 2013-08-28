using System;
using System.IO;
using System.Web;
using System.Web.Optimization;

namespace AngularPartialsBundles
{
    public class PartialContentReader
    {
        private readonly bool _removeLeadingSlash;

        public PartialContentReader(bool removeLeadingSlash)
        {
            _removeLeadingSlash = removeLeadingSlash;
        }

        public string Read(BundleFile bundleFile)
        {
            var contentRaw = File.ReadAllText(HttpContext.Current.Server.MapPath(bundleFile.VirtualFile.VirtualPath));

            return contentRaw.Replace(Environment.NewLine, "\\n").Replace("'", "''");
        }

        public string GetName(BundleFile bundleFile)
        {
            var name = bundleFile.VirtualFile.VirtualPath;
            if (_removeLeadingSlash && name.StartsWith("/"))
            {
                return name.Substring(1);
            }
            return name;
        }
    }
}