using System.Collections.Generic;
using System.Linq;
using SampleApp.Sources.generated.v3;

namespace SampleApp.Sources.democlient
{
    public class FieldOperationsApiExamples
    {
        private readonly ApiClient _apiClient;

        public FieldOperationsApiExamples(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public void MakeFieldOperationsApiCalls(List<Field> fields)
        {
            var fieldsWithFieldOperationsAccess = fields.Where(field => field.links.Any(link => link.rel == LinkRel.fieldOperation.ToString()));
            foreach (var field in fieldsWithFieldOperationsAccess)
            {
                GetFieldOperationsForField(field);
            }
        }

        private void GetFieldOperationsForField(Field field)
        {
            var fieldOperationUrl = field.links.Single(link => link.rel == LinkRel.fieldOperation.ToString()).uri;
            // Please don't do this. It may return a huge amount of data and will be very slow:
            var allFieldOperations = _apiClient.GetAllUsingPagination<FieldOperation>(fieldOperationUrl);
            // Better: Filter by crop season
            var fieldOperations2019 = _apiClient.GetAllUsingPagination<FieldOperation>(fieldOperationUrl, 
                new Dictionary<string, string> {{"cropSeason", "2019"}});
            // If your application only needs data for specific operations, you can improve performance by adding another filter.
            // Accepted values: See https://developer.deere.com/#!documentation&doc=.%2Fmyjohndeere%2FfieldOperations.htm&anchor=one
            var seedingOperations2019 = _apiClient.GetAllUsingPagination<FieldOperation>(fieldOperationUrl,
                new Dictionary<string, string> {{"cropSeason", "2019"}, {"fieldOperationType", "SEEDING"}});
        }
    }
}