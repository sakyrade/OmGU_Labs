using Lab_1;
using Lab_1.menu_tasks;
using Lab_1.regex_strings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Lab_1
{
    [TestFixture]
    public class UnitTestStringsTask
    {

        [SetUp]
        public void Setup() { }

        [Test]
        public void TestNormalizeString()
        {
            string result = StringsTask.NormalizeString("    ggg@mail.ru    ");

            Assert.That(result, Is.EqualTo("ggg@mail.ru"));
        }

        [Test]
        public void TestIsRegexValid()
        {
            Assert.DoesNotThrow(() => StringsTask.IsRegexValid("ggg@mail.ru", new EmailRegexString()));
        }

        [Test]
        public void TestIsRegexValidException()
        {
            Assert.Catch<ValidationException>(() => StringsTask.IsRegexValid("ggg@mail.ru", new PhoneNumberRegexString()));
        }

        [Test]
        public void TestIsReverse()
        {
            Assert.DoesNotThrow(() => StringsTask.IsReverse("ggg@mail.ru", "ur.liam@ggg"));
        }

        [Test]
        public void TestIsReverseException()
        {
            Assert.Catch<ValidationException>(() => StringsTask.IsReverse("ggg@mail.ru", "ggg@mail.ru"));
        }

        [Test]
        public void TestIsEqual()
        {
            Assert.DoesNotThrow(() => StringsTask.IsEqual("ggg@mail.ru", "ggg@mail.ru"));
        }

        [Test]
        public void TestIsEqualException()
        {
            Assert.Catch<ValidationException>(() => StringsTask.IsEqual("ggg@mail.ru", "gg@mail.ru"));
        }

        [Test]
        public void TestReverse()
        {
            Assert.That(StringsTask.Reverse("ggg@mail.ru"), Is.EqualTo("ur.liam@ggg"));

            Assert.That(StringsTask.Reverse("ur.liam@ggg"), Is.EqualTo("ggg@mail.ru"));
        }
    }
}
