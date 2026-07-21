using api.DTOs;
using api.DTOS;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepo;
        private readonly IStockRepository _stockRepo;
        public CommentController(ICommentRepository commentRepo, IStockRepository stockRepo)
        {
            _commentRepo = commentRepo;
            _stockRepo = stockRepo;
        }



        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comments = await _commentRepo.GetAllAsync();
            var commentDto = comments.Select(s => s.ToCommentDto());
            return Ok(commentDto);
        }


        [HttpPost("{stockId}")]
        public async Task<IActionResult> Create([FromRoute] string stockId, CreateCommentRequestDto commentDto)
        {
            if(!await _stockRepo.StockExists(stockId))
            {
                return BadRequest("Stock does not exist");
            }
            var commentModel = commentDto.ToModelFromCreateDto(stockId);
            await _commentRepo.CreateAsync(commentModel);
            return CreatedAtAction(nameof(GetById), new { id=commentModel.Id}, commentModel.ToCommentDto());
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var comment = await _commentRepo.GetOneAsync(id);

            if (comment==null) { return NotFound(); }

            return Ok(comment.ToCommentDto());
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] string id, [FromBody] UpdateCommentRequestDto updateDto)
        {
            var comment = await _commentRepo.UpdateAsync(id, updateDto.ToModelFromUpdateDto());

            if (comment == null) { return NotFound("Comment not found"); }

            return Ok(comment.ToCommentDto());
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            var commentModel = await _commentRepo.DeleteAsync(id);

            if (commentModel == null) { return NotFound("Comment not found"); }

            return Ok(commentModel);
        }

    }
}
