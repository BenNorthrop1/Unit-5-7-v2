using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class Settingmenu : MonoBehaviour
{

    private float pMasterVolume, pMusicVolume, pVfxVolume;

    public Slider masterSlider, musicSlider, vfxSlider;


    public AudioClip[] clips;
    public AudioSource musicSource, vfxSource;
    public AudioMixer audioMixer;


   
    public TMP_Dropdown resolutionDropdown;

    Resolution[] resolutions;


    enum Sounds
    {
        music,//0
        ding,//1
        click,//2





    };

    void Start()
    {
        pMasterVolume = PlayerPrefs.GetFloat("playerMasterVolume", 0);
        pMusicVolume = PlayerPrefs.GetFloat("playerMusicVolume", 0);
        pVfxVolume = PlayerPrefs.GetFloat("playerVfxVolume", 0);
        audioMixer.SetFloat("masterVolume", pMasterVolume);
        audioMixer.SetFloat("musicVolume", pMusicVolume);
        audioMixer.SetFloat("vfxVolume", pVfxVolume);
        masterSlider.value = pMasterVolume;
        musicSlider.value = pMusicVolume;
        vfxSlider.value = pVfxVolume;
        musicSource.PlayOneShot(clips[(int)Sounds.music], 0.2f);


        resolutions = Screen.resolutions;

      

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height + " @ " + resolutions[i].refreshRate + "hz";
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

        PlayerPrefs.Save();
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
    public void PlayVFXSound(int clipNumber) => vfxSource.PlayOneShot(clips[clipNumber]);
    
    public void PlayMusicSound(int clipNumber) => musicSource.PlayOneShot(clips[clipNumber]);



  public void SetVolumeMaster(float volume)  
    {
        audioMixer.SetFloat("masterVolume", volume);
        PlayerPrefs.SetFloat("playerMasterVolume", volume);
    }
    public void SetVolumeMusic(float volume)
    {
        audioMixer.SetFloat("musicVolume", volume);
        PlayerPrefs.SetFloat("playerMusicVolume", volume);
    }
    public void SetVolumeVfx(float volume)
    {
        audioMixer.SetFloat("vfxVolume", volume);
        PlayerPrefs.SetFloat("playerVfxVolume", volume);
    }


}
