using UnityEngine;
using System.Collections;
using System.IO;

public class ScreenshotButton : MonoBehaviour
{
    private void Start()
    {
        // Create the Screenshots folder if it doesn't exist in the project
        string screenshotPath = Path.Combine(Application.dataPath, "Screenshots");
        Directory.CreateDirectory(screenshotPath);
    }

    private void Update()
    {
        
    }

    private IEnumerator Screenshot()
    {
        yield return new WaitForEndOfFrame();
        
        // Create a new Texture2D to capture the screen
        Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);

        // Read the pixels from the screen into the texture
        texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        texture.Apply();

        // Generate a unique filename based on the current date and time
        string timestamp = System.DateTime.Now.ToString("yyyyMMddHHmmss");
        string screenshotFilename = "Screenshot_" + timestamp + ".png";

        // Construct the full path to save the screenshot inside the "Screenshots" folder
        string screenshotPath = Path.Combine(Application.dataPath, "Screenshots", screenshotFilename);

        // Encode the texture as a PNG and save it to the "Screenshots" folder
        byte[] bytes = texture.EncodeToPNG();
        File.WriteAllBytes(screenshotPath, bytes);

        // Destroy the texture to free up memory
        Destroy(texture);
    }

    public void TakeScreenshot()
    {
        StartCoroutine("Screenshot");
    }
}
