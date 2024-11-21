using UnityEngine;
using UnityEngine.UI;

public class ImageBlocker : MonoBehaviour
{
    public GameObject targetImage; // Drag the image GameObject here

    public void HideImage()
    {
        if (targetImage != null)
        {
            targetImage.SetActive(false); // Deactivate the image
        }
    }

    public void ShowImage()
    {
        if (targetImage != null)
        {
            targetImage.SetActive(true); // Reactivate the image
        }
    }
}
