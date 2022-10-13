using Bongo.Core.Services;
using Bongo.DataAccess.Repository.IRepository;
using Bongo.Models.Model;
using Bongo.Models.Model.VM;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bongo.Core
{
    [TestFixture]
    public class StudyRoomBookingServiceTests
    {
        private StudyRoomBooking _request;
        private List<StudyRoom> _availableStudyRoom;
        private Mock<IStudyRoomBookingRepository> _studyRoomBookingRepoMock;
        private Mock<IStudyRoomRepository> _studyRoomRepoMock;
        private StudyRoomBookingService _bookingService;
        [SetUp]
        public void Setup()
        {
            _request = new StudyRoomBooking
            {
                FirstName = "Ben",
                LastName = "Spark",
                Email = "ben@gmail.com",
                Date = new DateTime(2022, 1, 1)
            };

            _availableStudyRoom = new List<StudyRoom>
            {
                new StudyRoom{
                    Id = 10,
                    RoomName="Michigan",
                    RoomNumber="A202"
                }
            };

            _studyRoomBookingRepoMock = new Mock<IStudyRoomBookingRepository>();
            _studyRoomRepoMock = new Mock<IStudyRoomRepository>();
            _studyRoomRepoMock.Setup(x => x.GetAll()).Returns(_availableStudyRoom);
            _bookingService = new StudyRoomBookingService(
                _studyRoomBookingRepoMock.Object,
                _studyRoomRepoMock.Object);
        }
        [TestCase]
        public void GetAllBooking_InvokeMethod_CheckIfRepoIsCalled()
        {
            _bookingService.GetAllBooking();
            _studyRoomBookingRepoMock.Verify(x=> x.GetAll(null),Times.Once());
        }
        [TestCase]
        public void BookingException_NullREquest_ThrowsException()
        {
            var exception = Assert.Throws<ArgumentNullException>(() =>
            _bookingService.BookStudyRoom(null)); 
            Assert.AreEqual("request",exception.ParamName);
        }
        [Test]
        public void BookNotInvoked_SaveBookingWithoutAvailableRoom_BookingMethodNotInvoked()
        {
            _availableStudyRoom.Clear();
            var result = _bookingService.BookStudyRoom(_request);
            _studyRoomBookingRepoMock.Verify(x=>x.Book(It.IsAny<StudyRoomBooking>()), Times.Never());

        }
        [TestCase(0, false)]
        [TestCase(55, true)]
        public void StudyRoomBooking_SaveBookingWithAvailableRoom_ReturnsResultWithAllValues(int excpectedBookingId, bool roomAvailability)
        {
            if (!roomAvailability)
            {
                _availableStudyRoom.Clear();
            }
            _studyRoomBookingRepoMock.Setup(x => x.Book(It.IsAny<StudyRoomBooking>()))
                .Callback<StudyRoomBooking>(booking =>
                {
                    booking.BookingId = 55;

                });
            var result = _bookingService.BookStudyRoom(_request);
            Assert.AreEqual(excpectedBookingId, result.BookingId);

        }
        [TestCase(true, ExpectedResult = StudyRoomBookingCode.Success)]
        [TestCase(false, ExpectedResult = StudyRoomBookingCode.NoRoomAvailable)]
        public StudyRoomBookingCode StudyRoomBookingCode_ResultCodeSuccess_RoomAvability_ReturnSucessResultCode(bool roomAvailability)
        {
            if (!roomAvailability)
            {
                _availableStudyRoom.Clear();
            }
            return _bookingService.BookStudyRoom(_request).Code;
        }
    }
}
