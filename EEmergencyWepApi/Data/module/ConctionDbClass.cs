using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EEmergencyWepApi.Data.module
{
    public class ConctionDbClass:DbContext
    {
        public ConctionDbClass(DbContextOptions<ConctionDbClass> options):base(options)
    }
}
