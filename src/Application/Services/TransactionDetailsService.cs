using Application.Interfaces;
using Application.Models.Request;
using Application.Models;
using Domain;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Exceptions;

namespace Application.Services
{
    // Implementación del servicio de detalles de transacciones
    public class TransactionDetailService : ITransactionDetailService
    {
        private readonly ITransactionDetailsRepository _transactionDetailsRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IItemRepository _itemRepository;

        // Constructor que inyecta los repositorios necesarios
        public TransactionDetailService(ITransactionDetailsRepository transactionDetailsRepository, ITransactionRepository transactionRepository, IItemRepository itemRepository)
        {
            _transactionDetailsRepository = transactionDetailsRepository;
            _transactionRepository = transactionRepository;
            _itemRepository = itemRepository;
        }

        // Método para obtener todos los detalles de transacciones
        public IEnumerable<TransactionDetailDTO> GetAllTransactionDetails()
        {
            var objs = _transactionDetailsRepository.GetAll();
            return TransactionDetailDTO.CreateList(objs);
        }

        // Método para obtener un detalle de transacción específico por su ID
        public TransactionDetailDTO GetTransactionDetailById(int id)
        {
            var obj = _transactionDetailsRepository.GetById(id)
                ?? throw new NotFoundException(nameof(TransactionDetail), id);
            return TransactionDetailDTO.Create(obj);
        }

        // Método para crear un nuevo detalle de transacción
        public void CreateTransactionDetail(TransactionDetailCreateRequest transactionDetailCreateRequest)
        {
            var transaction = _transactionRepository.GetById(transactionDetailCreateRequest.TransactionId);
            var item = _itemRepository.GetById(transactionDetailCreateRequest.ItemId);
            
            // Verifica si el item existe
            if (item == null)
            {
                throw new NotFoundException(nameof(Item), transactionDetailCreateRequest.ItemId);
            }

            // Verifica si hay stock disponible
            if (item.StockAvailable < transactionDetailCreateRequest.Quantity)
            {
                throw new InvalidOperationException("No hay suficiente stock disponible.");
            }

            // Resta la cantidad solicitada del stock
            item.StockAvailable -= transactionDetailCreateRequest.Quantity;

            // Actualiza el item en el repositorio
            _itemRepository.Update(item);

            // Crea un nuevo detalle de transacción
            var transactionDetail = new TransactionDetail(transaction, item, transactionDetailCreateRequest.Quantity, transactionDetailCreateRequest.UnitPrice);
            _transactionDetailsRepository.Add(transactionDetail);
        }

        // Método para actualizar un detalle de transacción existente
        public void UpdateTransactionDetail(int id, TransactionDetailUpdateRequest transactionDetailUpdateRequest)
        {
            var transactionDetail = _transactionDetailsRepository.GetById(id)
                ?? throw new NotFoundException(nameof(TransactionDetail), id);
            var transaction = _transactionRepository.GetById(transactionDetailUpdateRequest.TransactionId);
            var item = _itemRepository.GetById(transactionDetailUpdateRequest.ItemId);

            // Actualiza los campos si no son nulos
            if (transactionDetailUpdateRequest.Quantity != null) transactionDetail.Quantity = transactionDetailUpdateRequest.Quantity;
            if (transactionDetailUpdateRequest.UnitPrice != null) transactionDetail.UnitPrice = transactionDetailUpdateRequest.UnitPrice;

            transactionDetail.Item = item;
            transactionDetail.Transaction = transaction;

            // Actualiza el detalle de transacción
            _transactionDetailsRepository.Update(transactionDetail);
        }

        // Método para eliminar un detalle de transacción por su ID
        public void DeleteTransactionDetail(int id)
        {
            var transactionDetails = _transactionDetailsRepository.GetById(id);
            if (transactionDetails == null)
            {
                throw new NotFoundException(nameof(TransactionDetail), id);
            }
            _transactionDetailsRepository.Delete(transactionDetails);
        }
    }
}
