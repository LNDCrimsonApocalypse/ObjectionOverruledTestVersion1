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

    private const string QualityPrefKey = "GraphicsQuality";

    private void Awake()
    {
        // Add listeners to buttons
        LowBtn.onClick.AddListener(SetLowQuality);
        MediumBtn.onClick.AddListener(SetMediumQuality);
        HighBtn.onClick.AddListener(SetHighQuality);

        // Load and apply the saved quality setting
        int savedQualityLevel = PlayerPrefs.GetInt(QualityPrefKey, 0); // Default to Low if not set
        Debug.Log($"Loading saved quality level: {savedQualityLevel}");
        ApplyQualitySetting(savedQualityLevel);
    }

    public void SetLowQuality()
    {
        Debug.Log("Low quality selected");
        ApplyQualitySetting(0);
    }

    public void SetMediumQuality()
    {
        Debug.Log("Medium quality selected");
        ApplyQualitySetting(1);
    }

    public void SetHighQuality()
    {
        Debug.Log("High quality selected");
        ApplyQualitySetting(2);
    }

    private void ApplyQualitySetting(int qualityLevel)
    {
        // Set the quality level
        QualitySettings.SetQualityLevel(qualityLevel);

        // Save the quality level to PlayerPrefs
        PlayerPrefs.SetInt(QualityPrefKey, qualityLevel);
        PlayerPrefs.Save();

        // Update the icons based on the selected quality level
        switch (qualityLevel)
        {
            case 0:
                UpdateIcons(LowOnIcon, LowOffIcon, MediumOnIcon, MediumOffIcon, HighOnIcon, HighOffIcon);
                break;
            case 1:
                UpdateIcons(MediumOnIcon, MediumOffIcon, LowOnIcon, LowOffIcon, HighOnIcon, HighOffIcon);
                break;
            case 2:
                UpdateIcons(HighOnIcon, HighOffIcon, LowOnIcon, LowOffIcon, MediumOnIcon, MediumOffIcon);
                break;
        }
    }

    private void UpdateIcons(GameObject activeOnIcon, GameObject activeOffIcon, GameObject otherOnIcon1, GameObject otherOffIcon1, GameObject otherOnIcon2, GameObject otherOffIcon2)
    {
        Debug.Log($"Updating icons. Active: {activeOnIcon.name}, Deactivating: {otherOnIcon1.name} & {otherOnIcon2.name}");

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
