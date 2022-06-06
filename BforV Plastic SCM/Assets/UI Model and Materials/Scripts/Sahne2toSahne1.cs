using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class Sahne2toSahne1 : MonoBehaviour

{
    public void LoadScene(string Sahne1)
    {
        SceneManager.LoadScene(Sahne1);
    }

}