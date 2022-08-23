// Your task is to write a simple morse encoder/decoder.
// You are allowed to lookup morse code on wikipedia.

// To separate letters from each other a single space is used.
// To separate words from one another three space characters are used.

// A map of morse code to characters exists in the MorseAlphabet.cs file.

using MorseCodeInterpreter;

string toBeDecoded = "-.. . -.-. --- -.. .   -- .   --..-.   .--. .-. --- .--. . .-. .-.. -.-- -.-.--";
string toBeEncoded = "Encode me - properly!";

var invertedDictionary = MorseAlphabet.CharacterMap.ToDictionary(x => x.Value, x => x.Key);

string decodedMorseString = string.Empty;
var encodedWords = toBeDecoded.Split("   ");
foreach (var word in encodedWords)
{
    foreach(var c in word.Split(' '))
    {
        decodedMorseString += MorseAlphabet.CharacterMap[c];
    }

    if (word != encodedWords.Last())
    {
        decodedMorseString += ' ';
    }
}

// Print the decoded morse code to the console.
Console.WriteLine(decodedMorseString);

string encodedMorseString = string.Empty;
var decodedWords = toBeEncoded.Split(' ');
foreach (var word in decodedWords)
{
    foreach (var c in word)
    {
        if (invertedDictionary.TryGetValue(char.ToUpper(c), out string encodedMorseChar))
        {
            encodedMorseString += encodedMorseChar;
        }

        if (c != word.Last())
        {
            encodedMorseString += ' ';
        }
    }

    if (word != decodedWords.Last())
    {
        encodedMorseString += "   ";
    }
}

// Print the encoded morse code to the console.
Console.WriteLine(encodedMorseString);


Console.ReadKey();
