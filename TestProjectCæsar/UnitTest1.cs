using cæsarkryptering;
namespace TestProjectCæsar
{
    public class UnitTest1
    {
        [Fact]
        public void usingOnly26Letters()
        {
            Assert.Equal("JGL", encrypt.simplekrypt("HEJ"));
            Assert.Equal("HEJ", encrypt.simplekrypt("JGL", -2));
            
        }
        [Fact]
        public void Reversal()
        {
            Assert.Equal("FDS", encrypt.simplekrypt(encrypt.simplekrypt("FDS", 20), -20));
        }

        [Fact]
        public void Vigineer()
        {

            Assert.NotEqual("hejsa rune".ToUpper(), encrypt.advancedencrypt("hejsa rune", "B"));

        }
        [Fact]
        public void VigiDecrypt()
        {
            string input = "heeeasdlgfhjioxcvbcxviou".ToUpper();
            string key = "LOLKA";
            string test = encrypt.advancedencrypt(input, key);
            Assert.Equal(input,encrypt.advanceddecrypt(test,key));
        }
    }
}