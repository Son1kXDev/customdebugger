using UnityEngine;

public class ExampleScript : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("This is default log message!", this);

        // use Debug.SetColor(Color) to set a color for the next debug message
        // 

        Debug.SetColor(Color.green);
        Debug.SetStyle(Style.bold);
        Debug.Log("This is custom log message!", this);

        Debug.LogWarning("This is default warning message", this);

        Debug.SetColor(Color.blue);
        Debug.SetStyle(Style.italic);
        Debug.LogWarning("This is custom warning message", this);

        Debug.LogError("This is default error message", this);

        Debug.SetColor(Color.cyan);
        Debug.SetStyle(Style.bolditalic);
        Debug.LogError("This is custom error message", this);
    }
}