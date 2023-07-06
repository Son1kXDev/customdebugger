# Console.cs

## Description
Console.cs is a custom debugger script for Unity that provides additional functionality for logging and debugging in the Unity Editor.

## Installation

To install the plugin, simply download and import the CustomDebugger.unitypackage into your project.

## Features
- Clearing the debug console.
- Setting color and style for log messages.
- Logging messages with different log types (Log, Warning, Error, Assertion, Exception).

## Usage
### Clearing the Debug Console
- In the Unity Editor, navigate to `Tools > Console > Clear Console` or use the shortcut `Alt + Shift + C` to clear the debug console.

![image](https://github.com/Son1kXDev/customdebugger/assets/106654105/3ef4bea6-0866-4650-8b80-5e7d04604a3d)
  
- In any script simple add Debug.Clear() to clear the debug console.
```csharp
 Debug.Clear();
```

### Setting Color and Style
- Use the following methods to set the color and style for log messages:
    - `SetColor(Color color)`: Sets the color for log messages. The color parameter should be a valid Color object.
    - `SetStyle(Style style)`: Sets the style for log messages. The style parameter should be one of the following:  Bold, Italic, or BoldItalic.

### Logging Messages
- The logging methods (`Log`, `LogWarning`, `LogError`, `LogAssertion`, `LogException`) are similar to the ones provided by the `UnityEngine.Debug` class. They allow you to log messages with different log types and optional context objects.

## Example
Here's a simple example of how to use the `Console.cs` script:

```csharp
using UnityEngine;

public class ExampleScript : MonoBehaviour
{
    private IEnumerator Start()
    {
        Debug.SetColor(Color.green);            //set color to green
        Debug.SetStyle(Style.bold);            //set style to bold
        Debug.Log("Hello world!", this);        //logging message

        yield return new WaitForSeconds(5);    //waiting for 5 seconds
        Debug.Clear();                        //clearing console
    }
}
```

![image](https://github.com/Son1kXDev/customdebugger/assets/106654105/7ed94337-e472-406d-9512-9e88819a1336)


## Notes
- This script provides additional functionality for logging and debugging in the Unity Editor.
- The script can be accessed through the `Tools` menu in the Unity Editor.
- Some features are only available in the Unity Editor and may not work in a built game.
- Ensure that you have imported the necessary libraries and dependencies for the script to work properly.
