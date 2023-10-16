using System;

namespace Product
{
public class Products
{
    public int Productid {get;set;}
    public string? Productname {get;set;}
    public string? Productclass {get;set;}
}

public class Electronics : Products
{

}

public class Computer : Electronics
{

}

public class Phone : Electronics
{

}

public class IoT : Electronics
{

}












}