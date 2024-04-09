namespace School_API.Data
{
    public class StringFunctions
    {
        public string Concatinate(string str1, string str2)
        {
            return str1 + str2;
        }

        public bool IsPalindrome(string str)
        {
            string reversed = new (str.Reverse().ToArray());
            return str.Equals(reversed, StringComparison.OrdinalIgnoreCase);
        }
    }
}
