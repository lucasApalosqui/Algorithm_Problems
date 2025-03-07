using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

public struct CurrencyAmount
{
    private decimal amount;
    private string currency;

    public CurrencyAmount(decimal amount, string currency)
    {
        this.amount = amount;
        this.currency = currency;
    }

    // TODO: implement equality operators
    public static bool operator ==(CurrencyAmount lhs, CurrencyAmount rhs)
    {
        verifyCurrency(lhs, rhs);
        return (lhs.Equals(rhs)) ? true : false;
    }

    public static bool operator !=(CurrencyAmount lhs, CurrencyAmount rhs)
    {
        verifyCurrency(lhs, rhs);
        return (lhs.Equals(rhs)) ? false : true;
    }

    public override bool Equals([NotNullWhen(true)] object? obj) =>
        base.Equals(obj);

    public override int GetHashCode() =>
        base.GetHashCode();

    // TODO: implement comparison operators
    public static bool operator >(CurrencyAmount lhs, CurrencyAmount rhs)
    {
        verifyCurrency(lhs, rhs);
        return (lhs.amount > rhs.amount) ? true : false;
    }
    public static bool operator <(CurrencyAmount lhs, CurrencyAmount rhs)
    {
        verifyCurrency(lhs, rhs);
        return (lhs.amount < rhs.amount) ? true : false;
    }

    // TODO: implement arithmetic operators
    public static CurrencyAmount operator +(CurrencyAmount lhs, CurrencyAmount rhs)
    {
        verifyCurrency(lhs, rhs);
        return new CurrencyAmount((lhs.amount + rhs.amount), lhs.currency);
    }
    public static CurrencyAmount operator -(CurrencyAmount lhs, CurrencyAmount rhs)
    {
        verifyCurrency(lhs, rhs);
        return new CurrencyAmount((lhs.amount - rhs.amount), lhs.currency);
    }
    public static CurrencyAmount operator *(CurrencyAmount lhs, decimal mult) =>
        new CurrencyAmount((mult * lhs.amount), lhs.currency);

    public static CurrencyAmount operator *( decimal mult, CurrencyAmount lhs) =>
     new CurrencyAmount((mult * lhs.amount), lhs.currency);

    public static CurrencyAmount operator /(CurrencyAmount lhs, decimal mult)
    {
        return new CurrencyAmount((lhs.amount / mult), lhs.currency);
    }

    // TODO: implement type conversion operators
    public static explicit operator double(CurrencyAmount lhs) =>
        (double)lhs.amount;

    public static implicit operator decimal(CurrencyAmount lhs) =>
       lhs.amount;



    //Utils
    private static void verifyCurrency(CurrencyAmount lhs, CurrencyAmount rhs)
    {
        if (lhs.currency != rhs.currency) throw new ArgumentException();
    }

}
