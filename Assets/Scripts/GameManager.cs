using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject mazePast;
    public GameObject mazeFuture;
    private bool isFuture;

    void Start()
    {
        mazePast.SetActive(true);
        mazeFuture.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isFuture = !isFuture;
            mazePast.SetActive(!isFuture);
            mazeFuture.SetActive(isFuture);
        }
    }


}
