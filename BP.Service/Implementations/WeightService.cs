using AutoMapper;
using BP.Core;
using BP.Core.Entities;
using BP.Service.DTOs.WeightDTOs;
using BP.Service.Exceptions;
using BP.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.Service.Implementations
{
    public class WeightService : IWeightService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public WeightService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<WeightListDTO>> GetAllAsync()
        {
            return _mapper.Map<List<WeightListDTO>>(await _unitOfWork.WeightRepository.GetAllByExAsync(x => !x.IsDeleted));
        }

        public async Task<WeightGetDTO> GetById(int? id)
        {
            Weight weight = await _unitOfWork.WeightRepository.GetAsync(x => !x.IsDeleted && x.Id == id);

            if (weight == null)
                throw new NotFoundException($"Weight cannot be found by id = {id}");

            return _mapper.Map<WeightGetDTO>(weight);
        }

        public async Task CreateAsync(WeightPostDTO weightPostDTO)
        {
            if (await _unitOfWork.WeightRepository.IsExistAsync(c => !c.IsDeleted
            && c.Name.ToLower() == weightPostDTO.Name.Trim().ToLower()))
                throw new RecordDublicateException($"Weight Already Exists by Name = {weightPostDTO.Name}!");

            Weight weight = _mapper.Map<Weight>(weightPostDTO);

            await _unitOfWork.WeightRepository.AddAsync(weight);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(int? id, WeightPutDTO weightPutDTO)
        {
            if (id == null)
                throw new BadRequestException($"Id is null!");

            if (id != weightPutDTO.Id)
                throw new BadRequestException($"Id's are not the same!");

            if (await _unitOfWork.WeightRepository.IsExistAsync(c => !c.IsDeleted && c.Id != weightPutDTO.Id
            && c.Name.ToLower() == weightPutDTO.Name.Trim().ToLower()))
                throw new RecordDublicateException($"Weight Already Exists by Name = {weightPutDTO.Name}!");

            Weight dbWeight = await _unitOfWork.WeightRepository.GetAsync(c => !c.IsDeleted && c.Id == weightPutDTO.Id);

            if (dbWeight == null)
                throw new NotFoundException($"Weight Cannot be found By id = {id}");

            dbWeight.Name = weightPutDTO.Name.Trim();
            dbWeight.UpdatedAt = DateTime.UtcNow.AddHours(4);

            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int? id)
        {
            if (id == null)
                throw new BadRequestException($"Id is null!");

            Weight dbWeight = await _unitOfWork.WeightRepository.GetAsync(c => c.Id == id);

            if (dbWeight == null)
                throw new NotFoundException($"Weight Cannot be found By id = {id}");

            _unitOfWork.WeightRepository.Remove(dbWeight);

            foreach (var item in await _unitOfWork.AssessmentRepository.GetAllByExAsync(x => x.WeightId == id))
            {
                _unitOfWork.AssessmentRepository.Remove(item);
            }

            await _unitOfWork.CommitAsync();
        }

    }
}
