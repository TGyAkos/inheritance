using inheritance;

namespace inheritanceTests
{
    [TestClass]
    public class AlkalmazottTests
    {
        public TestContext TestContext { get; set; }
        private Alkalmazott AlkalmazottClass { get; set; }

        [TestInitialize]
        public void InitAlkalmazottTest()
        {
            string nev = "ASD";
            string beosztas = "Vezeto";
            int fizetes = 10000;

            if (TestContext.Properties.Contains("Fizetes"))
            {
                fizetes = int.Parse(TestContext.Properties["Fizetes"] as string);
                TestContext.WriteLine(fizetes.ToString());
                AlkalmazottClass = new Alkalmazott(nev, beosztas, fizetes);
            }
            else if (TestContext.Properties.Contains("OnlyNev"))
            {
                AlkalmazottClass = new Alkalmazott(nev);
            }
            else
            {
                AlkalmazottClass = new Alkalmazott(nev, beosztas, fizetes);
            }

        }

        [TestCleanup]
        public void AlkalmazottTestCleanup()
        {
            TestContext = null;
            AlkalmazottClass = null;
        }

        [TestMethod]
        public void AlakmazottNevGetter_GetNevProperty_ReturnsStringArray()
        {
            string[] expected = {"ASD", "Vezeto"};
            string[] actual = AlkalmazottClass.Nev;


            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FizetesEmeles_CorrectValueSupplied_RewritesCurrentFizetesValue()
        {
            AlkalmazottClass.FizetesEmeles(25000);

            int expected = 25000;
            int actual = AlkalmazottClass.Fizetes;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestProperty("Fizetes", "25000")]
        public void Kor_FizetesLessThan300k_NoChangeInAge()
        {
            AlkalmazottClass.Kor();

            int expected = 0;
            int actual = AlkalmazottClass["ev"];

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestProperty("Fizetes", "35000000")]
        public void Kor_FizetesMoreThan300k_SubtractionFromAge()
        {
            AlkalmazottClass.Kor();

            int expected = -10;
            int actual = AlkalmazottClass["ev"];

            Assert.AreEqual(expected, actual);
        }
    }
}
