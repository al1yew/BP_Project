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

        //Task<AllDataDTO> GetAllData();
        Task<AssessmentDTO> Get(); //new

        Task<int> CheckAssessment(CheckAssessmentDTO checkAssessmentDTO);

        //Task<AssessmentObjectDTO> Get(SortDTO sortDTO);

        Task CreateAsync(AssessmentPostDTO assessmentPostDTO);

        Task UpdateAsync(int? id, AssessmentPutDTO assessmentPutDTO);

        Task<List<AssessmentListDTO>> DeleteAsync(int? id);
    }
}
