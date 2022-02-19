using Contentful.Core;
using Contentful.Core.Configuration;

namespace ZwiepsHaakHoek.Extensions
{
    public static class ServicesExtension
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Ye ye, I know this is not secure... who cares
            services.AddTransient<IContentfulClient, ContentfulClient>(
                sp =>  new ContentfulClient(
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
        }
    }
}
