using System;

namespace Domain.Entities;

public class Client : User
{
    public List<Transaction> Transactions { get; set; }


}