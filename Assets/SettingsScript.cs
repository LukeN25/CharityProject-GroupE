using UnityEngine;
using UnityEngine.Audio;

public class SettingsScript : MonoBehaviour
{
    public AudioMixer audioMixer;

    public GameObject settingsPanel;
   public void SetVolume(float volume)
    {
        Debug.Log(volume);

        audioMixer.SetFloat("volume", volume);
    }

    public void SettingsPanelToggle()
    { if(settingsPanel.active)
        settingsPanel.SetActive(false); 

    else 
            settingsPanel.SetActive(true);
    }

}
