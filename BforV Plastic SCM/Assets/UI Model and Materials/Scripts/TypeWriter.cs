using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TypeWriter : MonoBehaviour
{
    public float delay = 0.1f;
    public string yazi;
    Text thisText;

    private void Start()
    {
        thisText = GetComponent<Text>();
        StartCoroutine(TypeWrite());
    }
    IEnumerator TypeWrite()
    {
        foreach (char i in yazi)
        {
            thisText.text += i.ToString();
            if (i.ToString() == ".") { yield return new WaitForSeconds(1); }
            else { yield return new WaitForSeconds(delay); }
        }
    }
}