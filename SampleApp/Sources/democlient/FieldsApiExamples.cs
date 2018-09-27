using System.Collections.Generic;
using System.Linq;
using SampleApp.Sources.generated.v3;

namespace SampleApp.Sources.democlient
{
    public class FieldsApiExamples
    {
        private readonly ApiClient _apiClient;

        public FieldsApiExamples(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public void MakeFieldsApiCalls(List<Organization> organizations)
        {
            // One way to check whether you can access Fields for a given Organization is to look for a HATEOAS link.
            // Alternately, you could skip the links and make a call to /organization/{orgId}/fields. If you get an HTTP 403 back, you don't have access.
            var orgsWithFieldAccess = organizations.Where(org => org.links.Any(link => link.rel == LinkRel.fields.ToString()));
            foreach (var organization in orgsWithFieldAccess)
            {
                GetFieldsForOrganization(organization);
            }
        }

        private void GetFieldsForOrganization(Organization organization)
        {
            var fieldsUri = organization.links.Single(link => link.rel == LinkRel.fields.ToString()).uri;
            // Simply gets a list of Fields for this organization
            var fields = _apiClient.GetAllUsingPagination<Field>(fieldsUri);
            // Get a list of Fields with their associated Clients and Farms
            var fieldsWithClientAndFarmEmbedded = _apiClient.GetAllUsingPagination<Field>(fieldsUri, new Dictionary<string, string> {{"embed", "clients,farms"}});
            // Get a list of Fields with their associated Boundaries
            var fieldsWithActiveBoundaryEmbedded = _apiClient.GetAllUsingPagination<Field>(fieldsUri, new Dictionary<string, string> {{"embed", "boundaries"}});
        }
    }
}
