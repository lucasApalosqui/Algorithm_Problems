using System;
using System.Linq;
using System.Collections.Generic;

public struct Coord
{
    public Coord(ushort x, ushort y)
    {
        X = x;
        Y = y;
    }

    public ushort X { get; }
    public ushort Y { get; }

    public int Mult() =>
        X * Y;
}

public struct Plot
{
    public Plot(Coord coord1, Coord coord2, Coord coord3, Coord coord4)
    {
        Coord1 = coord1;
        Coord2 = coord2;
        Coord3 = coord3;
        Coord4 = coord4;
    }

    public Coord Coord1 { get; }
    public Coord Coord2 { get; }
    public Coord Coord3 { get; }
    public Coord Coord4 { get; }
}


public class ClaimsHandler
{
    private List<Plot> _plot = new List<Plot>();
    public void StakeClaim(Plot plot) =>
        _plot.Add(plot);

    public bool IsClaimStaked(Plot plot) =>
        (_plot.Contains(plot)) ? true : false; 


    public bool IsLastClaim(Plot plot) =>
        (_plot.Last().Equals(plot)) ? true : false;


    public Plot GetClaimWithLongestSide()
    {
        int longest = 0;
        Plot longestPlot = new Plot();
        foreach (Plot plot in _plot)
        {
            if (longest < CalculateCoords(plot))
            {
                longest = CalculateCoords(plot);
                longestPlot = plot;
            }
        }

        return longestPlot;
    }

    private int CalculateCoords(Plot plot) =>
         plot.Coord1.Mult() + plot.Coord2.Mult() + plot.Coord3.Mult() + plot.Coord4.Mult();

}
