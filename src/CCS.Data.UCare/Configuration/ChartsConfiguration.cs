namespace CCS.Data.UCare.Configuration
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;
    using Core;

    internal class ChartsConfiguration : EntityTypeConfiguration<Chart>
    {
        public ChartsConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".Charts");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.PatientId).HasColumnName("PatientId").IsRequired();
            Property(x => x.BookingNumber).HasColumnName("BookingNumber").IsOptional().IsUnicode(false).HasMaxLength(50);
            Property(x => x.IncarcerationDate).HasColumnName("IncarcerationDate").IsRequired();
            Property(x => x.ReleaseDate).HasColumnName("ReleaseDate").IsOptional();
            Property(x => x.LastModifiedUser).HasColumnName("LastModifiedUser").IsOptional().IsUnicode(false).HasMaxLength(50);
            Property(x => x.LastModifiedDate).HasColumnName("LastModifiedDate").IsOptional();
            Property(x => x.IsCurrent).HasColumnName("IsCurrent").IsOptional();
            Property(x => x.DateCreated).HasColumnName("DateCreated").IsOptional();

            // Foreign keys
            HasRequired(a => a.Patient).WithMany(b => b.Charts).HasForeignKey(c => c.PatientId); // fkCharts_Patients
        }
    }
}
