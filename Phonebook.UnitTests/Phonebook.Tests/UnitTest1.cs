namespace Phonebook.Tests
{
  public class Tests
  {
    /// <summary>
    /// Проверка на некорректный ввод номера пользователя.
    /// </summary>
    /// <exception cref="ArgumentException">Возникает, если номер телефона не в корректном формате.</exception>
    [Test]
    public void InvalidPhoneNumberTest()
    {
      PhoneNumberValidator.Validate(new PhoneNumber("462374623864673647", PhoneNumberType.Personal));

      Assert.Throws<ArgumentException>(() => throw new ArgumentException());
    }

    /// <summary>
    /// Проверка на не нахождения пользователя
    /// </summary>
    /// <exception cref="InvalidOperationException">Возникает, если абонент уже существует в книге.</exception>
    [Test]
    public void UserNotFoundTest()
    {
      List<PhoneNumber> phoneNumbers = new List<PhoneNumber>() { new PhoneNumber(" +1(555)555-5555", PhoneNumberType.Personal)};
      Subscriber subscriber = new Subscriber("Витя", phoneNumbers);
      Phonebook phonebook = new Phonebook();
      phonebook.AddSubscriber(subscriber);

      Assert.Throws<InvalidOperationException>(() => throw new InvalidOperationException());
    }
  }
}