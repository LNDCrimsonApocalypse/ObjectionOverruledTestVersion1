using UnityEngine;
using UnityEngine.UI;

public class NeonButtonEffect : MonoBehaviour
{
    [Header("Button Colors")]
    public Color PlayColor = Color.cyan;
    public Color TutorialColor = Color.green;
    public Color SettingsColor = Color.yellow;
    public Color QuitColor = Color.red;

    [Header("Buttons")]
    public Button PlayButton;
    public Button TutorialButton;
    public Button SettingsButton;
    public Button QuitButton;

    [Header("Shadow Components")]
    public Shadow PlayShadow;
    public Shadow TutorialShadow;
    public Shadow SettingsShadow;
    public Shadow QuitShadow;

    private void Start()
    {
        // Add listeners to buttons
        PlayButton.onClick.AddListener(() => ApplyNeonEffect(PlayShadow, PlayColor));
        TutorialButton.onClick.AddListener(() => ApplyNeonEffect(TutorialShadow, TutorialColor));
        SettingsButton.onClick.AddListener(() => ApplyNeonEffect(SettingsShadow, SettingsColor));
        QuitButton.onClick.AddListener(() => ApplyNeonEffect(QuitShadow, QuitColor));

        // Disable all shadows initially
        ResetAllShadows();
    }

    private void ApplyNeonEffect(Shadow targetShadow, Color color)
    {
        // Reset other shadows
        ResetAllShadows();

        // Enable the selected shadow and apply the color
        targetShadow.effectColor = color;
        targetShadow.enabled = true;
    }

    private void ResetAllShadows()
    {
        // Disable all shadows
        PlayShadow.enabled = false;
        TutorialShadow.enabled = false;
        SettingsShadow.enabled = false;
        QuitShadow.enabled = false;
    }
}
