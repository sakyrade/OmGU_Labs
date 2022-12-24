using Lab_1;
using Lab_1.menu_tasks;

namespace Tests.Lab_1
{
    [TestFixture]
    public class UnitTestCalcTask
    {
        private CalcTask calcTask;

        [SetUp]
        public void Setup()
        {
            calcTask = new CalcTask();
        }

        [Test]
        public void TestExecute()
        {
            calcTask.Init(2, 3, 4);

            calcTask.Execute();

            Assert.That(calcTask.Result, Is.EqualTo(0.396));
        }

        [Test]
        public void TestExecuteValidationException()
        {
            calcTask.Init(-1, 3, 4);

            Assert.Catch<ValidationException>(calcTask.Execute);
        }

        [Test]
        public void TestCalcMethod()
        {
            calcTask.Init(-1, 3, 0);

            Assert.Catch<ValidationException>(calcTask.Execute);
        }
    }
}