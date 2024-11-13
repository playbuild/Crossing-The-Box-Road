using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public enum Bgm
    {
        TitleBGM,
        IngameBGM
    }

    public enum SoundEffect
    {
        EffectCoin,
        EffectCrash,
        EffectClear,
        EffectFireworks
    }
    //audio clip 담을 배열
    [SerializeField] AudioClip[] bgms;
    [SerializeField] AudioClip[] effects;

    //플레이 될 audioSource 배열
    [SerializeField] AudioSource bgmsources;
    [SerializeField] AudioSource effectsources;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        //방어코드
    }
    public void PlayBGM(Bgm bgmIdx)
    {
        //enum을 int형으로 변환
        bgmsources.clip = bgms[(int)bgmIdx];
        bgmsources.Play();
    }

    public void StopBGM()
    {
        bgmsources.Stop();
    }

    public void PlayEffect(SoundEffect effect)
    {
        effectsources.PlayOneShot(effects[(int)effect]);
    }
}
