using Microsoft.VisualStudio.TestTools.UnitTesting;
using RealCard.Core.BLL;
using RealCard.Core.DAL.Contexts;
using RealCard.Core.DAL.Models;
using TestRealCard.DataSource;

namespace TestRealCard
{

    [TestClass]
    public class FileRepositoryTest
    {
        private ImageFileRepo _fileRepo;
        private TestFileContext _context;

        [TestInitialize]
        public void TestInit()
        {
            _context = new TestFileContext();
            FileData.FillData(_context);
            _fileRepo = new ImageFileRepo(_context);
        }

        [TestMethod]
        public void Should_Insert_File()
        {
            ImageFile file = _context.files[0];

            byte[] array = file.ImageByteArray;
            _fileRepo.UploadFile(array);

            Assert.AreEqual(array, _context.files[_context.files.Count - 1].ImageByteArray);
            Assert.AreEqual(4, _context.files.Count);
        }

        public void Should_Get_File_By_Id()
        {
            int id = _context.files[0].Id;

            ImageFile file = _fileRepo.Read(id);

            Assert.AreEqual(file, _context.files[0]);
        }

        public void Should_Delete_File()
        {
            int id = _context.files[0].Id;
            _fileRepo.Delete(id);
            Assert.AreEqual(2, _context.files.Count);
        }

    }

   
}
