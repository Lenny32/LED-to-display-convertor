using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BitmapTests
    {
        private static string FileNameDotnet = "Content/dotnet.bmp";
        private static string FileNameTriangle = "Content/Triangle.gif";

        [TestMethod]
        public void ReadBitmap()
        {
            var reader = new System.Image.Reader.GenericReader(FileNameDotnet);
            reader.Read();

        }

        [TestMethod]
        public void ReadImage()
        {
            var reader = new System.Image.Reader.GenericReader(FileNameDotnet);
            reader.Read();
        }


        [TestMethod]
        public void ReadFormat()
        {
            var reader = new System.Image.Reader.GenericReader(FileNameTriangle);
            var format = reader.GetFormat();
            Assert.AreEqual(format, "GIF");
        }

    }
}
