using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DataManagement.Business.Interfaces;
using DataManagement.Entities;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DataManagement.API.Controllers
{
    [Route("api/[controller]")] 
    public class UserController : Controller
    {
        IUserManager _userManager;
        public UserController(IUserManager userManager) 
            => _userManager = userManager;
 
        [HttpGet]  
        public IEnumerable < User > Get() 
            => _userManager.GetAllUser();

        // GET api/user/5  
        [HttpGet("{id}")]
        public User Get(int id) 
            => _userManager.GetUserById(id);
                                               
        // POST api/user  
        [HttpPost]  
        public void Post([FromBody] User user) 
            => _userManager.AddUser(user);  

        // PUT api/user/5  
        [HttpPut("{id}")]  
        public void Put(int id, [FromBody] User user) 
            => _userManager.UpdateUser(user);  

        // DELETE api/user/5  
        [HttpDelete("{id}")]  
        public void Delete(int id) 
            => _userManager.DeleteUser(id);  
         
    }
}
