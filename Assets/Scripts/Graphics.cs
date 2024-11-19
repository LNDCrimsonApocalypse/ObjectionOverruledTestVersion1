using UnityEngine;

public class ImageSwitcher : MonoBehaviour
{
    public GameObject lowImage;     // Assign the Low image in the Inspector
    public GameObject mediumImage; // Assign the Medium image in the Inspector
    public GameObject highImage;   // Assign the High image in the Inspector

    void Start()
    {
        // Ensure only the Low image is visible at the start
        ShowImage(lowImage);
    }

    public void ShowLow()
    {
        ShowImage(lowImage);
    }

    public void ShowMedium()
    {
        ShowImage(mediumImage);
    }

    public void ShowHigh()
    {
        ShowImage(highImage);
    }

    private void ShowImage(GameObject imageToShow)
    {
        // Deactivate all images
        if (lowImage != null) lowImage.SetActive(false);
        if (mediumImage != null) mediumImage.SetActive(false);
        if (highImage != null) highImage.SetActive(false);

        // Activate the selected image
        if (imageToShow != null) imageToShow.SetActive(true);
    }
}
