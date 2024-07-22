using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/todoitems", async () =>
{
    var list = new List<Todo>();
    var item1 = new Todo()
    {
        Id = 1,
        Name ="test",
        IsComplete = true
    };

    list.Add(item1);
    var item2 = new Todo()
    {
        Id = 2,
        Name = "abc",
        IsComplete = false
    };
    list.Add(item2);

    return list;
});

app.MapGet("/todoitems/{id}", async (int id) =>
{
    var list = new List<Todo>();
    var item1 = new Todo()
    {
        Id = 1,
        Name = "test",
        IsComplete = true
    };

    list.Add(item1);
    var item2 = new Todo()
    {
        Id = 2,
        Name = "abc",
        IsComplete = false
    };
    list.Add(item2);

    return list.FirstOrDefault(x => x.Id == id) is Todo todo ? Results.Ok(todo) : Results.NotFound();

});

app.Run();
