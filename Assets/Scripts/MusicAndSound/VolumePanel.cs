using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumePanel : MonoBehaviour
{
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider volumeSlider;
    public void Start()
    {
        musicSlider.value = Volume.musicVolume;
        volumeSlider.value = Volume.soundVolume;
    }
    public void SetMusicVolume()
    {
        Volume.musicVolume = musicSlider.value;
        SaveSystem.SaveSetting();
    }
    public void SetSoundVolume()
    {
        Volume.soundVolume = volumeSlider.value;
        SaveSystem.SaveSetting();
    }
}
