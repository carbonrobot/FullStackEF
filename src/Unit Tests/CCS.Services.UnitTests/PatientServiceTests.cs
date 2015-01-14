namespace CCS.Services.UnitTests
{
    using System.Collections.Generic;
    using System.Linq;
    using Core;
    using Criteria;
    using Data;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class PatientServiceTests
    {
        private Mock<IUCareDataContext> _mockDataContext;
        private PatientService _service;

        [TestInitialize]
        public void Setup()
        {
            _mockDataContext = new Mock<IUCareDataContext>();
            _service = new PatientService(() => _mockDataContext.Object);
        }
        
        [TestMethod]
        public void Can_Get_Patients_By_Id()
        {
            _mockDataContext
                .Setup(context => context.Get<Patient>(12))
                .Returns(new Patient(){ Id = 12 });

            var response = _service.Get(12);
            Assert.IsFalse(response.HasError);

            var patient = response.Result;
            Assert.AreEqual(patient.Id, 12);
        }

        [TestMethod]
        public void Can_Get_Patients_By_Last_Name()
        {
            var list = new List<Patient>()
            {
                new Patient() {NameLast = "Archer", NameFirst = "Mallory"},
                new Patient() {NameLast = "Archer", NameFirst = "Sterling"},
                new Patient() {NameLast = "Krieger", NameFirst = "Victor"},
                new Patient() {NameLast = "Boones", NameFirst = "Samuel"}
            };

            _mockDataContext
                .Setup(context => context.AsQueryable<Patient>())
                .Returns(list.AsQueryable());

            var response = _service.Find(new PatientSearchCriteria()
            {
                LastName = "Archer"
            });
            Assert.IsFalse(response.HasError);
            Assert.AreEqual(2, response.Result.Count);
        }

    }
}
