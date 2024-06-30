using LOLApi.Data;
using LOLApi.Model;

namespace LOLApi.Repository
{
    public class RangeTypeRepository:GeneralRepository<RangeType>
    {
        private readonly ApplicationDbContext _context;

        public RangeTypeRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }
    }
}
