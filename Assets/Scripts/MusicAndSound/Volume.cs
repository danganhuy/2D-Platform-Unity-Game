using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volume
{
    public static float musicVolume;
    public static float soundVolume;

    [System.Serializable]
    public class SaveVolume
    {
        public float musicVolume;
        public float soundVolume;
        public SaveVolume()
        {
            this.musicVolume = Volume.musicVolume;
            this.soundVolume = Volume.soundVolume;
        }
        public void DefaultSetting()
        {
            Volume.musicVolume = 1.0f;
            Volume.soundVolume = 1.0f;
        }
        public void LoadVolume()
        {
            Volume.musicVolume = this.musicVolume;
            Volume.soundVolume = this.soundVolume;
        }
    }
}
