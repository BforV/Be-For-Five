using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class Sahne1toSahne2 : MonoBehaviour

//Butona onclik kismina scenecontroller atilacak.
//Sonraki sahnenin adi "Sahne3" yerine yazilacak.
//Gecilecek sahne file/Build Settings/Add Scenes'ten eklenmis olacak.
{
    public void LoadScene(string Sahne2)
    {
        SceneManager.LoadScene(Sahne2);
    }

}

