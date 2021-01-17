using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserComment.DB.Model;

namespace UserComment.Services.Interface
{
    public interface ICommentBS
    {
        Task<ActionResult<IEnumerable<Comment>>> Get();
        Task<ActionResult<IEnumerable<Comment>>> GetUserComment(int userId);
        Task<ActionResult<Comment>> Get(int id);
        Task<IActionResult> Put(int id, Comment comment);
        Task<ActionResult<Comment>> Save(Comment comment);
        Task<IActionResult> Delete(int id);
    }
}
