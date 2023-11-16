using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;
using System;

public class GalleryManager : MonoBehaviour
{
    public GameObject[] imageSlots;
    private List<string> imagePaths = new List<string>();
    private int currentPage = 0;
    private int imagesPerPage = 8;

    public GameObject expandedImageContainer;
    public Image expandedImage;

    // TODO: Make buttons disable if ur at end of page
    public Button nextButton;
    public Button prevButton;
    public AudioClip clickSfx;
    public AudioClip deleteSfx;

    private int currentExpandedImageIndex = -1; // -1 means no image is expanded
    public Sprite successSprite;
    public Sprite failureSprite;


    private void Start()
    {
        LoadImages();
        ShowPage(currentPage);
        UpdateButtonStates();
    }

    private void LoadImages()
    {
        var screenshotsPath = Path.Combine(Application.persistentDataPath, "Screenshots");
        if (Directory.Exists(screenshotsPath))
        {
            imagePaths.AddRange(Directory.GetFiles(screenshotsPath, "*.png"));
        }
        UpdateButtonStates(); // Update the button states after loading images
    }

    public void ShowNextPage()
    {
        AudioManagerScript.instance.PlaySoundEffect(clickSfx, 0.3f);

        if ((currentPage + 1) * imagesPerPage < imagePaths.Count)
        {
            currentPage++;
            ShowPage(currentPage);
        }
        UpdateButtonStates();
    }

    public void ShowPreviousPage()
    {
        AudioManagerScript.instance.PlaySoundEffect(clickSfx, 0.3f);

        if (currentPage > 0)
        {
            currentPage--;
            ShowPage(currentPage);
        }
        UpdateButtonStates();
    }

    private void UpdateButtonStates()
    {
        // Enable or disable the next button based on whether there is a next page
        nextButton.interactable = (currentPage + 1) * imagesPerPage < imagePaths.Count;

        // Enable or disable the previous button based on whether there is a previous page
        prevButton.interactable = currentPage > 0;
    }

    public void ExpandImage(Image imageToExpand)
    {
        AudioManagerScript.instance.PlaySoundEffect(clickSfx, 0.3f);

        // Assuming imageToExpand.name is set to a string that represents an integer
        if (int.TryParse(imageToExpand.name, out int imageIndex))
        {
            currentExpandedImageIndex = currentPage * imagesPerPage + imageIndex;
            expandedImage.sprite = imageToExpand.sprite;
            expandedImageContainer.SetActive(true);
            // Additional code for transitions or animations
        }
        else
        {
            Debug.LogError("The name of the image could not be converted to an int: " + imageToExpand.name);
        }
    }

    public void DeleteImage()
    {
        AudioManagerScript.instance.PlaySoundEffect(deleteSfx);

        if (currentExpandedImageIndex != -1 && currentExpandedImageIndex < imagePaths.Count)
        {
            File.Delete(imagePaths[currentExpandedImageIndex]);
            imagePaths.RemoveAt(currentExpandedImageIndex);
            CloseExpandedImage();
            ShowPage(currentPage);
            if (currentPage > 0 && currentPage * imagesPerPage >= imagePaths.Count)
            {
                currentPage--;
            }
            ShowPage(currentPage); // Refresh the gallery view
            currentExpandedImageIndex = -1;
        }
        UpdateButtonStates(); // Update the button states after deleting an image
    }

    public void CloseExpandedImage()
    {
        AudioManagerScript.instance.PlaySoundEffect(clickSfx, 0.5f);
        expandedImageContainer.SetActive(false);
        // Reset the current expanded image index
        currentExpandedImageIndex = -1;
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

    public void DownloadImage()
    {
        if (currentExpandedImageIndex != -1 && currentExpandedImageIndex < imagePaths.Count)
        {
            string sourcePath = imagePaths[currentExpandedImageIndex];
            string fileName = Path.GetFileName(sourcePath);
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string destinationPath = Path.Combine(desktopPath, fileName);

            try
            {
                File.Copy(sourcePath, destinationPath, true);
                Debug.Log("Image downloaded to Desktop: " + destinationPath);

                // Change sprite to success (checkmark)
                expandedImage.sprite = successSprite;

                // Optionally, provide feedback to the user via UI
            }
            catch (Exception e)
            {
                Debug.LogError("Failed to download image: " + e.Message);

                // Change sprite to failure (X)
                expandedImage.sprite = failureSprite;

                // Optionally, handle errors, such as user feedback through UI
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
