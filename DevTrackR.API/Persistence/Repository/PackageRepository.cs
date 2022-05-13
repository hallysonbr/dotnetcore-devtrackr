using DevTrackR.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevTrackR.API.Persistence.Repository
{
    public class PackageRepository : IPackageRepository
    {
        private readonly DevTrackerContext _context;
        public PackageRepository(DevTrackerContext context)
        {
            _context = context;
        }

        public void Add(Package package)
        {
            _context.Packages.Add(package);
            _context.SaveChanges();
        }

        public List<Package> GetAll()
        {
            return _context.Packages.ToList();
        }

        public Package GetByCode(string code)
        {
           return _context.Packages.Include(p => p.Updates).SingleOrDefault(a => a.Code == code);
        }

        public void Update(Package package)
        {
            _context.Entry(package).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}