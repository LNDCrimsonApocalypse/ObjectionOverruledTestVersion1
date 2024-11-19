using UnityEngine;
using UnityEngine.UI;

public class GraphicsSetting : MonoBehaviour
{
    [Header("Buttons")]
    public Button LowBtn;
    public Button MediumBtn;
    public Button HighBtn;

    [Header("Icons")]
    public GameObject LowOnIcon;
    public GameObject LowOffIcon;
    public GameObject MediumOnIcon;
    public GameObject MediumOffIcon;
    public GameObject HighOnIcon;
    public GameObject HighOffIcon;

    private void Awake()
    {
        // Add listeners to buttons
        LowBtn.onClick.AddListener(SetLowQuality);
        MediumBtn.onClick.AddListener(SetMediumQuality);
        HighBtn.onClick.AddListener(SetHighQuality);

        // Initialize the state
        SetLowQuality(); // Default to Low
    }

    public void SetLowQuality()
    {
        // Set quality level
        QualitySettings.SetQualityLevel(0);

        // Update icons
        UpdateIcons(LowOnIcon, LowOffIcon, MediumOnIcon, MediumOffIcon, HighOnIcon, HighOffIcon);
    }

    public void SetMediumQuality()
    {
        // Set quality level
        QualitySettings.SetQualityLevel(1);

        // Update icons
        UpdateIcons(MediumOnIcon, MediumOffIcon, LowOnIcon, LowOffIcon, HighOnIcon, HighOffIcon);
    }

    public void SetHighQuality()
    {
        // Set quality level
        QualitySettings.SetQualityLevel(2);

        // Update icons
        UpdateIcons(HighOnIcon, HighOffIcon, LowOnIcon, LowOffIcon, MediumOnIcon, MediumOffIcon);
    }

    private void UpdateIcons(GameObject activeOnIcon, GameObject activeOffIcon, GameObject otherOnIcon1, GameObject otherOffIcon1, GameObject otherOnIcon2, GameObject otherOffIcon2)
    {
        // Activate the selected button's ON icon
        activeOnIcon.SetActive(true);
        activeOffIcon.SetActive(false);

        // Deactivate the other buttons' ON icons
        otherOnIcon1.SetActive(false);
        otherOffIcon1.SetActive(true);
        otherOnIcon2.SetActive(false);
        otherOffIcon2.SetActive(true);
    }
}
