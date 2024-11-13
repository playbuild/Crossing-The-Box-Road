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
    //audio clip ���� �迭
    [SerializeField] AudioClip[] bgms;
    [SerializeField] AudioClip[] effects;

    //�÷��� �� audioSource �迭
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
        //����ڵ�
    }
    public void PlayBGM(Bgm bgmIdx)
    {
        //enum�� int������ ��ȯ
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
