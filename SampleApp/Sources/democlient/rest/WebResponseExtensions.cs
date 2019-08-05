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
            var responseStream = webResponse?.GetResponseStream();
            if (responseStream == null)
                return null;

            // The response is usually gzip-compressed since we always set an Accept-Encoding of gzip on RestRequest's
            if (webResponse.Headers.Get("Content-Encoding").ToLower().Contains("gzip"))
            {
                using (var gzipStream = new GZipStream(responseStream, CompressionMode.Decompress))
                {
                    using (var reader = new StreamReader(gzipStream))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
            // If the response wasn't gzip-compressed, just read and return the result.
            using (var reader = new StreamReader(responseStream))
            {
                return reader.ReadToEnd();
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
            var collectionPage = JsonSerializer.Deserialize<CollectionPage<T>>(payload);

            return collectionPage.values;
        }

        public static T GetResponseAsObject<T>(this HttpWebResponse webResponse)
        {
            var payload = webResponse.GetBody();

            return JsonSerializer.Deserialize<T>(payload);
        }
    }
}