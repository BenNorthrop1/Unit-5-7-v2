using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{


    Animator anim;

    public GameObject settings;
    public GameObject menu;


    void Start()
    {
        menu.SetActive(true);
        settings.SetActive(false);
        anim = GetComponent<Animator>();
        anim.SetBool("START" , true);
    }

    void Update()
    {
        
    }

    public void play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        anim.SetBool("START" , false);
    }

    public void Quit()
    {
        Application.Quit();
        anim.SetBool("START" , false);
    }

    public void Back()
    {
        settings.SetActive(false);
        menu.SetActive(true);
        anim.SetBool("START" , false);
    }

    public void Settings()
    {

        anim.SetBool("START" , false);
        menu.SetActive(false);
        settings.SetActive(true);
    }











}
