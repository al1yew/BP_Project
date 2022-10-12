using AutoMapper;
using BP.Core;
using BP.Core.Entities;
using BP.Service.DTOs.FrequencyDTOs;
using BP.Service.Exceptions;
using BP.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BP.Service.Implementations
{
    public class FrequencyService : IFrequencyService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public FrequencyService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<FrequencyListDTO>> GetAllAsync()
        {
            return _mapper.Map<List<FrequencyListDTO>>(await _unitOfWork.FrequencyRepository.GetAllByExAsync(x => !x.IsDeleted));
        }

        public async Task<FrequencyGetDTO> GetById(int? id)
        {
            Frequency frequency = await _unitOfWork.FrequencyRepository.GetAsync(x => !x.IsDeleted && x.Id == id);

            if (frequency == null)
                throw new NotFoundException($"Frequency cannot be found by id = {id}");

            return _mapper.Map<FrequencyGetDTO>(frequency);
        }

        public async Task CreateAsync(FrequencyPostDTO frequencyPostDTO)
        {
            if (await _unitOfWork.FrequencyRepository.IsExistAsync(c => !c.IsDeleted
            && c.Name.ToLower() == frequencyPostDTO.Name.Trim().ToLower()))
                throw new RecordDublicateException($"Frequency Already Exists by Name = {frequencyPostDTO.Name}!");

            Frequency frequency = _mapper.Map<Frequency>(frequencyPostDTO);

            await _unitOfWork.FrequencyRepository.AddAsync(frequency);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(int? id, FrequencyPutDTO frequencyPutDTO)
        {
            if (id == null)
                throw new BadRequestException($"Id is null!");

            if (id != frequencyPutDTO.Id)
                throw new BadRequestException($"Id's are not the same!");

            if (await _unitOfWork.FrequencyRepository.IsExistAsync(c => !c.IsDeleted && c.Id != frequencyPutDTO.Id
            && c.Name.ToLower() == frequencyPutDTO.Name.Trim().ToLower()))
                throw new RecordDublicateException($"Frequency Already Exists by Name = {frequencyPutDTO.Name}!");

            Frequency dbFrequency = await _unitOfWork.FrequencyRepository.GetAsync(c => !c.IsDeleted && c.Id == frequencyPutDTO.Id);

            if (dbFrequency == null)
                throw new NotFoundException($"Frequency Cannot be found By id = {id}");

            dbFrequency.Name = frequencyPutDTO.Name.Trim();
            dbFrequency.UpdatedAt = DateTime.UtcNow.AddHours(4);

            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int? id)
        {
            if (id == null)
                throw new BadRequestException($"Id is null!");

            Frequency dbFrequency = await _unitOfWork.FrequencyRepository.GetAsync(c => c.Id == id);

            if (dbFrequency == null)
                throw new NotFoundException($"Frequency Cannot be found By id = {id}");

            _unitOfWork.FrequencyRepository.Remove(dbFrequency);

            foreach (var item in await _unitOfWork.AssessmentRepository.GetAllByExAsync(x => x.FrequencyId == id))
            {
                _unitOfWork.AssessmentRepository.Remove(item);
            }

            await _unitOfWork.CommitAsync();
        }

    }
}
