using Angular2MVC.DBContext;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace Angular2MVC.Controllers
{
    [RoutePrefix("api/lookup")]
    public class LookupController : BaseAPIController
    {
        [Route("Branches")]
        public HttpResponseMessage GetBranch()
        {
            var branches = UserDB.Branches.Select(st => new
            {
                st.Id,
                st.BranchName
            }).ToList();
            return ToJson(branches);
        }
        [Route("Programs")]
        public HttpResponseMessage GetProgramArea()
        {
            var programs = UserDB.ProgramAreas.Select(st => new
            {
                st.Id,
                st.ProgramAreaName
            }).ToList();
            return ToJson(programs);
        }

        public HttpResponseMessage Post([FromBody]TblUser value)
        {
            UserDB.TblUsers.Add(value);             
            return ToJson(UserDB.SaveChanges());
        }

        public HttpResponseMessage Put(int id, [FromBody]TblUser value)
        {
            UserDB.Entry(value).State = EntityState.Modified;
            return ToJson(UserDB.SaveChanges());
        }
        public HttpResponseMessage Delete(int id)
        {
            UserDB.TblUsers.Remove(UserDB.TblUsers.FirstOrDefault(x => x.Id == id));
            return ToJson(UserDB.SaveChanges());
        }
    }
}
