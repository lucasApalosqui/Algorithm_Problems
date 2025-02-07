using System;
using System.Globalization;
using System.Linq;
//Console.WriteLine(HighSchoolSweethearts.DisplayGermanExchangeStudents("Norbert", "Heidi", new DateTime(2019, 1, 22), 1535.22f));
public static class HighSchoolSweethearts
{
    public static string DisplaySingleLine(string studentA, string studentB)
    {
        string str = $"{studentA} ♡ {studentB}";
        return CentralizeStr(str, '♡');
    }

    public static string DisplayBanner(string studentA, string studentB)
    {
        return $@"
{DoHeartLines("     ******   ", ' ', 5)}
{DoHeartLines("   **      ** ", ' ', 3)}
{DoHeartLines(" **         **", ' ', 1)}
{DoHeartLines("**            ", '*', 0)}
{DoHeartLines("**            ", ' ', 0)}
{DoHeartCenterLine("**            ", '+', studentA, studentB)}
{DoHeartLines(" **           ", ' ', 1)}
{DoHeartLines("   **         ", ' ', 3)}
{DoHeartLines("     **       ", ' ', 5)}
{DoHeartLines("       **     ", ' ', 7)}
{DoHeartLines("         **   ", ' ', 9)}
{DoHeartLines("           ** ", ' ', 11)}
{DoHeartLines("             *", '*', 13)}
{DoHeartLines("              ", '*', 14)}";
    }

    public static string DisplayGermanExchangeStudents(string studentA
        , string studentB, DateTime start, float hours)
    {
        return $"{studentA} and {studentB} have been dating since {start.ToString("dd.MM.yyyy")} - that's {hours.ToString("N2", new CultureInfo("pt-BR"))} hours";
    }


    //Utils
    private static string CentralizeStr(string str, char symbol)
    {
        var strNew = str.Split(symbol);
        int left = 30 - strNew[0].Length;
        int right = 30 - strNew[1].Length;
        return $"{new string(' ', left)}{str}{new string(' ', right)}";
    }

    private static string DoHeartLines(string symbols, char center, int EmptyToDelete)
    {
        var reverSym = "";
        foreach (var symbol in symbols.Reverse())
            reverSym += symbol.ToString();
        reverSym = (EmptyToDelete <= 13) ? reverSym.Remove(14 - EmptyToDelete, EmptyToDelete) : reverSym;

        return (symbols.Length == 14) ? $"{symbols}{center}{reverSym}" : throw new ArgumentException();
    }

    private static string DoHeartCenterLine(string symbols, char center, string student1, string student2)
    {
        var str = DoHeartLines(symbols, center, 0);
        str = ReplaceHelp(str, 7, 6, $"{student1}");
        return ReplaceHelp(str, 17, 6, $"{student2}");
        
    }

    private static string ReplaceHelp(string text, int start, int count,
                             string replacement)
    {
        return text.Substring(0, start) + replacement
             + text.Substring(start + count);
    }
}
