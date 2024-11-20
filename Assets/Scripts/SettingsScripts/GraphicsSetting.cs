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
        Debug.Log("Initializing to Low Quality by default");
        SetLowQuality(); // Default to Low
    }

    public void SetLowQuality()
    {
        Debug.Log("Low quality selected");
        QualitySettings.SetQualityLevel(0);
        UpdateIcons(LowOnIcon, LowOffIcon, MediumOnIcon, MediumOffIcon, HighOnIcon, HighOffIcon);
    }

    public void SetMediumQuality()
    {
        Debug.Log("Medium quality selected");
        QualitySettings.SetQualityLevel(1);
        UpdateIcons(MediumOnIcon, MediumOffIcon, LowOnIcon, LowOffIcon, HighOnIcon, HighOffIcon);
    }

    public void SetHighQuality()
    {
        Debug.Log("High quality selected");
        QualitySettings.SetQualityLevel(2);
        UpdateIcons(HighOnIcon, HighOffIcon, LowOnIcon, LowOffIcon, MediumOnIcon, MediumOffIcon);
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
