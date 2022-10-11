using AutoMapper;
using BP.Core;
using BP.Core.Entities;
using BP.Service.DTOs.DistanceDTOs;
using BP.Service.Exceptions;
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
            return _mapper.Map<List<DistanceListDTO>>(await _unitOfWork.DistanceRepository.GetAllByExAsync(x => !x.IsDeleted));
        }

        public async Task<DistanceGetDTO> GetById(int? id)
        {
            Distance distance = await _unitOfWork.DistanceRepository.GetAsync(x => !x.IsDeleted && x.Id == id);

            if (distance == null)
                throw new NotFoundException($"Distance cannot be found by id = {id}");

            return _mapper.Map<DistanceGetDTO>(distance);
        }

        public async Task CreateAsync(DistancePostDTO distancePostDTO)
        {
            if (await _unitOfWork.DistanceRepository.IsExistAsync(c => !c.IsDeleted
            && c.Name.ToLower() == distancePostDTO.Name.Trim().ToLower()))
                throw new RecordDublicateException($"Distance Already Exists by Name = {distancePostDTO.Name}!");

            Distance distance = _mapper.Map<Distance>(distancePostDTO);

            await _unitOfWork.DistanceRepository.AddAsync(distance);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(int? id, DistancePutDTO distancePutDTO)
        {
            if (id == null)
                throw new BadRequestException($"Id is null!");

            if (id != distancePutDTO.Id)
                throw new BadRequestException($"Id's are not the same!");

            if (await _unitOfWork.DistanceRepository.IsExistAsync(c => !c.IsDeleted && c.Id != distancePutDTO.Id
            && c.Name.ToLower() == distancePutDTO.Name.Trim().ToLower()))
                throw new RecordDublicateException($"Distance Already Exists by Name = {distancePutDTO.Name}!");

            Distance dbDistance = await _unitOfWork.DistanceRepository.GetAsync(c => !c.IsDeleted && c.Id == distancePutDTO.Id);

            if (dbDistance == null)
                throw new NotFoundException($"Distance Cannot be found By id = {id}");

            dbDistance.Name = distancePutDTO.Name.Trim();
            dbDistance.UpdatedAt = DateTime.UtcNow.AddHours(4);

            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int? id)
        {
            if (id == null)
                throw new BadRequestException($"Id is null!");

            Distance dbDistance = await _unitOfWork.DistanceRepository.GetAsync(c => c.Id == id && !c.IsDeleted);

            if (dbDistance == null)
                throw new NotFoundException($"Distance Cannot be found By id = {id}");

            dbDistance.IsDeleted = true;
            dbDistance.DeletedAt = DateTime.UtcNow.AddHours(4);

            await _unitOfWork.CommitAsync();
        }

        public async Task RestoreAsync(int? id)
        {
            if (id == null)
                throw new BadRequestException($"Id is null!");

            Distance dbDistance = await _unitOfWork.DistanceRepository.GetAsync(c => c.Id == id && c.IsDeleted);

            if (dbDistance == null)
                throw new NotFoundException($"Distance Cannot be found By id = {id}");

            dbDistance.IsDeleted = false;
            dbDistance.DeletedAt = null;

            await _unitOfWork.CommitAsync();
        }
    }
}
