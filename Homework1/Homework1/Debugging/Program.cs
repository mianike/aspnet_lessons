using System.Text.Json;

var numbers = new Dictionary<int, string>
{
    {1, "one"},
    {2, "two"},
    {3, "three"},
    {4, "four"},
    {5, "five"}
};

string json = JsonSerializer.Serialize(numbers);
Console.WriteLine($"Serialized json: {json}");


Console.ReadLine();