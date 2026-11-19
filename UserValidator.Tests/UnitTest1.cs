using User;
namespace UserValidator.Tests
{
    public class Tests
    {
        [TestCase(17, false)]
        [TestCase(18, true)]
        [TestCase(25, true)]
        [TestCase(0, false)]
        [TestCase(-5, false)]
        public void IsValidAge_Test(int age, bool expected)
        {
            var validator = new User.UserValidator();

            bool result = validator.IsValidAge(age);

            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase("test@gmail.com", true)]
        [TestCase("user@mail.com", true)]
        [TestCase("testgmail.com", false)]
        [TestCase("   ", false)]
        [TestCase(null!, false)]
        public void IsValidEmail_Test(string email, bool expected)
        {
            var validator = new User.UserValidator();

            bool result = validator.IsValidEmail(email);

            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase("Password123", true)]
        [TestCase("abc", false)]
        [TestCase("", false)]
        [TestCase(null!, false)]
        [TestCase("12345678", true)]
        public void IsValidPassword_Test(string password, bool expected)
        {
            var validator = new User.UserValidator();

            bool result = validator.IsValidPassword(password);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void CheckUsers()
        {
            List<string> users = new List<string>
            {
                "Anna",
                "Ivan",
                "Mykola"
            };      

            // assert-и для колекцій
            Assert.That(users, Has.Count.EqualTo(3));  // перевірка чи кількість елементів колекції = 3

            Assert.That(users, Does.Contain("Anna")); // чи колекція містить рядок "Anna"

            Assert.That(users, Does.Not.Contain("Vasil")); // чи колекція НЕ містить рядок "Vasil"
        }
    }
}
