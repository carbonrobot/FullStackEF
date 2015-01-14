namespace CCS.Core
{
    using System;
    using System.Collections.Generic;

    public class Patient : AuditableEntity
    {
        public Patient()
        {
            IsReleased = false;
            IsInfirmaryHoused = false;
            ConcurrencyId = 1;
            InmateTypeId = 1;
            Charts = new List<Chart>();
        }

        public string AddressPrimary { get; set; }

        public string AddressSecondary { get; set; }

        public DateTime? BirthDate { get; set; }

        public IList<Chart> Charts { get; set; }

        public string City { get; set; }

        public int? ConcurrencyId { get; set; }

        public DateTime? CustodyDate { get; set; }

        public int? EldoradoId { get; set; }

        public string EldoradoSsnId { get; set; }

        public string InmateNumber { get; set; }

        public int InmateTypeId { get; set; }

        public bool? IsDeceased { get; set; }

        public bool IsInfirmaryHoused { get; set; }

        public bool? IsJuvenile { get; set; }

        public bool? IsPreSentenced { get; set; }

        public bool IsReleased { get; set; }

        public bool? IsSentenced { get; set; }

        public string LocBed { get; set; }

        public string LocBuilding { get; set; }

        public string LocCell { get; set; }

        public string LocCellBlock { get; set; }

        public string LocDisplay { get; set; }

        public string LocFacility { get; set; }

        public string LocFloor { get; set; }

        public string LocOffsiteCode { get; set; }

        public string LocUnit { get; set; }

        public string NameFirst { get; set; }

        public string NameFull { get; internal set; }

        public string NameLast { get; set; }

        public string NameMiddle { get; set; }

        public int? PreferredLanguageId { get; set; }

        public DateTime? ReleaseDateActual { get; set; }

        public DateTime? ReleaseDatePotential { get; set; }

        public DateTime? SentenceDate { get; set; }

        public string Sex { get; set; }

        public int SiteDepartmentId { get; set; }

        public int SiteId { get; set; }

        public string Ssn { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }
    }
}