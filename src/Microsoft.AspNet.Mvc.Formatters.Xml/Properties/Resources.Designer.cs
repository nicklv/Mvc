// <auto-generated />
namespace Microsoft.AspNet.Mvc.Formatters.Xml
{
    using System.Globalization;
    using System.Reflection;
    using System.Resources;

    internal static class Resources
    {
        private static readonly ResourceManager _resourceManager
            = new ResourceManager("Microsoft.AspNet.Mvc.Formatters.Xml.Resources", typeof(Resources).GetTypeInfo().Assembly);

        /// <summary>
        /// The type must be an interface and must be or derive from '{0}'.
        /// </summary>
        internal static string EnumerableWrapperProvider_InvalidSourceEnumerableOfT
        {
            get { return GetString("EnumerableWrapperProvider_InvalidSourceEnumerableOfT"); }
        }

        /// <summary>
        /// The type must be an interface and must be or derive from '{0}'.
        /// </summary>
        internal static string FormatEnumerableWrapperProvider_InvalidSourceEnumerableOfT(object p0)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("EnumerableWrapperProvider_InvalidSourceEnumerableOfT"), p0);
        }

        /// <summary>
        /// {0} does not recognize '{1}', so instead use '{2}' with '{3}' set to '{4}' for value type property '{5}' on type '{6}'.
        /// </summary>
        internal static string RequiredProperty_MustHaveDataMemberRequired
        {
            get { return GetString("RequiredProperty_MustHaveDataMemberRequired"); }
        }

        /// <summary>
        /// {0} does not recognize '{1}', so instead use '{2}' with '{3}' set to '{4}' for value type property '{5}' on type '{6}'.
        /// </summary>
        internal static string FormatRequiredProperty_MustHaveDataMemberRequired(object p0, object p1, object p2, object p3, object p4, object p5, object p6)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("RequiredProperty_MustHaveDataMemberRequired"), p0, p1, p2, p3, p4, p5, p6);
        }

        /// <summary>
        /// The object to be wrapped must be of type '{0}' but was of type '{1}'.
        /// </summary>
        internal static string WrapperProvider_MismatchType
        {
            get { return GetString("WrapperProvider_MismatchType"); }
        }

        /// <summary>
        /// The object to be wrapped must be of type '{0}' but was of type '{1}'.
        /// </summary>
        internal static string FormatWrapperProvider_MismatchType(object p0, object p1)
        {
            return string.Format(CultureInfo.CurrentCulture, GetString("WrapperProvider_MismatchType"), p0, p1);
        }

        private static string GetString(string name, params string[] formatterNames)
        {
            var value = _resourceManager.GetString(name);

            System.Diagnostics.Debug.Assert(value != null);

            if (formatterNames != null)
            {
                for (var i = 0; i < formatterNames.Length; i++)
                {
                    value = value.Replace("{" + formatterNames[i] + "}", "{" + i + "}");
                }
            }

            return value;
        }
    }
}
