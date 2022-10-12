using AutoMapper;
using BP.Core;
using BP.Core.Entities;
using BP.Service.DTOs.AssessmentDTOs;
using BP.Service.Exceptions;
using BP.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BP.Service.Implementations
{
    public class AssessmentService : IAssessmentService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AssessmentService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<AssessmentListDTO>> GetAllAsync()
        {
            return _mapper.Map<List<AssessmentListDTO>>(await _unitOfWork.AssessmentRepository.GetAllAsync());
        }

        public async Task<AssessmentGetDTO> GetById(int? id)
        {
            Assessment assessment = await _unitOfWork.AssessmentRepository.GetAsync(x => x.Id == id);

            if (assessment == null)
                throw new NotFoundException($"Assessment cannot be found by id = {id}");

            return _mapper.Map<AssessmentGetDTO>(assessment);
        }

        public async Task CreateAsync(AssessmentPostDTO assessmentPostDTO)
        {
            if (await _unitOfWork.AssessmentRepository.IsExistAsync(x =>
            x.WeightId == assessmentPostDTO.WeightId &&
            x.FrequencyId == assessmentPostDTO.FrequencyId &&
            x.DistanceId == assessmentPostDTO.DistanceId))
                throw new RecordDublicateException($"Assessment Already Exists!");

            if (!await _unitOfWork.WeightRepository.IsExistAsync(x => x.Id == assessmentPostDTO.WeightId))
                throw new NotFoundException($"Choose existing weight!");

            if (!await _unitOfWork.DistanceRepository.IsExistAsync(x => x.Id == assessmentPostDTO.DistanceId))
                throw new NotFoundException($"Choose existing distance!");

            if (!await _unitOfWork.FrequencyRepository.IsExistAsync(x => x.Id == assessmentPostDTO.FrequencyId))
                throw new NotFoundException($"Choose existing frequency!");

            Assessment assessment = _mapper.Map<Assessment>(assessmentPostDTO);

            await _unitOfWork.AssessmentRepository.AddAsync(assessment);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(int? id, AssessmentPutDTO assessmentPutDTO)
        {
            if (id == null)
                throw new BadRequestException($"Id is null!");

            if (id != assessmentPutDTO.Id)
                throw new BadRequestException($"Id's are not the same!");

            if (await _unitOfWork.AssessmentRepository.IsExistAsync(x =>
            x.Id != assessmentPutDTO.Id &&
            x.WeightId == assessmentPutDTO.WeightId &&
            x.FrequencyId == assessmentPutDTO.FrequencyId &&
            x.DistanceId == assessmentPutDTO.DistanceId))
                throw new RecordDublicateException($"Assessment Already Exists!");

            if (!await _unitOfWork.WeightRepository.IsExistAsync(x => x.Id == assessmentPutDTO.WeightId))
                throw new NotFoundException($"Choose existing weight!");

            if (!await _unitOfWork.DistanceRepository.IsExistAsync(x => x.Id == assessmentPutDTO.DistanceId))
                throw new NotFoundException($"Choose existing distance!");

            if (!await _unitOfWork.FrequencyRepository.IsExistAsync(x => x.Id == assessmentPutDTO.FrequencyId))
                throw new NotFoundException($"Choose existing frequency!");

            Assessment dbAssessment = await _unitOfWork.AssessmentRepository.GetAsync(c => c.Id == assessmentPutDTO.Id);

            if (dbAssessment == null)
                throw new NotFoundException($"Assessment Cannot be found By id = {id}");

            dbAssessment.WeightId = assessmentPutDTO.WeightId;
            dbAssessment.FrequencyId = assessmentPutDTO.FrequencyId;
            dbAssessment.DistanceId = assessmentPutDTO.DistanceId;
            dbAssessment.NeedToAssess = assessmentPutDTO.NeedToAssess;

            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int? id)
        {
            if (id == null)
                throw new BadRequestException($"Id is null!");

            Assessment dbAssessment = await _unitOfWork.AssessmentRepository.GetAsync(c => c.Id == id);

            if (dbAssessment == null)
                throw new NotFoundException($"Assessment Cannot be found By id = {id}");

            _unitOfWork.AssessmentRepository.Remove(dbAssessment);
            await _unitOfWork.CommitAsync();
        }
    }
}
