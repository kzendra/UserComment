using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserComment.DB;
using UserComment.DB.Model;
using UserComment.Services.Interface;

namespace UserComment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentBS _commentBS;

        public CommentsController(ICommentBS commentBS)
        {
            _commentBS = commentBS;
        }

        // GET: api/Comments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comment>>> GetComments()
        {
            return await _commentBS.Get();
        }

        // GET: api/Comments/5
        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<Comment>>> GetComments(int userId)
        {
            return await _commentBS.GetUserComment(userId);
        }

        // GET: api/Comments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Comment>> GetComment(int id)
        {
            return await _commentBS.Get(id);
        }

        // PUT: api/Comments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComment(int id, Comment comment)
        {
            return await _commentBS.Put(id, comment);
        }

        // POST: api/Comments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Comment>> PostComment(Comment comment)
        {
            return await _commentBS.Save(comment);
        }

        // DELETE: api/Comments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            _commentBS.Delete(id);
        }

    }
}
