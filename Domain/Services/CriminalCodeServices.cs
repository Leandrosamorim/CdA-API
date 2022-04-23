using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class CriminalCodeServices : ICriminalCodeServices
    {
        private readonly ICriminalCodeRepository _criminalCodeRepository;

        public CriminalCodeServices(ICriminalCodeRepository criminalCodeRepository)
        {
            _criminalCodeRepository = criminalCodeRepository;
        }

        public async Task<CriminalCode> Add(CriminalCode criminalCode)
        {
            return await _criminalCodeRepository.Add(criminalCode);
        }


        public async Task<CriminalCode> Get(int id)
        {
            return await _criminalCodeRepository.GetById(id);
        }

        public CriminalCodeDTO GetAll(int page)
        {
            var resultsPerPage = 10f;
            var criminalCodes = _criminalCodeRepository.GetAll()
                .Skip((page - 1) * (int)resultsPerPage)
                .Take((int)resultsPerPage);
            var totalCriminalCodes = _criminalCodeRepository.GetAll().Count();
            var pageCount = Math.Ceiling(totalCriminalCodes / resultsPerPage);

            var response = new CriminalCodeDTO
            {
                CriminalCodes = criminalCodes,
                Pages = (int)pageCount,
                CurrentPage = page
            };

            return response;
        }

        public async Task<bool> Remove(int id)
        {
            return await _criminalCodeRepository.Delete(id);
        }

        public async Task<CriminalCode> Update(CriminalCode criminalCode)
        {
            return await _criminalCodeRepository.Edit(criminalCode);
        }
    }
}
