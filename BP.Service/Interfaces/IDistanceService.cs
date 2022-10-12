using BP.Service.DTOs.DistanceDTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BP.Service.Interfaces
{
    public interface IDistanceService
    {
        Task<List<DistanceListDTO>> GetAllAsync();

        Task<DistanceGetDTO> GetById(int? id);

        Task CreateAsync(DistancePostDTO distancePostDTO);

        Task UpdateAsync(int? id, DistancePutDTO distancePutDTO);

        Task DeleteAsync(int? id);

    }
}
