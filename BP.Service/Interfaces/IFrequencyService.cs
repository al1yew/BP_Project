using BP.Service.DTOs.FrequencyDTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BP.Service.Interfaces
{
    public interface IFrequencyService
    {
        Task<List<FrequencyListDTO>> GetAllAsync();

        Task<FrequencyGetDTO> GetById(int? id);

        Task CreateAsync(FrequencyPostDTO frequencyPostDTO);

        Task UpdateAsync(int? id, FrequencyPutDTO FrequencyfutDTO);

        Task DeleteAsync(int? id);

        Task RestoreAsync(int? id);
    }
}
