using Lab1Problem2.Models;
using System;

namespace Lab1P2_UnitTest
{
    public class Tests
    {
        private CalcCharges gc { get; set; } = null;

        [SetUp]
    public void Setup()
    {
        gc = new CalcCharges();
    }

    [Test]
    public void getChargesTest()
    {
        double a = 12, b = 1000, expectedResult = 9.6;

        var results = gc.getCharges(a, b);

        Assert.AreEqual(expectedResult, results);
        Assert.That(results, Is.TypeOf<double>());
    }
}
}
