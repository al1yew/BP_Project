using BP.Service.DTOs.AssessmentDTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BP.Service.Interfaces
{
    public interface IAssessmentService
    {
        Task<List<AssessmentListDTO>> GetAllAsync();

        Task<AssessmentGetDTO> GetById(int? id);

        Task CreateAsync(AssessmentPostDTO assessmentPostDTO);

        Task UpdateAsync(int? id, AssessmentPutDTO assessmentPutDTO);

        Task DeleteAsync(int? id);
    }
}
