using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JWTwebApi.Models;

namespace JWTwebApi.Controllers
{
    [Route("api/[controller]")]
    public class OwnerController : Controller
    {
        // GET api/values
        [HttpGet,Authorize]
        public IEnumerable<Owner> Get()
        {
            List<Owner> lstOwner = GetOnwers();
            return lstOwner;
        }

        private static List<Owner> GetOnwers()
        {
            List<Owner> lstOwner = new List<Owner>();
            lstOwner.Add(new Owner() { id = "1", name = "Gaurav", dateOfBirth = DateTime.Now, address = "Baner" });
            lstOwner.Add(new Owner() { id = "2", name = "Trupti", dateOfBirth = DateTime.Now, address = "Baner" });
            lstOwner.Add(new Owner() { id = "3", name = "Aaaru", dateOfBirth = DateTime.Now, address = "Baner" });
            lstOwner.Add(new Owner() { id = "4", name = "Riyu", dateOfBirth = DateTime.Now, address = "Baner" });
            lstOwner.Add(new Owner() { id = "5", name = "Pappa", dateOfBirth = DateTime.Now, address = "Baner" });
            return lstOwner;
        }

        [HttpGet, Authorize]
        [Route("{id}/{account}")]
        public Owner Get(int id,string account)
        {
            Owner onwer = GetOnwers().Where(i => i.id == id.ToString()).FirstOrDefault();
            onwer.accounts = new List<Account>();
            onwer.accounts.Add(new Account() {accountType = "Domestic", dateCreated = DateTime.Now , id ="1",ownerId="1" });
            onwer.accounts.Add(new Account() { accountType = "International", dateCreated = DateTime.Now, id = "1", ownerId = "1" });
            onwer.accounts.Add(new Account() { accountType = "Saving", dateCreated = DateTime.Now, id = "1", ownerId = "1" });

            return onwer;
        }

        [HttpGet, Authorize]
        [Route("{id}")]
        public Owner Get(int id)
        {
            Owner onwer = GetOnwers().Where(i => i.id == id.ToString()).FirstOrDefault();
            onwer.accounts = new List<Account>();
            onwer.accounts.Add(new Account() { accountType = "Domestic", dateCreated = DateTime.Now, id = "1", ownerId = "1" });
            onwer.accounts.Add(new Account() { accountType = "International", dateCreated = DateTime.Now, id = "1", ownerId = "1" });
            onwer.accounts.Add(new Account() { accountType = "Saving", dateCreated = DateTime.Now, id = "1", ownerId = "1" });

            return onwer;
        }

        [HttpPost, Authorize]
        public IActionResult Post([FromBody]Owner obj)
        {
            return Ok();
        }
        
        [HttpPut("{id}"), Authorize]
        public IActionResult Put(int id,[FromBody]Owner obj)
        {
            return Ok();
        }

        [HttpDelete("{id}"), Authorize]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}