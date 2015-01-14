namespace CCS.Data.UCare
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.SqlClient;
    using Configuration;
    using Core;
    using Services.Data;

    public class UCareDataContext : DataContext, IUCareDataContext
    {
        static UCareDataContext()
        {
            Database.SetInitializer<UCareDataContext>(null);
        }

        public DbSet<Chart> Charts { get; set; }
        public DbSet<Patient> Patients { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PatientsConfiguration());
            modelBuilder.Configurations.Add(new ChartsConfiguration());
        }

        public PatientTrackingReport GetPatientTrackingReport(string inmateNumber, DateTime startDate, DateTime endDate)
        {
            var sproc = "prPatientTracking";
            var sqlParams = new List<SqlParameter>()
            {
                new SqlParameter("@InmateNumber", inmateNumber),
                new SqlParameter("@StartDate", startDate),
                new SqlParameter("@EndDate", endDate),
            };
            var parameters = sqlParams.ToArray<object>();
            return this.Database.SqlQuery<PatientTrackingReport>(sproc, parameters).SingleOrDefault();
        }
    }
}