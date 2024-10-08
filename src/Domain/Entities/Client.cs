using System;

namespace Domain.Entities;

public class Client :User
{
    public List<Order> Orders {get;set;}

}
