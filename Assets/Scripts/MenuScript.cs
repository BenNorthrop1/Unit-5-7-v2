using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;
using static Settingmenu;

public class MenuScript : MonoBehaviour
{

    public GameObject beginning;

    public GameObject mainMenu;

    public GameObject playMenu;

    public GameObject settingMenu;

    public GameObject controlsMenu;

    public GameObject creditsMenu;

    public GameObject quitMenu;

    public CinemachineBrain mainCamera;

    public CinemachineVirtualCamera cam_1;

    public CinemachineVirtualCamera cam_2;

    public Animator anim;



  
    void Start()
    {
        beginning.SetActive(true);
        playMenu.SetActive(false);
        settingMenu.SetActive(false);
        controlsMenu.SetActive(false);
        creditsMenu.SetActive(false);
        quitMenu.SetActive(false);
      
    }

    void Update()
    {
      
        if(Input.anyKeyDown && beginning.activeInHierarchy)
        {

            beginning.SetActive(false);
            mainMenu.SetActive(true);

            cam_1.gameObject.SetActive(false);
            cam_2.gameObject.SetActive(true);

        }
    }

    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Playmenu()
    {
        
        settingMenu.SetActive(false);
        controlsMenu.SetActive(false);
        creditsMenu.SetActive(false);
        quitMenu.SetActive(false);
        playMenu.SetActive(true);
    }


    public void Settings()
    {
        settingMenu.SetActive(true);
        controlsMenu.SetActive(false);
        creditsMenu.SetActive(false);
        quitMenu.SetActive(false);
        playMenu.SetActive(false);
    }

    public void Controls()
    {
        settingMenu.SetActive(false);
        controlsMenu.SetActive(true);
        creditsMenu.SetActive(false);
        quitMenu.SetActive(false);
        playMenu.SetActive(false);
    }
    
    public void Credits()
    {
        settingMenu.SetActive(false);
        controlsMenu.SetActive(false);
        creditsMenu.SetActive(true);
        quitMenu.SetActive(false);
        playMenu.SetActive(false);
    }

    public void Quit()
    {
        settingMenu.SetActive(false);
        controlsMenu.SetActive(false);
        creditsMenu.SetActive(false);
        quitMenu.SetActive(true);
        playMenu.SetActive(false);
    }

    public void MenuAnim()
    {

        anim.SetBool("Start" , true);

    }

    public void Back()
    {
        settingMenu.SetActive(false);
        controlsMenu.SetActive(false);
        creditsMenu.SetActive(false);
        quitMenu.SetActive(false);
        playMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
