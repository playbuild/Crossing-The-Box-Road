using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackBtn : MonoBehaviour
{
    PlayerManager playerManager;
    public void BackMain()
    {
        SceneManager.LoadScene("MainScene");
    }
}
