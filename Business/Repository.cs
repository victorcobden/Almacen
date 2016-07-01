using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using DAL;

namespace Business
{
    public class Repository : EFRepository, IDisposable
    {
        public Repository(bool autoDetectChangesEnabled = false, bool proxyCreationEnabled = false) : base(new AlmacenContext(), autoDetectChangesEnabled, proxyCreationEnabled)
        {
        }
    }
}
