using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

/// <summary>
/// A static class library(dll) providing extension methods for the string reference type.
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// A static method that encrypts a string using MD5 hash-function.The string is prsed to 16-bytes(data)
    /// and each data byte is parsed to a hexadecimal number 
    /// </summary>
    /// <param name="input">
    /// The string which we'll be encrypted
    /// </param>
    /// <returns>
    /// Returns a new string reprsented as a 32 digits hexadecimal number
    /// </returns>
    public static string ToMd5Hash(this string input)
    {
        var md5Hash = MD5.Create();
        var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
        var builder = new StringBuilder();

        for (int i = 0; i < data.Length; i++)
        {
            builder.Append(data[i].ToString("x2"));
        }

        return builder.ToString();
    }

    /// <summary>
    /// A static method that checks if a string is a boolean expression
    /// </summary>
    /// <param name="input">
    /// The string which we'll be checked 
    /// </param>
    /// <returns>
    /// Returns a boolean statements(true or false)
    /// </returns>
    public static bool ToBoolean(this string input)
    {
        var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
        return stringTrueValues.Contains(input.ToLower());
    }

    /// <summary>
    /// A static method that converts a string to its short(type) equivalent.
    /// </summary>
    /// <param name="input">
    /// The string which will be converted.
    /// </param>
    /// <returns>
    /// Returns a new 16-bit integer number[-32,768 to 32,767].
    /// Returns 0 if the string is not a number or the number is too big.
    /// </returns>
    public static short ToShort(this string input)
    {
        short shortValue;
        short.TryParse(input, out shortValue);
        return shortValue;
    }

    /// <summary>
    ///  A static method that converts a string to its integer(type) equivalent.
    /// </summary>
    /// <param name="input">
    /// The string which will be converted.
    /// </param>
    /// <returns>
    /// Returns a new 32-bit integer number[-2,147,483,648 to 2,147,483,647].
    /// Returns 0 if the string is not a number or the number is too big.
    /// </returns>
    public static int ToInteger(this string input)
    {
        int integerValue;
        int.TryParse(input, out integerValue);
        return integerValue;
    }

    /// <summary>
    ///  A static method that converts a string to its long(type) equivalent.
    /// </summary>
    /// <param name="input">
    /// The string which will be converted.
    /// </param>
    /// <returns>
    /// Returns a new 64-bit integer number[–9,223,372,036,854,775,808 to 9,223,372,036,854,775,807].
    /// Returns 0 if the string is not a number or the number is too big.
    /// </returns>
    public static long ToLong(this string input)
    {
        long longValue;
        long.TryParse(input, out longValue);
        return longValue;
    }

    /// <summary>
    /// A static method that converts a strig to a DateTime(type).
    /// </summary>
    /// <param name="input">
    /// The string which will be converted
    /// </param>
    /// <returns>
    /// Returns a new date in format month/day/year hours:minutes:seconds AM/PM.
    /// If the string can not be converted returns default DateTime of 01/01/0001 12:00:00 AM.
    /// </returns>
    public static DateTime ToDateTime(this string input)
    {
        DateTime dateTimeValue;
        DateTime.TryParse(input, out dateTimeValue);
        return dateTimeValue;
    }

    /// <summary>
    /// A static method that converts a string's first letter to uppercase.
    /// </summary>
    /// <param name="input">
    /// The string which will be converted
    /// </param>
    /// <returns>
    /// A new string with capitalized first letter.
    /// If the string is null or empty returns a new empty string or null.
    /// </returns>
    public static string CapitalizeFirstLetter(this string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        return 
            input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + 
            input.Substring(1, input.Length - 1);
    }

    /// <summary>
    /// A static method that finds the text in a string between two specific strings.
    /// </summary>
    /// <param name="input">
    /// The string in which the search will be performed
    /// </param>
    /// <param name="startString">
    /// The starting string from where the search will be performed on.
    /// </param>
    /// <param name="endString">
    /// The ending string where the search will end..
    /// </param>
    /// <param name="startFrom">
    /// (optioanal)The starting positon from where the search will be performed on.
    /// </param>
    /// <returns>
    /// Returns a new string with the found text.
    /// Return empty string if no string is found or the startStrign and endStrig are not found in the text.
    /// </returns>
    public static string GetStringBetween(
        this string input, string startString, string endString, int startFrom = 0)
    {
        input = input.Substring(startFrom);
        startFrom = 0;
        if (!input.Contains(startString) || !input.Contains(endString))
        {
            return string.Empty;
        }

        var startPosition = 
            input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
        if (startPosition == -1)
        {
            return string.Empty;
        }

        var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
        if (endPosition == -1)
        {
            return string.Empty;
        }

        return input.Substring(startPosition, endPosition - startPosition);
    }

    /// <summary>
    /// A static method that converts a cyrilyc string to its latin equivalent.
    /// </summary>
    /// <param name="input">
    /// The string which will be converted
    /// </param>
    /// <returns>
    /// Returns the input string converted to latin.
    /// </returns>
    public static string ConvertCyrillicToLatinLetters(this string input)
    {
        var bulgarianLetters = new[]
        {
            "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о",
            "п", "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
        };
        var latinRepresentationsOfBulgarianLetters = new[]
        {
            "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
            "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
            "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
        };
        for (var i = 0; i < bulgarianLetters.Length; i++)
        {
            input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
            input = input.Replace(bulgarianLetters[i].ToUpper(),
                latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
        }

        return input;
    }

    /// <summary>
    /// A static method that converts a latin string to its cyrilic equivalent.
    /// </summary>
    /// <param name="input">
    /// The string which will be converted
    /// </param>
    /// <returns>
    /// Returns the input string converted to cyrlic.
    /// </returns>
    public static string ConvertLatinToCyrillicKeyboard(this string input)
    {
        var latinLetters = new[]
        {
            "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
            "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
        };

        var bulgarianRepresentationOfLatinKeyboard = new[]
        {
            "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
            "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
            "в", "ь", "ъ", "з"
        };

        for (int i = 0; i < latinLetters.Length; i++)
        {
            input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
            input = input.Replace(latinLetters[i].ToUpper(),
                bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
        }

        return input;
    }

    /// <summary>
    /// A static method that converts a cyrilic string to a valid user name in latin removing all special charachters
    /// </summary>
    /// <param name="input">
    /// The string which will be converted
    /// </param>
    /// <returns>
    /// Returns a new valid latin string representation of the input string. 
    /// </returns>
    public static string ToValidUsername(this string input)
    {
        input = input.ConvertCyrillicToLatinLetters();
        return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
    }

    /// <summary>
    /// A static method that converts a cyrilic string to a valid file name in latin removing all special charachters
    /// and replacing whitespaces with '-'
    /// </summary>
    /// <param name="input"></param>
    /// <returns>
    /// Returns a new valid latin string representation of the input string .
    /// </returns>
    public static string ToValidLatinFileName(this string input)
    {
        input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
        return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
    }

    /// <summary>
    /// A static method that returns  the first 'n'(count) specified charachters in a string.
    /// </summary>
    /// <param name="input">
    /// The string which will be examined
    /// </param>
    /// <param name="charsCount">
    /// The count of charachters to be extracted
    /// </param>
    /// <returns>
    /// Returns a new substring of the inuput string
    /// </returns>
    public static string GetFirstCharacters(this string input, int charsCount)
    {
        return input.Substring(0, Math.Min(input.Length, charsCount));
    }

    /// <summary>
    /// A static method that gets the extension of the string representation of a file name.
    /// </summary>
    /// <param name="fileName">
    /// The string representation of the filename.
    /// </param>
    /// <returns>
    /// A new string with the extension of the input string file name
    /// Returns empty string if no extension is found or the string is null or empty.
    /// </returns>
    public static string GetFileExtension(this string fileName)
    {
        if (string.IsNullOrWhiteSpace(fileName))
        {
            return string.Empty;
        }

        string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
        if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
        {
            return string.Empty;
        }

        return fileParts.Last().Trim().ToLower();
    }

    /// <summary>
    /// A stati method that gets the content type of a specific extension.
    /// </summary>
    /// <param name="fileExtension">
    /// The extensions as a string representation.
    /// </param>
    /// <returns>
    /// Returns a new string with the content type.
    /// Return defult "application/octet-stream" if no such extension exists.
    /// </returns>
    public static string ToContentType(this string fileExtension)
    {
        var fileExtensionToContentType = new Dictionary<string, string>
        {
            { "jpg", "image/jpeg" },
            { "jpeg", "image/jpeg" },
            { "png", "image/x-png" },
            { "docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" },
            { "doc", "application/msword" },
            { "pdf", "application/pdf" },
            { "txt", "text/plain" },
            { "rtf", "application/rtf" }
        };
        if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
        {
            return fileExtensionToContentType[fileExtension.Trim()];
        }

        return "application/octet-stream";
    }

    /// <summary>
    /// Converts a string to a byte array.
    /// </summary>
    /// <param name="input">
    /// The string to be converted.
    /// </param>
    /// <returns>
    /// Rreturns a new byte array representation of the input string
    /// </returns>
    public static byte[] ToByteArray(this string input)
    {
        var bytesArray = new byte[input.Length * sizeof(char)];
        Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
        return bytesArray;
    }
}
