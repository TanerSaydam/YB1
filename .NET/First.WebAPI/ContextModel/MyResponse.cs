namespace First.WebAPI.ContextModel;

public class MyResponse
{
    public List<Header> Headers { get; set; }
    public int StatusCode { get; set; }
    public object Body { get; set; }
}
