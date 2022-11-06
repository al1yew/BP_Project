using BP.Service.DTOs;
using BP.Service.DTOs.AssessmentDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.Service.Interfaces
{
    public interface IAssessmentService
    {

        Task<AssessmentGetDTO> GetById(int? id);

        Task<AllDataDTO> GetAllData();

        Task<AssessmentObjectDTO> Get(SortDTO sortDTO);

        Task CreateAsync(AssessmentPostDTO assessmentPostDTO);

        Task UpdateAsync(int? id, AssessmentPutDTO assessmentPutDTO);

        Task DeleteAsync(int? id);
    }
}
