using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    private AudioSource cash;
    private void Start()
    {
        cash = GetComponent<AudioSource>();

    }
    private void OnTriggerEnter(Collider other) //seçeceðimiz ses => shooting sound > magic_1 (audio source'a eklenecek)
    {
        if (other.gameObject.CompareTag("Cash"))
        {
            Destroy(other.gameObject);
            cash.Play();
        }
    }
}
