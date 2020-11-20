using EEmergencyWepApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EEmergencyWepApi.Data.module
{
    public class ConctionDbClass:DbContext
    {
     

        public ConctionDbClass(DbContextOptions<ConctionDbClass> options) : base(options) { 
        
        }

        public DbSet<Civilian> Civilian { set; get; }
        public DbSet<HelpRequest> HelpRequest { set; get; }
        public DbSet<Admin> Admin { set; get; }
        public DbSet<Paramedic> Paramedic { set; get; }
        public DbSet<DCD> DCD { set; get; }
        public DbSet<HelpRequestAssigned> HelpRequestAssigned { set; get; }
        public DbSet<Hospital> Hospital { set; get; }
        public DbSet<TeamMembers> TeamMembers { set; get; }
        public DbSet<ParamedicTeam> ParamedicTeams { set; get; }
        
    }
}
