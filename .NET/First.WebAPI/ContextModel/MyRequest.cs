namespace First.WebAPI.ContextModel;

public class MyRequest
{
    public List<Header> Headers { get; set; }
    public string Url { get; set; }
    public List<QueryParam> QueryParams { get; set; }
    public List<RouteParam> RouteParams { get; set; }
    public object Body { get; set; }
}
