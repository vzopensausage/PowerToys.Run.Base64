using System;
using System.Windows;
using Wox.Plugin;

namespace Community.PowerToys.Run.Plugin.Base64;

public class B64
{
    private static string encode(string plainText)
    {
        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
        return System.Convert.ToBase64String(plainTextBytes);
    }

    private static string decode(string base64EncodedData)
    {
        var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
        return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
    }
    
    public static Result Encode(string plainText)
    {
        return ToResult(encode(plainText));
    }
    
    public static Result Decode(string plainText)
    {
        
        return ToResult(decode(plainText));
    }
    
    public static void SetClipboardText(string s)
    {
        Clipboard.SetDataObject(s);
    }
    
    public static Result ToResult(string content)
    {
        return new Result
        {
            Title = content,
            SubTitle = "将结果复制到剪贴板",
            Action = (e) =>
            {
                SetClipboardText(content);
                return true;
            }
        };
    }
}