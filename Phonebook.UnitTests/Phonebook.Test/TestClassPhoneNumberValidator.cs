using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.Test
{
  internal class TestClassPhoneNumberValidator
  {
    /// <summary>
    /// Проверка на некорректный ввод номера пользователя.
    /// </summary>
    /// <param name="number">Номер абонента.</param>
    [TestCase("+1(555)555-5A55")]
    [TestCase("1(ggg)555-5555")]
    [TestCase("+1(555)555-55557")]
    [TestCase("+1(555)555-555")]
    [TestCase("+1(555)55-5555")]
    [TestCase("+1(55)555-5555")]
    [TestCase("+1(55)555-5555")]
    public void InvalidPhoneNumberTest(string number)
    {
      var phoneNumber = new PhoneNumber(number, PhoneNumberType.Personal);

      Assert.Throws<ArgumentException>(() => PhoneNumberValidator.Validate(phoneNumber));
    }
  }
}
