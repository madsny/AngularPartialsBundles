using System.Collections.Generic;
using System.Text;
using System.Web.Optimization;

namespace AngularPartialsBundles
{
    public class TemplateCacheWriter
    {
        private readonly string _moduleName;
        private readonly List<KeyValuePair<string,string>> _partials;

        public TemplateCacheWriter(string moduleName)
        {
            _moduleName = moduleName;
            _partials = new List<KeyValuePair<string, string>>();
        }

        public void AddPartial(string filename, string fileContent)
        {
            _partials.Add(new KeyValuePair<string, string>(filename, fileContent));
        }

        public string WriteModule()
        {
            var sb = new StringBuilder();
            foreach (var partial in _partials)
            {
                sb.AppendLine(string.Format("$templateCache.put('{0}', '{1}');", partial.Key, partial.Value));
            }

            return string.Format("angular.module('{0}').run(['$templateCache', function($templateCache){{{1}}}]);", _moduleName, sb);
        }
    }
}