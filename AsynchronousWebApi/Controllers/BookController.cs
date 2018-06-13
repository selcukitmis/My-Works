using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using AsynchronousWebApi.Models;

namespace AsynchronousWebApi.Controllers
{
    public class BookController : ApiController
    {
        private readonly Context _context;

        public BookController()
        {
            _context = new Context();
        }
        public async Task<JsonResult<List<Book>>> Get()
        {
            var data = await _context.Books.Where(s => s.Id > 0).ToListAsync();
            return Json(data);
        }

        public async Task<JsonResult<Book>> Get(int id)
        {
            var data = await _context.Books.FirstOrDefaultAsync(s => s.Id.Equals(id));
            
            return Json(data);
        }

        public async Task<IHttpActionResult> Post(Book value)
        {
            try
            {
                var checkData = await _context.Books.FirstOrDefaultAsync(s => s.Name.Equals(value.Name));
                if (checkData == null)
                {
                    _context.Books.Add(value);
                    await _context.SaveChangesAsync();
                    return Ok(value);
                }

                return BadRequest("Record already have.");

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        public async Task<IHttpActionResult> Put(Book value)
        {
            try
            {
                var checkData = await _context.Books.FirstOrDefaultAsync(s => s.Id.Equals(value.Id));
                if (checkData != null)
                {
                    var checkName = await _context.Books.FirstOrDefaultAsync(s => s.Name.Equals(value.Name) && s.Id != value.Id);
                    if (checkName == null)
                    {
                        checkData.Name = value.Name;
                        _context.Books.Attach(checkData);
                        _context.Entry(checkData).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                        return Ok(checkData);
                    }
                    return BadRequest(value.Name + " already using.");
                }

                return BadRequest("Record not found.");

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                var data = await _context.Books.FirstOrDefaultAsync(s => s.Id.Equals(id));
                if (data == null) return BadRequest("Record not found!");
                _context.Books.Remove(data);
                await _context.SaveChangesAsync();
                return Ok(data);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
