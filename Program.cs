using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

public class LogParser
{
    public bool IsValidLine(string text)
    {
        var logline = text.Substring(0, 5);
        if (logline.Contains("[") && logline.Contains("]"))
            return (Enum.TryParse<Log>(logline.Substring(1, 3).ToUpper(), out var result)) ? true : false;
        return false;
    }

    public string[] SplitLogLine(string text)
    {
        var builder = new StringBuilder();
        bool verify = false;
        foreach (var cha in text)
        {
            if (cha == '<') verify = true;
            builder.Append(cha switch
            {
                '>' => '&',
                _ when verify == true => null,
                _ => cha
            });
            if (cha == '>') verify = false;
        }
        return builder.ToString().Split('&');
    }

    public int CountQuotedPasswords(string lines)
    {
        int count = 0;
        var separateStr = SepareStringByQuotes(lines);
        foreach (string strings in separateStr)
            if(strings.ToUpper().Contains("PASSWORD")) count++;
        return count;
    }

    public string RemoveEndOfLineText(string line)
    {
        var Words = line.Split(' ');
        string cleanLine = "";
        for (int i = 0; i < Words.Length; i++)
        {
            if (!Words[i].Contains("end-of-line")) cleanLine += Words[i] + " ";
            else if (Words[i] != Words[Words.Length - 1]) cleanLine += " ";
        }
           
        return cleanLine;    
    }

    public string[] ListLinesWithPasswords(string[] lines)
    {
        string[] strings = new string[lines.Length];
        string refactLine = "";
        string passW = "";
        int count = 0;
        foreach (string line in lines)
        {
            var words = line.Split(" ");
            int lastCont = 1;
            foreach (string word in words)
            {
                
                if (word.ToLower().Contains("password"))
                {
                    passW = (word.ToLower().Equals("password")) ? "--------: " : $"{word}: ";
                }
                refactLine += (lastCont != words.Length) ? $"{word} " : word;
                lastCont++;
            }
            lastCont = 1;
            strings[count] = passW + refactLine;
            count++;
            refactLine = "";
        }
        return strings;
    }


    // Utils
    private List<string> SepareStringByQuotes(string lines)
    {
        List<string> separateStr = new List<string>();
        var build = new StringBuilder();
        int quoteCount = 0;

        foreach (char line in lines)
        {
            build.Append(line switch
            {
                '"' => null,
                _ when char.IsControl(line) => null,
                _ => line
            });

            if (line == '"')
            {
                quoteCount++;
                if (quoteCount == 1 && build.Length != 0)
                    build = new StringBuilder();

                if (quoteCount == 2)
                {
                    separateStr.Add(build.ToString());
                    build = new StringBuilder();
                    quoteCount = 0;
                }

            }

        }
        return separateStr;
    }
}

public enum Log
{
    TRC,
    DBG,
    INF,
    WRN,
    ERR,
    FTL
}
