using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface ICriminalCodeServices
    {
        public Task<CriminalCode> Add(CriminalCode criminalCode);
        public Task<bool> Remove(int id);
        public Task<CriminalCode> Get(int id);
        public Task<CriminalCode> Update(CriminalCode criminalCode);
        public CriminalCodeDTO GetAll(int page);
    }
}
