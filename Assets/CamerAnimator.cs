using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerAnimator : MonoBehaviour
{


    public MenuScript ms;

    public void TitleAnim()
    {
        ms.TitleAnimation();
    }
    
    public void MenuAnim()
    {
        ms.MenuAnimation();

    }
}
