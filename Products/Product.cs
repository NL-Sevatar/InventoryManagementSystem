using System;

namespace InventoryManagement
{
public class Product
{
    public int ProductID {get;set;}
    public string? ProductName {get;set;}
    public string? ProductClass {get;set;}
}

public class Electronics : Product
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