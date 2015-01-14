namespace CCS.Core
{
    using System;

    public class Chart
    {
        public Chart()
        {
        }

        public string BookingNumber { get; set; }

        public DateTime? DateCreated { get; set; }

        public int Id { get; set; }

        public DateTime IncarcerationDate { get; set; }

        public bool? IsCurrent { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        public string LastModifiedUser { get; set; }

        public virtual Patient Patient { get; set; }

        public int PatientId { get; set; }

        public DateTime? ReleaseDate { get; set; }

    }
}