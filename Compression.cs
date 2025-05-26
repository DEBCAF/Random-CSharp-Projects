using System.Text.RegularExpressions;

static string enter()
{
    string word = "";
    while (word == "" || !(Regex.IsMatch(word, @"^[a-zA-Z]\w*$")))
    {
        Console.Write("Enter your word: ");
        word = Console.ReadLine();
    }
    return word;
}

static string comp(string word, int count, bool have, string letter)
{
    List<string> letters = new List<string>();
    for (int i = 0; i < word.Length-1; i++)
    {
        if (word[i] == word[i + 1])
        {
            count = count + 1;
            letter = word[i].ToString();
            have = true;
        }
        else if (have == true)
        {
            letters.Add(letter);
            letters.Add(count.ToString());
            have = false;
        }
        else
        {
            letters.Add(word[i].ToString());
        }

        if (i == word.Length - 2 && !(word[i]==word[i+1]))
        {
            letters.Add(word[i+1].ToString());
        }
    }
    if (have == true)
    {
        letters.Add(letter);
        letters.Add(count.ToString());
        have = false;
    }
    return letters.Aggregate("", (current, letter) => current + letter);
}

static string decomp(string word)
{
    List<string> letters = new List<string>();
    for (int i = 0; i < word.Length; i++)
    {
        string letter = word[i].ToString();
        if (Regex.IsMatch(letter, @"^[a-zA-Z]\w*$"))
        {
            letters.Add(letter);
        }
        else
        {
            int count = int.Parse(letter);
            for (int j = 0; j < count; j++)
            {
                letters.Add(word[i-1].ToString());
            }
        }
    }
    return letters.Aggregate("", (current, letter) => current + letter);
}

// Main Program 
int count = 1;
bool have = false;
string letter = "";

Console.WriteLine(comp(enter(), count, have, letter));
Console.WriteLine(decomp(enter()));