var res = Manacher.FindLongestPalindrome("bananas");
Console.WriteLine(res);

class Manacher
{
    public static string FindLongestPalindrome(string text)
    {
        var n = text.Length;
        var strLen = 2 * n + 3;
        var sChars = new string[strLen];
        sChars[0] = "@";
        sChars[^1] = "$";

        for (var i = 1; i < sChars.Length - 1; i++)
        {
            sChars[i] = (i % 2 == 1) ? "#" : text[i / 2 - 1].ToString();
        }

        var maxLen = 0;
        var start = 0;
        var maxRight = 0;
        var center = 0;

        var p = new int[strLen];

        for (var i = 1; i < strLen - 1; i++)
        {
            if (i < maxRight)
            {
                p[i] = Math.Min(p[2 * center - i], p[i]);
            }

            while (sChars[i + p[i] + 1] == sChars[i - p[i] - 1])
            {
                p[i] += 1;
            }

            if (i + p[i] > maxRight)
            {
                center = i;
                maxRight = i + p[i];
            }

            if (p[i] > maxLen)
            {
                start = (i - p[i] - 1) / 2;
                maxLen = p[i];
            }
        }

        return text.Substring(start, start + maxLen - 1);
    }
}