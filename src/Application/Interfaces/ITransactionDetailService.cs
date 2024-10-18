using Application.Models.Request;
using Application.Models;
using Domain.Entities;

namespace Application.Interfaces
{
    // Definición de la interfaz del servicio de detalles de transacciones
    public interface ITransactionDetailService
    {
        // Método para obtener todos los detalles de transacciones
        IEnumerable<TransactionDetailDTO> GetAllTransactionDetails();

        // Método para obtener un detalle de transacción específico por ID
        TransactionDetailDTO GetTransactionDetailById(int id);

        // Método para crear un nuevo detalle de transacción
        void CreateTransactionDetail(TransactionDetailCreateRequest transactionDetailCreateRequest);

        // Método para actualizar un detalle de transacción existente
        void UpdateTransactionDetail(int id, TransactionDetailUpdateRequest transactionDetailUpdateRequest);

        // Método para eliminar un detalle de transacción por su ID
        void DeleteTransactionDetail(int id);
    }
}
