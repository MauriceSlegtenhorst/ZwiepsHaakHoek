using Contentful.Core;
using Contentful.Core.Configuration;
using Contentful.Core.Models;

namespace ZwiepsHaakHoek.Extensions.ServiceCollection
{
    public static class ContentfulServiceExtension
    {
        public static void AddContentfulServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Ye ye, I know this is not secure... who cares
            services.AddTransient<IContentfulClient, ContentfulClient>(
                sp => new ContentfulClient(
                    new HttpClient(),
                    new ContentfulOptions
                    {
                        DeliveryApiKey = "HEZwVKQRiik5yRzucCp10c0_B9j3Imj9qdPcwf3Ni3I",
                        PreviewApiKey = "seqY0EqzSOyqTu9xU1M-29eLhNkItEBAglBk-b9Arfc",
                        UsePreviewApi = false,
                        SpaceId = "0j1qh6rkj1g8"
                    }
                )
            );

            services.AddTransient(sp => new HtmlRenderer());
        }
    }
}
