using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserComment.DB;
using UserComment.DB.Model;
using UserComment.Services.Interface;

namespace UserComment.Services
{
    public class CommentBS : ControllerBase, ICommentBS
    {
        private Data _dbContext;
        public CommentBS(Data dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Delete(int id)
        {
            var comment = await _dbContext.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            _dbContext.Comments.Remove(comment);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        public async Task<ActionResult<IEnumerable<Comment>>> Get()
        {
            return await _dbContext.Comments.ToListAsync();
        }

        public async Task<ActionResult<Comment>> Get(int id)
        {
            var comment = await _dbContext.Comments.FindAsync(id);

            if (comment == null)
            {
                return NotFound();
            }

            return comment;
        }

        public async Task<ActionResult<IEnumerable<Comment>>> GetUserComment(int userId)
        {
            return await _dbContext.Comments.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<IActionResult> Put(int id, Comment comment)
        {
            if (id != comment.Id)
            {
                return BadRequest();
            }

            _dbContext.Entry(comment).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        public async Task<ActionResult<Comment>> Save(Comment comment)
        {
            _dbContext.Comments.Add(comment);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetComment", new { id = comment.Id }, comment);
        }

        private bool CommentExists(int id)
        {
            return _dbContext.Comments.Any(e => e.Id == id);
        }
    }
}
