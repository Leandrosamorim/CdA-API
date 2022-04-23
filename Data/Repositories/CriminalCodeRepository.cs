using Data.Context;
using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class CriminalCodeRepository : ICriminalCodeRepository
    {
        private readonly ApplicationDBContext _context;

        public CriminalCodeRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public IQueryable<CriminalCode> GetAll()
            => _context.CriminalCode;

        public async Task<CriminalCode> Add(CriminalCode entity)
        {
            try
            {
                _context.CriminalCode.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }catch (Exception ex)
            {
                throw new Exception("Something strange occurred. Try again");
            }
            
        }

        public async Task<CriminalCode> GetById(int id)
        {
            try
            {
                return await _context.CriminalCode.SingleOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var deletedCriminalCode = await GetById(id);
            if (deletedCriminalCode != null)
            {
                _context.CriminalCode.Remove(deletedCriminalCode);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<CriminalCode> Edit (CriminalCode entity)
        {
            _context.CriminalCode.Update(entity);
            _context.SaveChangesAsync();

            return entity;
        }




    }
}
