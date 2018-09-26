using System.IO;
using System.Net;
using SampleApp.Sources.generated.v3;

namespace SampleApp.Sources.democlient.rest
{
    public static class WebResponseExtensions
    {
        public static string GetBody(this WebResponse webResponse)
        {
            var responseStream = webResponse.GetResponseStream();
            if (responseStream == null)
                return null;
            
            using (var reader = new StreamReader(responseStream))
            {
                return reader.ReadToEnd();
            }
        }

        public static CollectionPage<T> GetResponsePage<T>(this WebResponse webResponse)
        {
            var payload = webResponse.GetBody();
            var jsonSerializer = new Serializer();

            return jsonSerializer.Deserialize<CollectionPage<T>>(payload);
        }
    }
}