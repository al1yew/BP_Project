using BP.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BP.Core
{
    public interface IUnitOfWork
    {
        IWeightRepository WeightRepository { get; }
        IDistanceRepository DistanceRepository { get; }
        IFrequencyRepository FrequencyRepository { get; }
        IAssessmentRepository AssessmentRepository { get; }
        IAppUserRepository AppUserRepository { get; }
        Task<int> CommitAsync();
        int Commit();
    }
}
