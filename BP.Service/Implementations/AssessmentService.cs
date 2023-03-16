using AutoMapper;
using BP.Core;
using BP.Core.Entities;
using BP.Service.DTOs;
using BP.Service.DTOs.AssessmentDTOs;
using BP.Service.DTOs.DistanceDTOs;
using BP.Service.DTOs.FrequencyDTOs;
using BP.Service.DTOs.WeightDTOs;
using BP.Service.Exceptions;
using BP.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<AssessmentObjectDTO> Get(SortDTO sortDTO)
        {
            List<AssessmentListDTO> assessments = _mapper.Map<List<AssessmentListDTO>>
                (await _unitOfWork.AssessmentRepository.GetAllAsync("Weight", "Distance", "Frequency"));

            IQueryable<AssessmentListDTO> query = assessments.AsQueryable();

            if (sortDTO.WeightId > 0)
            {
                query = query.Where(x => x.WeightId == sortDTO.WeightId);
            }

            if (sortDTO.DistanceId > 0)
            {
                query = query.Where(x => x.DistanceId == sortDTO.DistanceId);
            }

            if (sortDTO.FrequencyId > 0)
            {
                query = query.Where(x => x.FrequencyId == sortDTO.FrequencyId);
            }

            if (sortDTO.NeedToAssess == 1)
            {
                query = query.Where(x => x.NeedToAssess);
            }
            else if (sortDTO.NeedToAssess == 2)
            {
                query = query.Where(x => !x.NeedToAssess);
            }

            if (sortDTO.Page == 0)
            {
                sortDTO.Page = 1;
            }

            if (sortDTO.ShowCount == 0)
            {
                sortDTO.ShowCount = 10;
            }

            return new AssessmentObjectDTO()
            {
                Query = query.Skip((sortDTO.Page * sortDTO.ShowCount) - sortDTO.ShowCount).Take(sortDTO.ShowCount),
                TotalCount = query.Count()
            };
        }

        public async Task<AssessmentGetDTO> GetById(int? id)
        {
            Assessment assessment = await _unitOfWork.AssessmentRepository.GetAsync(x => x.Id == id, "Weight", "Distance", "Frequency");

            if (assessment == null)
                throw new NotFoundException($"Assessment cannot be found by id = {id}");

            return _mapper.Map<AssessmentGetDTO>(assessment);
        }

        public async Task<AllDataDTO> GetAllData()
        {
            return new AllDataDTO()
            {
                Distances = _mapper.Map<List<DistanceListDTO>>(await _unitOfWork.DistanceRepository.GetAllByExAsync(x => !x.IsDeleted)),
                Weights = _mapper.Map<List<WeightListDTO>>(await _unitOfWork.WeightRepository.GetAllByExAsync(x => !x.IsDeleted)),
                Frequencies = _mapper.Map<List<FrequencyListDTO>>(await _unitOfWork.FrequencyRepository.GetAllByExAsync(x => !x.IsDeleted)),
            };
        }

        public async Task<int> MakeAssessment(MakeAssessmentDTO makeAssessmentDTO)
        {
            if (!await _unitOfWork.WeightRepository.IsExistAsync(x => x.Id == makeAssessmentDTO.WeightId))
                throw new NotFoundException($"Choose existing weight!");

            if (!await _unitOfWork.DistanceRepository.IsExistAsync(x => x.Id == makeAssessmentDTO.DistanceId))
                throw new NotFoundException($"Choose existing distance!");

            if (!await _unitOfWork.FrequencyRepository.IsExistAsync(x => x.Id == makeAssessmentDTO.FrequencyId))
                throw new NotFoundException($"Choose existing frequency!");

            Assessment assessment = await _unitOfWork.AssessmentRepository.GetAsync(x => x.FrequencyId == makeAssessmentDTO.FrequencyId && x.WeightId == makeAssessmentDTO.WeightId && x.DistanceId == makeAssessmentDTO.DistanceId);

            if (assessment == null)
                throw new NotFoundException("Assessment cannot be found!");

            return assessment.NeedToAssess ? 1 : 0;
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
