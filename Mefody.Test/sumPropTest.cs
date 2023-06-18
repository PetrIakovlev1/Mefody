using MefodyLibrary;
using MefodyLibrary.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mefody.Test
{
    [TestClass]
    public class sumPropTest
    {
        [DataTestMethod]
        [DataRow(31, "М", "Р", "тридцати одного")]
        [DataRow(22, "С", "Т", "двадцатью двумя")]
        [DataRow(154323, "М", "И", "сто пятьдесят четыре тысячи триста двадцать три")]
        [DataRow(154323, "М", "Т", "ста пятьюдесятью четырьмя тысячами тремястами двадцатью тремя")]
        public void sumProp(long nSum, string sGender, string sCase, string expectedResult)
        {
            NumberAnalyzer analyzer = new NumberAnalyzer();

            var calculatedResult= analyzer.ToString(nSum, InputConverter.GetCase(sCase), InputConverter.GetGender(sGender));
            Assert.AreEqual(calculatedResult, expectedResult);
        }

    }
}
