using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SampleApp.Sources.generated.v3;
using File = SampleApp.Sources.generated.v3.File;

namespace SampleApp.Sources.democlient
{
    public class FilesApiExamples
    {
        private readonly ApiClient _apiClient;

        public FilesApiExamples(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public void MakeFilesApiCalls(List<Organization> organizations)
        {
            // Deere Etags are useful if you want to regularly poll for new or updated data. They let you download a list of new data since your last
            // request, instead of re-downloading the entire list every time.
            // See https://developer.deere.com/#!documentation&doc=.%2Fmyjohndeere%2FdeereTags.htm
            GetAllFilesUsingDetags(organizations);

            UploadNewFileToOrganization(organizations.First());
        }

        private void GetAllFilesUsingDetags(IEnumerable<Organization> organizations)
        {
            foreach (var org in organizations)
            {
                var filesApiUrl = org.links.SingleOrDefault(link => link.rel == LinkRel.files.ToString())?.uri;
                if (filesApiUrl == null)
                    continue;

                // The first time, we don't have a Deere ETag value. Pass null -- it will return the entire list without pagination, and give you an ETag
                var filesResult = _apiClient.GetListUsingDetag<File>(filesApiUrl, null);

                // Save this Deere ETag value. It is tied to this URI (which also means it is specific to this Organization). You can use it later in order
                // to only receive data that is new or modified since you last made this call, instead of having to download the entire list again.
                var detagValue = filesResult.Item1;
                var allFilesForOrganization = filesResult.Item2;

                // This call will probably return an HTTP 304 (Not Modified), generating an empty list. It will only return data that was created or modified 
                // since your last call.
                var newFilesSinceLastApiCall = _apiClient.GetListUsingDetag<File>(filesApiUrl, detagValue).Item2;
            }
        }

        private void UploadNewFileToOrganization(Organization organization)
        {
            var filesApiUrl = organization.links.SingleOrDefault(link => link.rel == LinkRel.files.ToString())?.uri;
            if (filesApiUrl == null)
                return;
            var file = new File {name = "GS3 - 2630 Setup Data.zip"};
            var fileUrl = _apiClient.PostNewObject(filesApiUrl, file);

            var sampleFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "GS3 - 2630 Setup Data.zip");
            var fileContents = System.IO.File.ReadAllBytes(sampleFilePath);
            _apiClient.PutBinaryPayload(fileUrl, fileContents);
        }
    }
}
