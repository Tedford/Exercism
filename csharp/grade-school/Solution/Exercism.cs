using System.Collections.Generic;
using System.Linq;

public class School
{
    public IList<IEnumerable<string>> Roster { get; private set; } = new List<IEnumerable<string>>{};

    public void Add(string student, int grade)
    {
        if (!Roster.Any())
        {
            Enumerable.Range(0, 9).ToList().ForEach(i=> Roster.Add(Enumerable.Empty<string>()));
        }
        Roster[grade] = Roster[grade].Union(new[] { student }).OrderBy(i=>i);
    }

    public IEnumerable<string> Grade(int grade) => Roster.ElementAtOrDefault(grade) ?? Enumerable.Empty<string>();
}