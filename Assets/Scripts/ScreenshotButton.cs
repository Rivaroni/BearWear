using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class ScreenshotButton : MonoBehaviour
{
    public Image cameraImage;
    public AudioClip camSfx;
    public GameObject UI;

    private void Start()
    {
        // Get the path to the "Screenshots" folder within the Unity project
        string screenshotFolderPath = Path.Combine(Application.dataPath, "Screenshots");

        // Create the "Screenshots" folder if it doesn't exist
        if (!Directory.Exists(screenshotFolderPath))
        {
            Directory.CreateDirectory(screenshotFolderPath);
        }
    }

    private IEnumerator Screenshot()
    {
        UI.SetActive(false);
        AudioManagerScript.instance.PlaySoundEffect(camSfx);
        yield return new WaitForEndOfFrame();

        // Calculate the capture area to capture the left half of the screen
        float captureWidth = Screen.width / 1.6f; // Adjust the width to capture only the left half
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

        // Construct the full path to save the screenshot in the "Screenshots" folder
        string screenshotFolderPath = Path.Combine(Application.dataPath, "Screenshots");
        string screenshotPath = Path.Combine(screenshotFolderPath, screenshotFilename);

        // Encode the texture as a PNG and save it in the "Screenshots" folder
        byte[] bytes = texture.EncodeToPNG();
        File.WriteAllBytes(screenshotPath, bytes);

        // Destroy the texture to free up memory
        Destroy(texture);

        cameraImage.enabled = true;
        UI.SetActive(true);
    }

    public void TakeScreenshot()
    {
        StartCoroutine("Screenshot");
        cameraImage.enabled = false;
    }
}
