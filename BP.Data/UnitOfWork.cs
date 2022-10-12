using BP.Core;
using BP.Core.Repositories;
using BP.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BP.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WeightRepository _weightRepository;
        private readonly DistanceRepository _distanceRepository;
        private readonly FrequencyRepository _frequencyRepository;
        private readonly AssessmentRepository _assessmentRepository;
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IWeightRepository WeightRepository => _weightRepository != null ? _weightRepository : new WeightRepository(_context);
        public IDistanceRepository DistanceRepository => _distanceRepository != null ? _distanceRepository : new DistanceRepository(_context);
        public IFrequencyRepository FrequencyRepository => _frequencyRepository != null ? _frequencyRepository : new FrequencyRepository(_context);
        public IAssessmentRepository AssessmentRepository => _assessmentRepository != null ? _assessmentRepository : new AssessmentRepository(_context);



        public int Commit()
        {
            return _context.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
