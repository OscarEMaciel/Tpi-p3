using Microsoft.AspNetCore.Mvc;
using Application.Models.Request;
using Application.Services;
using Application.Interfaces;
using Domain.Exceptions;
using System;
using System.Collections.Generic;
using Application.Models;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;

namespace Web.Controllers
{
    // Definimos la ruta del controlador y aplicamos la autorización para proteger el acceso
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class TransactionDetailController : ControllerBase
    {
        private readonly ITransactionDetailService _transactionDetailService;

        // Constructor que inyecta el servicio de transacciones
        public TransactionDetailController(ITransactionDetailService transactionDetailService)
        {
            _transactionDetailService = transactionDetailService;
        }

        // Acción que obtiene todos los detalles de transacciones
        [HttpGet]
        [Authorize(Roles = "Client, SysAdmin, Admin")]
        public ActionResult<IEnumerable<TransactionDetail>> GetAllTransactionDetails()
        {
            try
            {
                var transactionDetails = _transactionDetailService.GetAllTransactionDetails();
                return Ok(transactionDetails); // Retorna el resultado en formato JSON (200 OK)
            }
            catch (Exception ex)
            {
                // Retorna un error 500 en caso de fallo inesperado
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        // Acción que obtiene un detalle de transacción por su ID
        [HttpGet("{id}")]
        [Authorize(Roles = "Client, SysAdmin, Admin")]
        public ActionResult<TransactionDetailDTO> GetTransactionDetailById(int id)
        {
            try
            {
                var transactionDetail = _transactionDetailService.GetTransactionDetailById(id);
                if (transactionDetail == null)
                {
                    throw new NotFoundException("TransactionDetail", id); // Lanza excepción si no se encuentra
                }
                return Ok(transactionDetail);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message); // Retorna 404 si no encuentra el recurso
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        // Acción para crear un nuevo detalle de transacción
        [HttpPost]
        [Authorize(Roles = "Client, SysAdmin, Admin")]
        public ActionResult CreateTransactionDetail([FromBody] TransactionDetailCreateRequest transactionDetailCreateRequest)
        {
            try
            {
                _transactionDetailService.CreateTransactionDetail(transactionDetailCreateRequest);
                return Ok(); // Retorna 200 OK si se crea correctamente
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        // Acción para actualizar un detalle de transacción existente
        [HttpPut("{id}")]
        [Authorize(Roles = "Client, SysAdmin, Admin")]
        public IActionResult UpdateTransactionDetail(int id, [FromBody] TransactionDetailUpdateRequest transactionDetailUpdateRequest)
        {
            try
            {
                _transactionDetailService.UpdateTransactionDetail(id, transactionDetailUpdateRequest);
                return NoContent(); // Retorna 204 No Content si se actualiza correctamente
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        // Acción para eliminar un detalle de transacción
        [HttpDelete("{id}")]
        [Authorize(Roles = "Client, SysAdmin, Admin")]
        public IActionResult DeleteTransactionDetail(int id)
        {
            try
            {
                _transactionDetailService.DeleteTransactionDetail(id);
                return NoContent(); // Retorna 204 si se elimina correctamente
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message); // Retorna 404 si no encuentra el recurso
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred.");
            }
        }
    }
}
