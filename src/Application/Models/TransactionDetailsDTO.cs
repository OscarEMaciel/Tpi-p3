using Domain.Entities;

namespace Application.Models
{
    // DTO (Data Transfer Object) para detalles de transacciones
    public class TransactionDetailDTO
    {
        // Identificador de la transacción
        public int TransactionId { get; set; }

        // Identificador del ítem relacionado
        public int ItemId { get; set; }

        // Cantidad de ítems en la transacción
        public int Quantity { get; set; }

        // Precio unitario del ítem en la transacción
        public decimal UnitPrice { get; set; }

        // Método estático que crea un TransactionDetailDTO a partir de un TransactionDetail
        public static TransactionDetailDTO Create(TransactionDetail transactionDetail)
        {
            return new TransactionDetailDTO
            {
                TransactionId = transactionDetail.TransactionId,
                ItemId = transactionDetail.ItemId,
                Quantity = transactionDetail.Quantity,
                UnitPrice = transactionDetail.UnitPrice
            };
        }

        // Método estático que crea una lista de TransactionDetailDTO a partir de una lista de TransactionDetail
        public static List<TransactionDetailDTO> CreateList(IEnumerable<TransactionDetail> transactionDetails)
        {
            List<TransactionDetailDTO> listDto = new List<TransactionDetailDTO>();
            foreach (var td in transactionDetails)
            {
                listDto.Add(Create(td));
            }
            return listDto;
        }
    }
}
