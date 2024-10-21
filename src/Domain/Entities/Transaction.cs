using System;

namespace Domain.Entities;

public class Transaction
{
    public int Id { get; set; }
    public Client client{ get; set; }
    public List<TransactionDetail> Details{ get; set; }
    public float TotalAmount { get; set; }
    public string SoldItem { get; set; }
    public string Date { get; set; }
}
//en el UML falta el atributo ID 
//al atributo 'seller' en el uml, le cambie el nombre a client para q haga referencia a la clase

