namespace CCS.Services.Data
{
    using System;
    using Core;

    public interface IUCareDataContext : IDataContext
    {
        PatientTrackingReport GetPatientTrackingReport(string inmateNumber, DateTime startDate, DateTime endDate);
    }
}
