using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces.Services;
using Domain.Models;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.Authorization;

namespace CdA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CriminalCodeController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly ICriminalCodeServices _criminalCodeServices;

        public CriminalCodeController(IConfiguration configuration, ICriminalCodeServices criminalCodeServices)
        {
            _configuration = configuration;
            _criminalCodeServices = criminalCodeServices;
        }

        [Authorize]
        [HttpPost]
        public async Task<CriminalCode> Add (CriminalCode criminalCode)
            => await _criminalCodeServices.Add(criminalCode);

        [HttpPut]
        public async Task<CriminalCode> Edit(CriminalCode criminalCode)
            => await _criminalCodeServices.Update(criminalCode);

        [Authorize]
        [HttpDelete]
        public async Task<bool> Delete (int id)
            => await _criminalCodeServices.Remove(id);

        [Authorize]
        [HttpGet("{id}")]
        [EnableQuery]
        public async Task<CriminalCode> Get (int id)
            => await _criminalCodeServices.Get(id);

        [Authorize]
        [HttpGet("api/[controller]/all/{page}")]
        [EnableQuery]
        public IQueryable<CriminalCode> GetAll(int page)
        {
            return _criminalCodeServices.GetAll(page).CriminalCodes;
        }
    }
}
