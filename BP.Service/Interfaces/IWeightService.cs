using BP.Service.DTOs.WeightDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP.Service.Interfaces
{
    public interface IWeightService
    {
        Task<List<WeightListDTO>> GetAllAsync();

        Task<WeightGetDTO> GetById(int? id);

        Task CreateAsync(WeightPostDTO weightPostDTO);

        Task UpdateAsync(int? id, WeightPutDTO weightPutDTO);

        Task DeleteAsync(int? id);

    }
}
