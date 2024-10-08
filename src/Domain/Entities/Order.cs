using System;

namespace Domain.Entities;

public class Order
{
    public int Id {get;set;}

    public Client client {get;set;}

    public List<ShoppingCart> Cart {get;set;}

    public float Total {get;set;}


}
