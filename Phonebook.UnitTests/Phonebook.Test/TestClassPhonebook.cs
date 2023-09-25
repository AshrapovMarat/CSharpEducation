namespace Phonebook.Test
{
  public class TestClassPhonebook
  {

    /// <summary>
    /// Проверка на не нахождения пользователя.
    /// </summary>
    /// <param name="number">Имя абонента, которого нужно добавить.</param>
    /// <param name="name">Номер абонента, которого нужно добавить.</param>
    /// <param name="numbers">Массив номеров телефона, которые записаны в телефоную книгу.</param>
    /// <param name="names">Массив имен, которые записаны в телефоную книгу.</param>
    [TestCase("+1(123)555-5555", "Олег", new string[] { "+1(123)555-5555" }, new string[] { "Олег" })]
    [TestCase("+1(123)555-5555", "Олег", new string[] { "+1(123)555-5555", "+1(321)555-5555", "+1(213)555-5555" }, new string[] { "Олег", "Кирилл", "Саша" })]
    [TestCase("+1(321)555-5555", "Олег", new string[] { "+1(123)555-5555", "+1(321)555-5555", "+1(213)555-5555" }, new string[] { "Данил", "Олег", "Саша" })]
    [TestCase("+1(213)555-5555", "Олег", new string[] { "+1(123)555-5555", "+1(321)555-5555", "+1(213)555-5555" }, new string[] { "Данил", "Кирилл", "Олег" })]
    public void UserNotFoundTest(string number, string name, string[] numbers, string[] names)
    {
      Phonebook phonebook = new Phonebook();
      List<PhoneNumber> phoneNumbers;
      Subscriber subscriber;

      if (numbers != null && names != null)
      {
        for (int i = 0; i < numbers.Length; i++)
        {
          phoneNumbers = new List<PhoneNumber>() { new PhoneNumber(numbers[i], PhoneNumberType.Personal) };
          subscriber = new Subscriber(names[i], phoneNumbers);
          phonebook.AddSubscriber(subscriber);
        }
      }

      phoneNumbers = new List<PhoneNumber>() { new PhoneNumber(number, PhoneNumberType.Personal) };
      subscriber = new Subscriber(name, phoneNumbers);

      Assert.Throws<InvalidOperationException>(() => phonebook.AddSubscriber(subscriber));
    }
  }
}