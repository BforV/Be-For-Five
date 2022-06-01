using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class Sahne3toSahne4 : MonoBehaviour
//Butona onclik kismina scenecontroller atilacak.
//Sonraki sahnenin adi "Sahne4" yerine yazilacak.
//Gecilecek sahne file/Build Settings/Add Scenes'ten eklenmis olacak.
{
    public void LoadScene(string Sahne4)
    {
        SceneManager.LoadScene(Sahne4);
    }

}
