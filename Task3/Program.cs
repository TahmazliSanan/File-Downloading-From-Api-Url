using Newtonsoft.Json;

namespace Task3
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await FetchData("https://dog.ceo/api/breeds/image/random");
            Console.ReadLine();
        }

        public static async Task FetchData(string url)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(url);
            var json = JsonConvert.DeserializeObject<DogImage>(response);
            if (json != null)
            {
                json.DisplayData();
                await DownloadFileFromUrl(json.Message);
            }
        }

        public static async Task DownloadFileFromUrl(string imageUrl)
        {
            var httpClient = new HttpClient();
            var imageBytes = await httpClient.GetByteArrayAsync(imageUrl);

            // Determine the file name and path
            var fileName = Path.GetFileName(imageUrl);
            const string downloadsPath = @"C:\Users\user\Downloads";
            var filePath = Path.Combine(downloadsPath, fileName);

            // Write bytes to file
            await File.WriteAllBytesAsync(filePath, imageBytes);
        }
    }
}
