using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Image musicToggleButton;
    public Sprite onMusicSprite;
    public Sprite offMusicSprite;

    public void OnMusicToggle() 
    {
        if (!PrefManager.musicToggled) 
        {
            PrefManager.musicToggled = true;
            musicToggleButton.sprite = onMusicSprite;
        } 
        else 
        {
            PrefManager.musicToggled = false;
            musicToggleButton.sprite = offMusicSprite;
        }
    }

    public void OnVolumeChange(float newValue)  
    {
        PrefManager.soundVolume = newValue;
    }

}
