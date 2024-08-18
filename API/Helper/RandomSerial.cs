namespace API.Helper
{
    public static class RandomSerial
    {
        
        private static Random _random = new Random();
        public static string GenerateSerial(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[_random.Next(s.Length)]).ToArray());
        }
    }
}
