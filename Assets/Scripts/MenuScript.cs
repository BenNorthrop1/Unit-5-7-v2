using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{


    Animator anim;

    public Animator camAnim;



    public GameObject settings;
    public GameObject menu;

    public GameObject Mainmenu;

    public GameObject titleText;
    public GameObject start;


    void Start()
    {
        anim = GetComponent<Animator>();

        start.SetActive(true);
        menu.SetActive(false);
        settings.SetActive(false);
        titleText.SetActive(false);
      
    }

    void Update()
    {
          if(Input.anyKey)
        {
            camAnim.SetBool("Start" , true);
            start.SetActive(false);

            Mainmenu.SetActive(true);
            
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
        titleText.SetActive(true);
        anim.SetBool("TitleStart", true);
    }

    public void MenuAnimation()
    {

    }








}
