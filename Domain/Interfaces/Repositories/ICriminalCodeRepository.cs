using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.Interfaces.Repositories
{
    public interface ICriminalCodeRepository
    {
        public IQueryable<CriminalCode> GetAll();
        public Task<CriminalCode> Add(CriminalCode entity);
        public Task<bool> Delete(int id);
        public Task<CriminalCode> GetById(int id);
        public Task<CriminalCode> Edit(CriminalCode entity);

    }
}