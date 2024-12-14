namespace Task3
{
    public class DogImage
    {
        public string Message { get; set; }
        public string Status { get; set; }

        public void DisplayData()
        {
            Console.WriteLine($"Message: {Message}");
            Console.WriteLine($"Status: {Status}");
        }
    }
}
