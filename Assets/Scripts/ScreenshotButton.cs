using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class ScreenshotButton : MonoBehaviour
{
    public Image cameraImage;

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

        // Calculate the capture area to capture the left half of the screen
        float captureWidth = Screen.width / 2; // Adjust the width to capture only the left half
        float captureHeight = Screen.height;
        float captureX = 0; // Start capturing from the left edge of the screen
        float captureY = 0;

        // Create a new Texture2D to capture the left half of the screen
        Texture2D texture = new Texture2D((int)captureWidth, (int)captureHeight, TextureFormat.RGB24, false);

        // Read the pixels from the screen into the texture within the specified area
        texture.ReadPixels(new Rect(captureX, captureY, captureWidth, captureHeight), 0, 0);
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

        cameraImage.enabled = true;
    }

    public void TakeScreenshot()
    {
        StartCoroutine("Screenshot");
        cameraImage.enabled = false;
    }
}
