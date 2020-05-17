using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingAppAPI.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DatingAppAPI.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        
        private readonly DataContext _dataContext;
        public ValuesController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        
        [HttpGet]
        public  async Task<IActionResult> Get(){
            //throw new Exception("The test except.");
            var values = await _dataContext.Values.ToListAsync();
            return Ok(values);
        }
 
       
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id){
            var value = await _dataContext.Values.FirstOrDefaultAsync(x=>x.Id == id);
            return Ok(value);
        }  

        [HttpPost]
        public void Post([FromBody] string value){

        }

        [HttpPut ("{id}")]
        public void Put(int id, [FromBody] string value){

        }

        [HttpDelete("{id}")]
        public void Delete(int id){

        }

    }
}