using System;

namespace Domain.Entities;
public class TransactionDetail
{
    public int Id { get; set; }
    public Item Item { get; set; }
    public float TotalAmount { get; set; }
    public int Quantity { get; set; }
    public string Purchaser { get; set; }
    public string Date { get; set; }
   



}
//aca tmb le agregue un ID
//Le agregue tmb un Quantity q seria la cantidad de producto q compra, de ultima lo sacamos
//Le saque el purchasedItem porq ya lo esta referenciando en el 'Item'