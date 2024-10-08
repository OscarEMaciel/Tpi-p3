using System;

namespace Domain.Entities;

public class ShoppingCart
{
    public int Id {get;set;}

    public Product Product{get;set;}

    public int Quantity {get;set;}

    public float UnitPrice {get;set;}

}
