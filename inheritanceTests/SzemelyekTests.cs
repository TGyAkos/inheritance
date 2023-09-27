using inheritance;

namespace inheritanceTests
{
    [TestClass]
    public class SzemelyekTests
    {
        public TestContext TestContext { get; set; }
        private Szemelyek SzemelyekClass { get; set; }
        private string NoLakcim;

        [TestInitialize]
        public void SzemelyekTestInit()
        {
            string nev = "ASD";

            int ev = 1999;
            int honap = 11;
            int nap = 2;
            int[] birthDate = { ev, honap, nap };

            string lakcim = "Matyas Utca 2.";
            Szemelyek szemelyek;

            if (TestContext.Properties.Contains("NoLakcim"))
            {
                NoLakcim = TestContext.Properties["Nolakcim"] as string; 
                szemelyek = new(nev, birthDate);
            }
            else
            {
                szemelyek = new(nev, birthDate, lakcim);

            }

            SzemelyekClass = szemelyek;
        }

        [TestCleanup]
        public void SzemelyekTestCleanp()
        {
            TestContext = null;
            SzemelyekClass = null;
            NoLakcim = null;
        }

        [TestMethod]
        public void SzemelyekIndexer_CorrectBirthDateSupplied_ReturnCorrectValueByIndexer()
        {
            int expectedYear = 1999;
            int expectedHonap = 11;
            int expectedNap = 02;

            int actualYear = SzemelyekClass["ev"];
            int actualHonap = SzemelyekClass["honap"];
            int actualNap = SzemelyekClass["nap"];

            Assert.AreEqual(expectedYear, actualYear);
            Assert.AreEqual(expectedHonap, actualHonap);
            Assert.AreEqual(expectedNap, actualNap);
        }

        [TestMethod]
        public void ToString_CorrectDataSupplied_ReturnsCustomToString()
        {
            string expected = "Nev: ASD, Lakcim: Matyas Utca 2., Szuletesi datum: 1999.11.2";
            string actual = SzemelyekClass.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestProperty("NoLakcim", "true")]
        public void SzemelyekDefaultConstructorValue_NoLakcimSupplied_AddsDefaultValueAsLakcim()
        {
            Console.WriteLine($"NoLakcim = {NoLakcim}");

            string expected = "Nincs megadva";
            string actual = SzemelyekClass.Lakcim;

            Assert.AreEqual(expected, actual);
        }

    }
}
