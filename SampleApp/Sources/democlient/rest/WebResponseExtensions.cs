using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using SampleApp.Sources.generated.v3;

namespace SampleApp.Sources.democlient.rest
{
    public static class WebResponseExtensions
    {
        private static readonly Serializer JsonSerializer = new Serializer();

        public static string GetBody(this HttpWebResponse webResponse)
        {
            var responseStream = webResponse.GetResponseStream();
            if (responseStream == null)
                return null;

            using (var gzipStream = new GZipStream(responseStream, CompressionMode.Decompress))
            {
                using (var reader = new StreamReader(gzipStream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        public static CollectionPage<T> GetResponsePage<T>(this HttpWebResponse webResponse)
        {
            var payload = webResponse.GetBody();

            return JsonSerializer.Deserialize<CollectionPage<T>>(payload);
        }

        public static List<T> GetResponseAsList<T>(this HttpWebResponse webResponse)
        {
            var payload = webResponse.GetBody();

            return JsonSerializer.Deserialize<List<T>>(payload);
        }

        public static T GetResponseAsObject<T>(this HttpWebResponse webResponse)
        {
            var payload = webResponse.GetBody();

            return JsonSerializer.Deserialize<T>(payload);
        }
    }
}