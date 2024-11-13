using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public GameObject GameClear;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameClear.SetActive(true);
            SoundManager.Instance.PlayEffect(SoundManager.SoundEffect.EffectClear);
            Time.timeScale = 0.0f;
        }
    }
}
