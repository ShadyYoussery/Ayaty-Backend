using System.Linq;
using Ayaty.Context.Models;
using Microsoft.EntityFrameworkCore;

namespace Ayaty.Clinic.Management.Helper
{
    public class GetDbSetLanguage
    {
        #region Fields

        private readonly AyatyContext _db;

        private int langaugeId = 1;

        #endregion Fields

        #region Ctor

        public GetDbSetLanguage(AyatyContext db)
        {
            _db = db;
        }

        #endregion Ctor

        #region General Methods

        public IQueryable<ClinicLanguage> Client => _db.ClinicLanguage.Where(t => t.LanguageId == langaugeId).Include(t=>t.Clinic);
        public IQueryable<ClinicUserLanguage> ClientUser => _db.ClinicUserLanguage.Where(t => t.LanguageId == langaugeId).Include(t=>t.Clin);

        #endregion General Methods
    }
}