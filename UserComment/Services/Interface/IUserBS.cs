using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using UserComment.DB.Model;

namespace UserComment.Services.Interface
{
    public interface IUserBS
    {
        public Task<ActionResult<IEnumerable<User>>> Get();
        Task<ActionResult<User>> Get(int id);
        Task<IActionResult> Put(int id, User user);
        Task<ActionResult<User>> Save(User user);
        Task<IActionResult> Delete(int id);
    }
}
