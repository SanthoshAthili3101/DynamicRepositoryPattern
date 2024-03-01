using DynamicRepositoryPattern.Infrastrucure.Entity;
using DynamicRepositoryPattern.Models;
using DynamicRepositoryPattern.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace DynamicRepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {

        private readonly TransactionDbContext _transactionDbContext;
        private readonly IUnitOfWork _unitOfWorkTransaction;
        public TransactionController(TransactionDbContext transactionDbContext)
        {
            _transactionDbContext = transactionDbContext;
            _unitOfWorkTransaction = new UnitOfWork<TransactionDbContext>(_transactionDbContext);
        }

        [HttpPost("CreateTransaction")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateTransaction(TransactionDto transactionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var transaction = new Transaction
            {
                Name = transactionDto.Name,
                Description = transactionDto.Description,
                Gender = transactionDto.Gender,
            };

            await _unitOfWorkTransaction.Repository<Transaction>().Add(transaction);

            return Ok("Transaction Created Successfully");
        }


        [HttpGet("GetTransactions")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTransactions()
        {
            var transactions = await _unitOfWorkTransaction.Repository<Transaction>().GetAll();
            return Ok(transactions);
        }

        [HttpGet("GetTransactionById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetTransactionById(int id)
        {
            var transaction = _unitOfWorkTransaction.Repository<Transaction>().GetById(id);
            if (transaction == null)
            {
                return NotFound();
            }
            return Ok(transaction);
        }

        [HttpDelete("DeleteTransaction/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteTransaction(int id)
        {
            var existingTransaction = _unitOfWorkTransaction.Repository<Transaction>().GetById(id);
            if (existingTransaction == null)
            {
                return NotFound();
            }

            _unitOfWorkTransaction.Repository<Transaction>().Remove(existingTransaction);

            return NoContent();
        }
    }
}
