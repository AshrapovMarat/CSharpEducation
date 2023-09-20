using System;
using System.Net;
using System.Threading.Tasks;

namespace AsynFileDownload
{
  internal class Program
  {
    static async Task Main(string[] args)
    {
      while (true)
      {
        string url, path;

        Console.WriteLine("Ведите URL-адрес файла которого надо скачать.");
        url = Console.ReadLine();
        Console.WriteLine("Введите путь файла");
        path = Console.ReadLine();

        DownloadFileAsync(url, path);
      }
    }

    /// <summary>
    /// Метод для скачивания файла.
    /// </summary>
    /// <param name="url">Url - адрес файла.</param>
    /// <param name="path">Путь с названием файла, куда надо сохранить файл.</param>
    static void Download(string url, string path)
    {
      using (var client = new WebClient())
      {
        client.DownloadFile(new Uri(url), path);
      }
    }

    /// <summary>
    /// Асинхронный метод скачивания файла.
    /// </summary>
    /// <param name="url">Url - адрес файла.</param>
    /// <param name="path">Путь с названием файла, куда надо сохранить файл.</param>
    /// <returns></returns>
    async static void DownloadFileAsync(string url, string path)
    {
      await Task.Run(() => Download(url, path));
    }
  }
}
