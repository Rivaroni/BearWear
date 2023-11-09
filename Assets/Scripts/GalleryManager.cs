using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;

public class GalleryManager : MonoBehaviour
{
    public GameObject[] imageSlots; // Assume this is assigned in the editor with your 8 slots
    private List<string> imagePaths = new List<string>();
    private int currentPage = 0;
    private int imagesPerPage = 8; // Or however many slots you have

    public GameObject expandedImageContainer; // Assign this in the inspector
    public Image expandedImage;

    private void Start()
    {
        LoadImages();
        ShowPage(currentPage);
    }

    private void LoadImages()
    {
        var screenshotsPath = Path.Combine(Application.persistentDataPath, "Screenshots");
        if (Directory.Exists(screenshotsPath))
        {
            imagePaths.AddRange(Directory.GetFiles(screenshotsPath, "*.png"));
        }
    }

    public void ShowNextPage()
    {
        if ((currentPage + 1) * imagesPerPage < imagePaths.Count)
        {
            currentPage++;
            ShowPage(currentPage);
        }
    }

    public void ShowPreviousPage()
    {
        if (currentPage > 0)
        {
            currentPage--;
            ShowPage(currentPage);
        }
    }

    // This method should be called by an event trigger on the image GameObject
    public void ExpandImage(Image imageToExpand)
    {
        expandedImage.sprite = imageToExpand.sprite; // Set the sprite for the image
        expandedImageContainer.SetActive(true); // Activate the container GameObject
                                                // Additional code for transitions or animations
    }


    public void CloseExpandedImage()
    {
        expandedImageContainer.SetActive(false); // Deactivate the container GameObject
    }

    private void ShowPage(int pageIndex)
    {
        int startImageIndex = pageIndex * imagesPerPage;
        for (int i = 0; i < imageSlots.Length; i++)
        {
            if (startImageIndex + i < imagePaths.Count)
            {
                var texture = LoadTextureFromFile(imagePaths[startImageIndex + i]);
                imageSlots[i].GetComponent<Image>().sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
                imageSlots[i].SetActive(true);
            }
            else
            {
                imageSlots[i].SetActive(false); // Hide the slot if there is no image to display.
            }
        }
    }

    private Texture2D LoadTextureFromFile(string filePath)
    {
        Texture2D texture = new Texture2D(2, 2);
        byte[] fileData = File.ReadAllBytes(filePath);
        texture.LoadImage(fileData);
        return texture;
    }
}
