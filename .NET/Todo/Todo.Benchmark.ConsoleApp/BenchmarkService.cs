using BenchmarkDotNet.Attributes;
using Microsoft.EntityFrameworkCore;
using Todo.Benchmark.ConsoleApp.Context;

namespace Todo.Benchmark.ConsoleApp;
public class BenchmarkService
{
    ApplicationDbContext context = new();

    [Benchmark(Baseline = true)]
    public void GetAll()
    {
        context.Todos.ToList();
    }

    [Benchmark]
    public void GetAllWithAsNoTracking()
    {
        context.Todos.AsNoTracking().ToList();
    }

}
