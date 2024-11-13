using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;
using static UnityEngine.ParticleSystem;

public class FireWorks : MonoBehaviour
{
    public ParticleSystem Shot;
    int score;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            score = 500;
            Score.Instance.AddScore(score);
            Instantiate(Shot, transform.position, Quaternion.identity);
            Shot.Play();
            SoundManager.Instance.PlayEffect(SoundManager.SoundEffect.EffectFireworks);
            Destroy(gameObject);
        }
    }
}