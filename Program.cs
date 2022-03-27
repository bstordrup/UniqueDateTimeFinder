// See https://aka.ms/new-console-template for more information
Dictionary<int, int> DaysInMonth = new Dictionary<int, int>
{
    [1] = 31,
    [2] = 29,
    [3] = 31,
    [4] = 30,
    [5] = 31,
    [6] = 30,
    [7] = 31,
    [8] = 31,
    [9] = 30,
    [10] = 31,
    [11] = 30,
    [12] = 31
};


Console.WriteLine("Søger digitalur visninger med unikke tal");
var sw = new System.Diagnostics.Stopwatch();
sw.Start();
var dateTimeStrings = FindUniqueDateTimeStrings().ToList();
var firstUnique = dateTimeStrings.First();
var lastUnique = dateTimeStrings.Last();
sw.Stop();

var elapsed = sw.ElapsedMilliseconds;

Console.WriteLine($"Første med unikke tal: {firstUnique}");
Console.WriteLine($"Sidste med unikke tal: {lastUnique}");

Console.WriteLine($"Antal med unikke tal : {dateTimeStrings.Count}");
Console.WriteLine($"Tidsforbrug: {elapsed} ms.");

// Console.WriteLine("Alle med unikke tal:");
// foreach (var dts in dateTimeStrings)
// {
//     Console.WriteLine(dts);
// }

Console.Write("Press any key...");
Console.ReadKey(true);



bool IsUniqueDateTimeStr(string dateTimeStr) => dateTimeStr.ToArray().Distinct().ToList().Count == 10;

IEnumerable<string> FindUniqueDateTimeStrings()
{
    for (int month = 1; month <= 12; month++)
    {
        for (int day = 1; day <= DaysInMonth[month]; day++)
        {
            for (int hour = 0; hour <= 23; hour++)
            {
                for (int minute = 0; minute <= 59; minute++)
                {
                    for (int second = 0; second <= 59; second++)
                    {
                        var dateTimeStr = $"{day:00}{month:00}{hour:00}{minute:00}{second:00}";
                        if (IsUniqueDateTimeStr(dateTimeStr))
                            yield return $"{day:00}/{month:00} {hour:00}:{minute:00}:{second:00}";
                    }
                }
            }
        }
    }
}
