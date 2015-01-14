namespace CCS.Data.UCare.Configuration
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core;

    internal class PatientsConfiguration : EntityTypeConfiguration<Patient>
    {
        public PatientsConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".PATIENTS");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.SiteId).HasColumnName("SiteId").IsRequired();
            Property(x => x.EldoradoId).HasColumnName("EldoradoId").IsOptional();
            Property(x => x.InmateNumber).HasColumnName("InmateNumber").IsRequired().HasMaxLength(15);
            Property(x => x.Ssn).HasColumnName("SSN").IsRequired().HasMaxLength(11);
            Property(x => x.NameFirst).HasColumnName("NameFirst").IsRequired().HasMaxLength(25);
            Property(x => x.NameMiddle).HasColumnName("NameMiddle").IsOptional().HasMaxLength(25);
            Property(x => x.NameLast).HasColumnName("NameLast").IsRequired().HasMaxLength(25);
            Property(x => x.NameFull).HasColumnName("NameFull").IsOptional().HasMaxLength(77).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(x => x.Sex).HasColumnName("Sex").IsRequired().IsFixedLength().HasMaxLength(1);
            Property(x => x.BirthDate).HasColumnName("BirthDate").IsOptional();
            Property(x => x.AddressPrimary).HasColumnName("Address_Primary").IsOptional().HasMaxLength(75);
            Property(x => x.AddressSecondary).HasColumnName("Address_Secondary").IsOptional().HasMaxLength(50);
            Property(x => x.City).HasColumnName("City").IsOptional().HasMaxLength(50);
            Property(x => x.State).HasColumnName("State").IsOptional().HasMaxLength(20);
            Property(x => x.Zip).HasColumnName("Zip").IsOptional().HasMaxLength(20);
            Property(x => x.CustodyDate).HasColumnName("CustodyDate").IsOptional();
            Property(x => x.ReleaseDatePotential).HasColumnName("ReleaseDatePotential").IsOptional();
            Property(x => x.ReleaseDateActual).HasColumnName("ReleaseDateActual").IsOptional();
            Property(x => x.IsReleased).HasColumnName("IsReleased").IsRequired();
            Property(x => x.IsInfirmaryHoused).HasColumnName("IsInfirmaryHoused").IsRequired();
            Property(x => x.LastModifiedDate).HasColumnName("LastModifiedDate").IsOptional();
            Property(x => x.ConcurrencyId).HasColumnName("ConcurrencyId").IsOptional();
            Property(x => x.InmateTypeId).HasColumnName("InmateTypeId").IsRequired();
            Property(x => x.SiteDepartmentId).HasColumnName("SiteDepartmentId").IsRequired();
            Property(x => x.IsPreSentenced).HasColumnName("IsPreSentenced").IsOptional();
            Property(x => x.IsSentenced).HasColumnName("IsSentenced").IsOptional();
            Property(x => x.SentenceDate).HasColumnName("SentenceDate").IsOptional();
            Property(x => x.IsJuvenile).HasColumnName("IsJuvenile").IsOptional();
            Property(x => x.IsDeceased).HasColumnName("IsDeceased").IsOptional();
            Property(x => x.LocDisplay).HasColumnName("Loc_Display").IsOptional().HasMaxLength(25);
            Property(x => x.LocFacility).HasColumnName("Loc_Facility").IsOptional().HasMaxLength(25);
            Property(x => x.LocBuilding).HasColumnName("Loc_Building").IsOptional().HasMaxLength(25);
            Property(x => x.LocFloor).HasColumnName("Loc_Floor").IsOptional().HasMaxLength(15);
            Property(x => x.LocCellBlock).HasColumnName("Loc_CellBlock").IsOptional().HasMaxLength(15);
            Property(x => x.LocUnit).HasColumnName("Loc_Unit").IsOptional().HasMaxLength(15);
            Property(x => x.LocCell).HasColumnName("Loc_Cell").IsOptional().HasMaxLength(15);
            Property(x => x.LocBed).HasColumnName("Loc_Bed").IsOptional().HasMaxLength(15);
            Property(x => x.LocOffsiteCode).HasColumnName("Loc_OffsiteCode").IsOptional().HasMaxLength(50);
            Property(x => x.EldoradoSsnId).HasColumnName("EldoradoSSN_Id").IsOptional().IsUnicode(false).HasMaxLength(50);
            Property(x => x.PreferredLanguageId).HasColumnName("PreferredLanguageId").IsOptional();

            Ignore(x => x.LastModifiedUser);
            Ignore(x => x.DateCreated);
        }
    }
}
