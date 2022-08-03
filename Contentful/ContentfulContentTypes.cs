using Contentful.Core.Models;
using ZwiepsHaakHoek.Models.Contentful;

namespace ZwiepsHaakHoek.Contentful
{
    public class ContentfulContentTypes
    {
        public const string LANGUAGE_ICON = "language-icon";
        public const string INDEX = "home";
        public const string PRODUCT = "product";
        public const string PRODUCTS = "products";

        public static string GetContentTypeName<TContentType>() where TContentType : ContentType 
            => typeof(TContentType) switch
        {
            _ when typeof(TContentType) == typeof(CFLanguageIcon) => LANGUAGE_ICON,
            _ when typeof(TContentType) == typeof(CFIndex) => INDEX,
            _ when typeof(TContentType) == typeof(CFProduct) => PRODUCT,
            _ => throw new KeyNotFoundException($"No ContentType found for key: \"{ nameof(TContentType) }\"."),
        };
    }
}
