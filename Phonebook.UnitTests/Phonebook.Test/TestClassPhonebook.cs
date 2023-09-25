namespace Phonebook.Test
{
  public class TestClassPhonebook
  {

    /// <summary>
    /// �������� �� �� ���������� ������������.
    /// </summary>
    /// <param name="number">��� ��������, �������� ����� ��������.</param>
    /// <param name="name">����� ��������, �������� ����� ��������.</param>
    /// <param name="numbers">������ ������� ��������, ������� �������� � ��������� �����.</param>
    /// <param name="names">������ ����, ������� �������� � ��������� �����.</param>
    [TestCase("+1(123)555-5555", "����", new string[] { "+1(123)555-5555" }, new string[] { "����" })]
    [TestCase("+1(123)555-5555", "����", new string[] { "+1(123)555-5555", "+1(321)555-5555", "+1(213)555-5555" }, new string[] { "����", "������", "����" })]
    [TestCase("+1(321)555-5555", "����", new string[] { "+1(123)555-5555", "+1(321)555-5555", "+1(213)555-5555" }, new string[] { "�����", "����", "����" })]
    [TestCase("+1(213)555-5555", "����", new string[] { "+1(123)555-5555", "+1(321)555-5555", "+1(213)555-5555" }, new string[] { "�����", "������", "����" })]
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