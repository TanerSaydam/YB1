using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.QueryDsl;
using PersonelYonetim.WebAPI.Models;

namespace PersonelYonetim.WebAPI.Repositories;

public sealed class EmployeeElasticSearchRepository : IEmployeeRepository
{
    private readonly ElasticsearchClient client;
    public EmployeeElasticSearchRepository()
    {
        ElasticsearchClientSettings settings = new(new Uri("http://localhost:9200"));
        settings.DefaultIndex("employees");
        client = new(settings);

        IndexRequest<Employee> indexRequest = new("employees");
        client.IndexAsync(indexRequest).Wait();
    }
    public void Create(Employee employee)
    {
        CreateRequest<Employee> createRequest = new("employees", employee.Id)
        {
            Document = employee
        };
        client.CreateAsync(createRequest).Wait();
    }

    public void Delete(Employee employee)
    {
        client.DeleteAsync<Employee>("employees", employee.Id).Wait();
    }

    public List<Employee> GetAll()
    {
        SearchRequest searchRequest = new(Indices.Index("employees"))
        {
            Size = 10000,
            Query = new MatchAllQuery()
        };
        SearchResponse<Employee> searchResponse =
            client.SearchAsync<Employee>(searchRequest).GetAwaiter().GetResult();

        return searchResponse.Documents.ToList();
    }

    public Employee? GetById(string id)
    {
        SearchRequest searchRequest = new(Indices.Index("employees"))
        {
            Size = 1,
            Query = new MatchQuery(new Field("id"))
            {
                Query = id
            }
        };
        SearchResponse<Employee> searchResponse = client.SearchAsync<Employee>(searchRequest).GetAwaiter().GetResult();
        return searchResponse.Documents.FirstOrDefault();
    }

    public void Update(Employee employee)
    {
        UpdateRequest<Employee, Employee> updateRequest = new("employees", employee.Id)
        {
            Doc = employee
        };
        client.UpdateAsync(updateRequest).Wait();
    }
}
