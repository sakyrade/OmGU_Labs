using Lab_1.menu_tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Lab_1
{
    [TestFixture]
    public class UnitTestRecursionDateTask
    {
        [SetUp]
        public void Setup() { }

        [Test]
        public void TestCalcDateSegment()
        {
            int result = RecursionDateTask.CalcDateSegment((DateOnly.Parse("12.12.2022"), DateOnly.Parse("15.12.2022")),
                                                           (DateOnly.Parse("13.12.2022"), DateOnly.Parse("16.12.2022")));

            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void TestZeroDateSegment()
        {
            int result = RecursionDateTask.CalcDateSegment((DateOnly.Parse("13.12.2022"), DateOnly.Parse("15.12.2022")),
                                                           (DateOnly.Parse("13.12.2022"), DateOnly.Parse("20.11.2022")));

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void TestNegativeDateSegment()
        {
            int result = RecursionDateTask.CalcDateSegment((DateOnly.Parse("10.12.2022"), DateOnly.Parse("21.12.2022")),
                                                           (DateOnly.Parse("13.12.2022"), DateOnly.Parse("20.12.2022")));

            Assert.That(result, Is.EqualTo(-1));
        }

        [Test]
        public void TestAkermannFuncStackOverflow()
        {
            int result = RecursionDateTask.CalcAckermannFunction(2, 2);

            Assert.That(result, Is.EqualTo(7));
        }
    }
}
