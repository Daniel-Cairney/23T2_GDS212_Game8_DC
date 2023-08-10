using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtojnScriipt : MonoBehaviour
{
   public void LoadMain()
   {
        SceneManager.LoadScene("TownDay");
   }
   
   public void LoadStory()
    {
        SceneManager.LoadScene("StoryTell");
    } 
}
