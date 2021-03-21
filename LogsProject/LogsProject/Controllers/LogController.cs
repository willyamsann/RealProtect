using LogsProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace LogsProject.Controllers
{
    public class LogController : ApiController
    {
        [HttpGet]
        [Route("api/log/")]
        [ResponseType(typeof(Log))]

        public IHttpActionResult GetAllLogs()
        {
            IList<Log> logs = null;
            using (var db = new AppDbContext())
            {
                logs = db.LogsProject.ToList();

            }
            if (logs.Count == 0)
            {
                return NotFound();
            }
            return Ok(logs);
        }
        [Route("api/log/{id:int}")]

        public IHttpActionResult GetById(int? id)
        {
            if (id == null)
                return BadRequest("O Id do Log e invalido");

            Log log = null;
            using (var db = new AppDbContext())
            {
                log = db.LogsProject.ToList()
                         .Where(c => c.Id == id)
                         .FirstOrDefault();
            }
            if (log == null)
            {
                return NotFound();
            }
            return Ok(log);
        }

        [HttpGet]
        [Route("api/log/{ip}")]
        public IHttpActionResult GetLogByIp(string ip)
        {
            if (ip == null)
                return BadRequest("O IP Invalido");

            IList<Log> logs = null;

            using (var db = new AppDbContext())
            {
                logs = db.LogsProject.Where(x => x.Ip == ip).ToList();
            }
            if (logs == null)
            {
                return NotFound();
            }
            return Ok(logs);
        }

        [HttpGet]
        [Route("api/log/search/{search}/{id}/{ip}/{initialDate}/{finalDate}")]
        [System.Web.Mvc.ValidateInput(false)]

        public IHttpActionResult GetSearch(string search, int id, string ip, string initialDate ,string finalDate)
        {

            var initial = DateTime.Parse(initialDate);
            var final = DateTime.Parse(finalDate);

            IList<Log> logs = null;

            using (var db = new AppDbContext())
            {
                if(id == null || id == 0)
                {
                    logs = db.LogsProject.Where(x => x.Description.Contains(search)
                    &&  x.Ip.Contains(ip) && 
                    x.Date >=  initial && x.Date <= final).ToList();

                }
                else
                {
                    logs = db.LogsProject.Where(x => x.Description.Contains(search) && x.Ip.Contains(ip)
                    && x.Date >= initial && x.Date <= final).ToList();

                    }
            }
            if (logs == null)
            {
                return NotFound();
            }
            return Ok(logs);
        }


        [HttpGet]
        [Route("api/log/period/{initial}/{final}")]
        [System.Web.Mvc.ValidateInput(false)]
        public IHttpActionResult GetPeriod(DateTime initial, DateTime final)
        {

            IList<Log> logs = null;


            using (var db = new AppDbContext())
            {
                logs = db.LogsProject.Where(x => x.Date >= initial && x.Date <= final).ToList();
            }
            if (logs == null)
            {
                return NotFound();
            }
            return Ok(logs);
        }


        [HttpGet]
        [Route("api/log/countAll/")]
        public IHttpActionResult CountAll()
        {
            var logCount = 0;
            using (var db = new AppDbContext())
            {
                logCount = db.LogsProject.Count();
            }

            return Ok(logCount);
        }

        [HttpGet]
        [Route("api/log/pagination/{page}/{take}")]
        public IHttpActionResult GetAllPagination(int page, int take)
        {
            if (page == null)
                page = 1;
            if (take == null)
                take = 20;
            IList<Log> logs = null;
            using (var db = new AppDbContext())
            {
                logs = db.LogsProject.
                    OrderByDescending(lg => lg.Date)
                    .Skip((page - 1) * take)
                    .Take(take)
                    .ToList();

                    ;

            }
            if (logs.Count == 0)
            {
                return NotFound();
            }
            return Ok(logs);
        }

    }
}