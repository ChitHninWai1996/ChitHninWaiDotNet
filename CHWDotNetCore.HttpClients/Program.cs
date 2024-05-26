using Newtonsoft.Json;

Console.WriteLine("Hello, World!");
string jsonStr = await File.ReadAllTextAsync("MyanmarMonths.json");
var model = JsonConvert.DeserializeObject<MainDto>(jsonStr);

Console.WriteLine(jsonStr);
foreach (var month in model.Tbl_Months)
{
    Console.WriteLine(month.Id);
}

Console.ReadLine();


public class MainDto
{
    public Tbl_Months[] Tbl_Months { get; set; }
}

public class Tbl_Months
{
    public int Id { get; set; }
    public string MonthMm { get; set; }
    public string MonthEn { get; set; }
    public string FestivalMm { get; set; }
    public string FestivalEn { get; set; }
    public string Description { get; set; }
    public string Detail { get; set; }
}

