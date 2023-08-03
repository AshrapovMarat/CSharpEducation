using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Phonebook
{
  internal class Abonent
  {
    private string username;
    private string phoneNumber;
    public string Username
    {
      get
      {
        return username;
      }
    }
    public string PhoneNumber
    {
      get
      {
        return phoneNumber;
      }
    }
    public Abonent(string username, string phoneNumber)
    {
        this.username = username.Trim();
        this.phoneNumber = phoneNumber.Trim();
    }
  }
}
