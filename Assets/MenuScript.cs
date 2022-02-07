using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{


    Animator anim;

    public GameObject settings;
    public GameObject menu;

    public GameObject start;


    void Start()
    {
        anim = GetComponent<Animator>();

        start.SetActive(true);
        menu.SetActive(false);
        settings.SetActive(false);
        anim.SetBool("Start",false);
      
    }

    void Update()
    {
          if(Input.anyKey == true)
        {
            anim.SetBool("Start" , true);
            start.SetActive(false);
        }
    }

    public void play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }

    public void Quit()
    {
        Application.Quit();
        
    }

    public void Back()
    {
        settings.SetActive(false);
        menu.SetActive(true);
        
    }

    public void Settings()
    {

        
        menu.SetActive(false);
        settings.SetActive(true);
    }

    public void TitleAnimation()
    {
        
    }










}
