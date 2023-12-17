using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class NavigationController : MonoBehaviour
{
public void navigatetoStart()
    {
        Application.LoadLevel(0);
    }
    public void navigatetoL1()
    {
        Application.LoadLevel(14);
    }
    public void navigatetoL2()
    {
        Application.LoadLevel(2);
    }
    public void navigatetoL3()
    {
        Application.LoadLevel(3);
    }
    public void navigatetoL4()
    {
        Application.LoadLevel(4);
    }
    public void navigatetoGameOver()
    {
        Application.LoadLevel(5);
    }
    public void navigatetoWin()
    {
        Application.LoadLevel(6);
    }
    public void navigateCutscene1()
    {
        Application.LoadLevel(10);
    }
    public void navigateCutscene2()
    {
        Application.LoadLevel(11);
    }
    public void navigateCutscene3()
    {
        Application.LoadLevel(12);
    }
    public void navigateCutscene4()
    {
        Application.LoadLevel(13);
    }
    public void Quit()
    {
        Application.Quit();
    }

}
