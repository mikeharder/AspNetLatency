using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Program
    {
        private static string test = @"{""foo"":""dafgdsfgsdfg"",""bar"":""fddfsafdsf""}";

        public static void Main(string[] args)
        {
            var url = args[0];
            var sw = new Stopwatch();

            Console.WriteLine("GET");
            sw.Start();
            for (int i = 0; i < 20; i++)
            {
                TestCall(url, "GET").Wait();
            }
            sw.Stop();
            Console.WriteLine("Total Elapsed={0} ms", sw.Elapsed.TotalMilliseconds);

            Console.WriteLine("POST");
            sw.Restart();
            for (int i = 0; i < 20; i++)
            {
                TestCall(url, "POST").Wait();
            }
            sw.Stop();
            Console.WriteLine("Total Elapsed={0} ms", sw.Elapsed.TotalMilliseconds);
        }

        private static async Task TestCall(string url, string method)
        {
            var sw = new Stopwatch();

            sw.Start();
            using (var client = new HttpClient())
            {
                if (method == "GET")
                {
                    var response = await client.GetAsync(url);
                }
                else if (method == "POST")
                {
                    var payload = new StringContent(test, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(url, payload);
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
            sw.Stop();

            Console.WriteLine("Elapsed={0} ms", sw.Elapsed.TotalMilliseconds);
        }
    }
}
