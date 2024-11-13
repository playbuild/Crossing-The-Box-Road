using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    int score;

    void Start()
    {
    }

    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            score = 100;
            Score.Instance.AddScore(score);
            Destroy(this.gameObject);
        }
    }
}