using Recruitment_Systeam.Data;
using System.Collections.Generic;
using System.Web.Http;

  
namespace CreateJob.API.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {
        // GET api/values



        public IEnumerable<string> Get()
        {
            using (var ctx = new Createjob_DbContext() )
            {
               Job stud = new Job { JobID = 1 , JobTitle="Software Engineer", Create_User_ID= 3, };

                ctx.jobs.Add(stud);
                ctx.SaveChanges();
            }

            return new string[] { "value1", "value2" ,"values3"};
        }

        // GET api/values/5 
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
