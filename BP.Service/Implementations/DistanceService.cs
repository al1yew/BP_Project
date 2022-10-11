using AutoMapper;
using BP.Core;
using BP.Service.DTOs.DistanceDTOs;
using BP.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BP.Service.Implementations
{
    public class DistanceService : IDistanceService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DistanceService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<DistanceListDTO>> GetAllAsync()
        {
            return _mapper.Map<List<DistanceListDTO>>(await _unitOfWork.WeightRepository.GetAllByExAsync(x => !x.IsDeleted));
        }

        public Task<DistanceGetDTO> GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(DistancePostDTO weightPostDTO)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int? id, DistancePutDTO weightPutDTO)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task RestoreAsync(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
