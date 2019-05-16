using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioSource BackgroundAudio;
    public Slider BackgroundSlider;

    //public AudioSource EffectAudio;
    //public Slider EffectSlider;

    void Start()
    {
        //Base Values of the background volume slider
        BackgroundSlider.minValue = 0;
        BackgroundSlider.maxValue = 1;
        BackgroundSlider.wholeNumbers = false;
        BackgroundSlider.value = 0.5f;

        ////Base Values of the Effect volume slider
        //EffectSlider.minValue = 0;
        //EffectSlider.maxValue = 1;
        //EffectSlider.wholeNumbers = false;
        //EffectSlider.value = 0.7f;
    }

    void Update()
    {
        VolumeController();
    }

    public void VolumeController()
    {
        BackgroundAudio.volume = BackgroundSlider.value;
        //EffectAudio.volume = EffectSlider.value;
    }
}
