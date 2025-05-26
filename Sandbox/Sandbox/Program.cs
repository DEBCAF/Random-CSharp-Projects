class Program
{
    public static string ToOctal(int num)
    {
        if (num < 0)
        {
            return "Invalid input: negative number";
        }
        if (num == 0)
        {
            return "0";
        }

        string octal = "";
        while (num > 0)
        {
            octal = (num % 8).ToString() + octal;
            num /= 8;
        }
        return octal;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Enter a number: ");
        int num = int.Parse(Console.ReadLine());
        Console.WriteLine(ToOctal(num));
    }
}