# Console.cs

## Description
Console.cs is a custom debugger script for Unity that provides additional functionality for logging and debugging in the Unity Editor.

## Installation
To use this script in your Unity project, follow these steps:
1. Copy the `Console.cs` script into your project's scripts folder.
2. Attach the `Console.cs` script to any game object in your scene or use it as a static class.

## Features
- Clearing the debug console.
- Setting color and style for log messages.
- Logging messages with different log types (Log, Warning, Error, Assertion, Exception).

## Usage
### Clearing the Debug Console
- In the Unity Editor, navigate to `Tools > Console > Clear Console` or use the shortcut `Alt + Shift + C` to clear the debug console.

### Setting Color and Style
- Use the following methods to set the color and style for log messages:
    - `SetColor(Color color)`: Sets the color for log messages. The color parameter should be a valid Color object.
    - `SetStyle(Style style)`: Sets the style for log messages. The style parameter should be one of the following: None, Bold, Italic, or BoldItalic.

### Logging Messages
- The logging methods (`Log`, `LogWarning`, `LogError`, `LogAssertion`, `LogException`) are similar to the ones provided by the `UnityEngine.Debug` class. They allow you to log messages with different log types and optional context objects.

## Example
Here's a simple example of how to use the `Console.cs` script:

```csharp
using UnityEngine;

public class ExampleScript : MonoBehaviour
{
    private void Start()
    {
        Debug.SetColor(Color.green);
        Debug.SetStyle(Style.bold);
        Debug.Log("Hello world!", this);
    }
}
```

This example sets the log color to green and the style to bold, and then logs the message "Hello world!" with the specified color and style, along with the context object `this`.

## Notes
- This script provides additional functionality for logging and debugging in the Unity Editor.
- The script can be accessed through the `Tools` menu in the Unity Editor.
- Some features are only available in the Unity Editor and may not work in a built game.
- Ensure that you have imported the necessary libraries and dependencies for the script to work properly.

For more information and examples, refer to the official Unity documentation or the comments within the `Console.cs` script.