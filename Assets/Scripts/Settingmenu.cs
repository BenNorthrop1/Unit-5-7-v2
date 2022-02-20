using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class Settingmenu : MonoBehaviour
{

    public AudioClip[] clips;
    public AudioSource vfx;
    public AudioSource music;
    public AudioSource master;

    public AudioMixer audioMixer;


    private float pMasterVolume, pVfxVolume, pMusicVolume;

    

    public Slider masterSlider;

    public Slider vfxSlider;

    public Slider musicSlider;
    
   
    public TMP_Dropdown resolutionDropdown;

    Resolution[] resolutions;

    void Start()
    {
        pMasterVolume = PlayerPrefs.GetFloat("playerMasterVolume",0);

        pMusicVolume = PlayerPrefs.GetFloat("playerMusicVolume",0);

        pVfxVolume = PlayerPrefs.GetFloat("playerVfxVolume",0);

        audioMixer.SetFloat("MasterVol",pMasterVolume);

        audioMixer.SetFloat("VfxVol",pVfxVolume);

        audioMixer.SetFloat("MusicVol",pMusicVolume);

        resolutions = Screen.resolutions;

        masterSlider.value = pMasterVolume;

        vfxSlider.value = pVfxVolume;

        musicSlider.value = pMusicVolume;

        music.PlayOneShot(clips[0],0.7f);

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        
        }
        
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

    }

  


    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }


    
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        QualitySettings.SetQualityLevel(2);
  
    }


    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }


    public void SetVolume(float volume) 
    {
        PlayerPrefs.SetFloat("playerMasterVolume", volume);
        audioMixer.SetFloat("MasterVolume",volume);
    }

  public void PlaySound(int clipNumber, int output) 
{
    switch(output)
     {
        
        case 0:
              music.PlayOneShot(clips[clipNumber]);
              break;
        case 1:
              vfx.PlayOneShot(clips[clipNumber]);
              break;
    }
}
}
