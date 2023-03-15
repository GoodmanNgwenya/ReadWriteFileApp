using ReadWriteFileApp;

namespace ReadWriteFileApp.nUnitTests
{
    [TestFixture]
    public class FrequencyOfFirstAndLastnameTests
    {
        [Test]
        public void FrequencyOfFirstAndLastname_ShouldWriteToFile()
        {
            // Arrange
            string[] firstname = { "Champion", "Goodman", "Champion", "Champion", "Goodman", "Lindokuhle" };
            string tempFilePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;

            // Act
            Program.FrequencyOfFirstAndLastname(firstname, tempFilePath);

            // Assert
            string[] expectedLines = { "Champion,3", "Goodman,2", "Lindokuhle,1" };
            string[] actualLines = File.ReadAllLines(tempFilePath + "/firstFile.txt");
           
            Assert.That(expectedLines, Is.EqualTo(actualLines));
        }

        [Test]
        public void FrequencyOfFirstAndLastname_ShouldNotWriteToFile()
        {
            // Arrange
            string[] firstname = { "Champion", "Goodman", "Champion", "Champion", "Goodman", "Lindokuhle" };
            string tempFilePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;

            // Act
            Program.FrequencyOfFirstAndLastname(firstname, tempFilePath);

            // Assert
            string[] expectedLines = { "Champion,3",  "Lindokuhle,1", "Goodman,2"};
            string[] actualLines = File.ReadAllLines(tempFilePath + "/firstFile.txt");

            Assert.That(expectedLines, Is.Not.EqualTo(actualLines));
        }

        [Test]
        public void SortAddressAlphabetically_ShouldWriteToFile()
        {
            // Arrange
            string[] address = { "14 Champ St", "15 Gman St", "120 Jonson St", "122 Ave", "144 Sandton Ave" };
            List<string> nameAndSurnameList = new List<string> { "Champion Dlamini", "Goodman Ngwenya", "Sendzo Ngele", "Lindokuhle Motha" };
            string tempFilePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;

            // Act
            Program.SortAddressAlphabetically(address, nameAndSurnameList);

            // Assert
            string[] expectedLines = { "122 Ave", "14 Champ St", "15 Gman St", "120 Jonson St", "144 Sandton Ave", "", "Champion Dlamini", "Goodman Ngwenya", "Sendzo Ngele", "Lindokuhle Motha" };
            string[] actualLines = File.ReadAllLines(tempFilePath + "/secondFile.txt");
           
            Assert.That(expectedLines,Is.EqualTo(actualLines));
        }

        [Test]
        public void SortAddressAlphabetically_ShouldNotWriteToFile()
        {
            // Arrange
            string[] address = { "14 Champ St", "15 Gman St", "120 Jonson St", "122 Ave", "144 Sandton Ave" };
            List<string> nameAndSurnameList = new List<string> { "Champion Dlamini", "Goodman Ngwenya", "Sendzo Ngele", "Lindokuhle Motha" };
            string tempFilePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;

            // Act
            Program.SortAddressAlphabetically(address, nameAndSurnameList);

            // Assert
            string[] expectedLines = { "122 Ave", "120 Jonson St", "144 Sandton Ave", "14 Champ St", "15 Gman St",  "", "Champion Dlamini", "Goodman Ngwenya", "Sendzo Ngele", "Lindokuhle Motha" };
            string[] actualLines = File.ReadAllLines(tempFilePath + "/secondFile.txt");

            Assert.That(expectedLines, Is.Not.EqualTo(actualLines));
        }
    }
}

