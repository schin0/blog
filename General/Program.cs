using General.Replaces;

# region Reflection tests
Console.WriteLine("Start Reflection tests");

var example = new EventExample
{
    Id = 42,
    Name = "Demo Event",
    Date = DateTime.UtcNow,
    Total = 99.95m
};

var template = "Id: --ID--, Name: --NAME--, Date: --DATE--, Total: --TOTAL--";
var result = EngineService.Process(template, example);

Console.WriteLine("Processed template:");
Console.WriteLine(result);

Console.WriteLine();
Console.WriteLine("Available keys:");
foreach (var k in PropertyCache<EventExample>.AvailableKeys)
{
    Console.WriteLine(k);
}

if (PropertyCache<EventExample>.TryGetValue(example, "--NAME--", out var nameValue))
{
    Console.WriteLine();
    Console.WriteLine($"TryGetValue for --NAME-- => \"{nameValue}\"");
}
else
{
    Console.WriteLine("Key not found");
}
#endregion
