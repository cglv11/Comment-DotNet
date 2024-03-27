using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using back_comments.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace back_comments.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CommentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Comment
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listComments = await _context.Comment.ToListAsync();

                return Ok(listComments);

            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Comment/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> GetAsync(int id)
        {
            try
            {
                var comment = await _context.Comment.FindAsync(id);

                if(comment == null)
                {
                    return NotFound();
                }

                return Ok(comment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Comment
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Comment comment)
        {
            try
            {

                _context.Add(comment);
                await _context.SaveChangesAsync();

                return Ok(comment);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Comment/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Comment comment)
        {
            try
            {

               if( id != comment.Id)
                {
                    return BadRequest();
                }

                _context.Update(comment);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Comment is updated successfully" });
              
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Comment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var comment = await _context.Comment.FindAsync(id);

                if(comment == null)
                {
                    return NotFound();
                }

                _context.Comment.Remove(comment);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Comment deleted successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
