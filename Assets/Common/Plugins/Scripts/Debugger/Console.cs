using System.Reflection;
using UnityEngine;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif

public enum Style { none = -1, bold, italic, bolditalic }

public partial class Debug
{

#if UNITY_EDITOR

    [MenuItem("Tools/Console/Clear Console &%#c", priority = 1)]
    private static void ClearMenuItem()
    {
        if (EditorUtility.DisplayDialog("Clear Debug Console", "Are you sure you want to clear debug console?", "Yes", "Cancel"))
        {
            Clear();
        }
    }

    [MenuItem("Tools/Console/Debug Mode", true)]
    private static bool ValidateEnableDebug()
    {
        Menu.SetChecked("Tools/Console/Debug Mode", UnityEngine.Debug.unityLogger.logEnabled);
        return true;
    }

    [MenuItem("Tools/Console/Debug Mode", priority = 100)]
    private static void EnableDebug()
    {
        UnityEngine.Debug.unityLogger.logEnabled = !UnityEngine.Debug.unityLogger.logEnabled;
    }

    /// <summary>
    /// Clears all messages in the console.
    /// </summary>
    public static void Clear()
    {
        var assembly = Assembly.GetAssembly(typeof(SceneView));
        var type = assembly.GetType("UnityEditor.LogEntries");
        var method = type.GetMethod("Clear");
        method.Invoke(new object(), null);
    }
#else
    public static void Clear() { }
#endif

    private static Color _color = Color.gray;

    private static Style _style;

    private static string ColorString
    {
        get
        {
            return ExtColorToNames.FindColor(_color);
        }
    }

    private static string StyleString
    {
        get
        {
            string result = _style switch
            {
                Style.bold => "<b>&</b>",
                Style.italic => "<i>&</i>",
                Style.bolditalic => "<b><i>&</i></b>",
                _ => "&",
            };
            return result;
        }
    }

    private static void Reset()
    {
        _color = Color.white;
        _style = Style.none;
    }

    /// <summary>
    /// Set a color for the next debug message.
    /// </summary>
    /// <param name="color"> Supported colors: cyan, grey, yellow, magenta, red, blue, green, black, white</param>
    public static void SetColor(Color color)
    {
        _color = color;
    }

    /// <summary>
    /// Set a style for the next debug message.
    /// </summary>
    /// <param name="style"> Supported styles: Bold, Italic, Bold + Italic</param>
    public static void SetStyle(Style style)
    {
        _style = style;
    }

    /// <summary>
    /// Logs message to the Unity Console.
    /// </summary>
    /// <param name="message">String or object to be converted to string representation for display.</param>
    public static void Log(object message)
    {
        message = $"<color={ColorString}>{message}</color>";
        message = StyleString.Replace("&", message.ToString());
        UnityEngine.Debug.unityLogger.Log(LogType.Log, message);
        Reset();
    }

    /// <summary>
    /// Logs message to the Unity Console.
    /// </summary>
    /// <param name="message">String or object to be converted to string representation for display.</param>
    /// <param name="context">Object to which the message applies.</param>
    public static void Log(object message, UnityEngine.Object context)
    {
        message = $"<color={ColorString}>{message}</color>";
        message = StyleString.Replace("&", message.ToString());
        UnityEngine.Debug.unityLogger.Log(LogType.Log, message, context);
        Reset();
    }

    /// <summary>
    /// A variant of Debug.Log that logs a warning message to the console.
    /// </summary>
    /// <param name="message"></param>
    public static void LogWarning(object message)
    {
        if (_color == Color.white) SetColor(Color.yellow);
        message = $"<color={ColorString}>{message}</color>";
        message = StyleString.Replace("&", message.ToString());
        UnityEngine.Debug.unityLogger.Log(LogType.Warning, message);
        Reset();
    }

    /// <summary>
    /// A variant of Debug.Log that logs a warning message to the console.
    /// </summary>
    /// <param name="message">String or object to be converted to string representation for display.</param>
    /// <param name="context">Object to which the message applies.</param>
    public static void LogWarning(object message, UnityEngine.Object context)
    {
        if (_color == Color.white) SetColor(Color.yellow);
        message = $"<color={ColorString}>{message}</color>";
        message = StyleString.Replace("&", message.ToString());
        UnityEngine.Debug.unityLogger.Log(LogType.Warning, message, context);
        Reset();
    }

    /// <summary>
    /// A variant of Debug.Log that logs an error message to the console.
    /// </summary>
    /// <param name="message">String or object to be converted to string representation for display.</param>
    public static void LogError(object message)
    {
        if (_color == Color.white) SetColor(Color.red);
        message = $"<color={ColorString}>{message}</color>";
        message = StyleString.Replace("&", message.ToString());
        UnityEngine.Debug.unityLogger.Log(LogType.Error, message);
        Reset();
    }

    /// <summary>
    /// A variant of Debug.Log that logs an error message to the console.
    /// </summary>
    /// <param name="message">String or object to be converted to string representation for display.</param>
    /// <param name="context">Object to which the message applies.</param>
    public static void LogError(object message, UnityEngine.Object context)
    {
        if (_color == Color.white) SetColor(Color.red);
        message = $"<color={ColorString}>{message}</color>";
        message = StyleString.Replace("&", message.ToString());
        UnityEngine.Debug.unityLogger.Log(LogType.Error, message, context);
        Reset();
    }

    /// <summary>
    /// A variant of Debug.Log that logs an assertion message to the console.
    /// </summary>
    /// <param name="message">String or object to be converted to string representation for display.</param>
    public static void LogAssertion(object message)
    {
        message = $"<color={ColorString}>{message}</color>";
        message = StyleString.Replace("&", message.ToString());
        UnityEngine.Debug.unityLogger.Log(LogType.Assert, message);
        Reset();
    }

    /// <summary>
    /// A variant of Debug.Log that logs an assertion message to the console.
    /// </summary>
    /// <param name="message">String or object to be converted to string representation for display.</param>
    /// <param name="context">Object to which the message applies.</param>
    public static void LogAssertion(object message, UnityEngine.Object context)
    {
        message = $"<color={ColorString}>{message}</color>";
        message = StyleString.Replace("&", message.ToString());
        UnityEngine.Debug.unityLogger.Log(LogType.Assert, message, context);
        Reset();
    }

    public static void LogException(System.Exception exception)
    {
        UnityEngine.Debug.unityLogger.LogException(exception);
    }

    public static void LogException(System.Exception exception, UnityEngine.Object context)
    {
        UnityEngine.Debug.unityLogger.LogException(exception, context);
    }
}

public static class ExtColorToNames
{
    private static readonly Dictionary<string, Color> colors = new Dictionary<string, Color>()
    {
        ["cyan"] = Color.cyan,
        ["grey"] = Color.grey,
        ["yellow"] = Color.yellow,
        ["magenta"] = Color.magenta,
        ["red"] = Color.red,
        ["blue"] = Color.blue,
        ["green"] = Color.green,
        ["black"] = Color.black,
        ["white"] = Color.white
    };

    public static string FindColor(Color color)
    {
        float nearest = 99;
        string nameColor = "";
        Vector3 cin = new Vector3(color.r, color.g, color.b);

        foreach (KeyValuePair<string, Color> entry in colors)
        {
            Vector3 found = new Vector3(entry.Value.r, entry.Value.g, entry.Value.b);

            if (Vector3.Distance(found, cin) < nearest)
            {
                nameColor = entry.Key;
                nearest = Vector3.Distance(found, cin);
            }
        }
        return nameColor;
    }
}