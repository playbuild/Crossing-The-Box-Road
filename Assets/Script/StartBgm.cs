using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StartBgm : MonoBehaviour
{
    public void Awake()
    {
        SoundManager.Instance.PlayBGM(SoundManager.Bgm.TitleBGM);
    }

}
