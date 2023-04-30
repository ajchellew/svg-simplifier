// See https://aka.ms/new-console-template for more information
Console.WriteLine("Paste SVG path and press enter");

//var input = "M 8.3422508,4.6845012 3.770064,10.171126 h 2.7433121 v 7.315498 h 3.6577489 v -7.315498 h 2.743312 L 8.3422508,4.6845012 M 17.486624,13.828875 V 6.5133759 h -3.657749 v 7.3154991 h -2.743312 l 4.572186,5.486624 4.572187,-5.486624 z";
//var input = "M 10 2 L 4.0195312 8 L 4 20 C 4 21.099999 4.9000011 22 6 22 L 18 22 C 19.099999 22 20 21.099999 20 20 L 20 4 C 20 2.9000011 19.099999 2 18 2 L 10 2 z M 12.011719 6.5136719 C 12.525886 6.5119375 13.039819 6.5761639 13.535156 6.7128906 C 14.523548 6.9749238 15.368188 7.7550778 15.611328 8.7617188 C 15.947106 10.011966 15.576859 11.398011 14.703125 12.345703 C 13.70291 13.514015 12.193895 14.097681 11.205078 15.275391 C 11.077779 15.444002 10.96301 15.639832 10.962891 15.857422 L 15.712891 15.857422 L 15.712891 17.904297 L 8.2597656 17.904297 C 8.2541956 17.011853 8.2195964 16.07891 8.6621094 15.269531 C 9.2354038 14.018028 10.369862 13.179013 11.458984 12.402344 C 12.193425 11.830957 13.049017 11.19131 13.195312 10.207031 C 13.29439 9.5976636 13.075777 8.8495566 12.441406 8.6269531 C 11.199156 8.2122247 9.834536 8.7365046 8.8828125 9.5605469 C 8.7215494 9.7108962 8.8317649 9.2688249 8.7988281 9.140625 L 8.7988281 7.4589844 C 9.7463521 6.8455182 10.880551 6.5174875 12.011719 6.5136719 z";
var input = Console.ReadLine();
if (input == null || string.IsNullOrEmpty(input))
{
    Console.WriteLine("Nothing input");
    Console.ReadLine();
    return;
}

Console.WriteLine($"Current: {input.Length} chars");
Console.WriteLine();

var result = "";
var pos = 0;
while (pos < input.Length)
{
    // parse for spaces and commas
    var indexOfAny = input.IndexOfAny(new[] { ' ', ',' }, pos);
    if (indexOfAny >= 0)
    {
        var endChar = input[indexOfAny];

        var substring = input.Substring(pos, indexOfAny - pos);
        
        if (int.TryParse(substring, out int intValue))
        {
            // convert int put back on with the end char
            result += "" + intValue + endChar;
        }
        else if (double.TryParse(substring, out double doubleValue))
        {
            // convert double to one decimal place and put back on the end char
            result += doubleValue.ToString("F1") + endChar;
        }
        else
        {
            // anything else is a letter.. can remove the spaces
            result += substring;
        }
        pos = indexOfAny + 1;
    }
    else
    {
        // if the string ends with a space now it can be removed
        if (result[^1] == ' ')
        {
            result = result.Substring(0, result.Length - 1);
        }

        // put the end char on
        var substring = input.Substring(pos);
        
        result += substring;
        pos = pos + substring.Length;
    }
}
Console.WriteLine(result);
Console.WriteLine($"Simplifed: {result.Length} chars");
Console.ReadLine();