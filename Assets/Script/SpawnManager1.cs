using System.Collections.Generic;
using UnityEngine;

public class SpawnManager1 : MonoBehaviour
{
    public GameObject Spawn1;
    public GameObject Spawn2;
    //프리팹 넣어줄곳
    public float Spawntime;

    int CarCount = 0;

    private void Start()
    {
        if (Spawntime > 0)
        {
            InvokeRepeating("CarSpawn", 3f, Spawntime);
            //InvokeReapeating은 CarSpawn 메서드를 3초 후에 Spawntime에 들어간 값 만큼의 초가 지나간 뒤에 반복 발동됨
        }
    }

    public GameObject CarSpawn()
    {
        if (Spawn1 == null)
            return null;

        if(CarCount < 3)           
        {
            GameObject Car1 = Instantiate(Spawn1, transform.position, Quaternion.AngleAxis(0, Vector3.up));
            CarCount++;
            return Car1;
            //Instantiate는 Spawn1에 들어갈 프리팹을 소환, transform.position은 위치를 스크립트라 달린 오브젝트의 위치로 지정, Quaternion은 Vector3.up(Y축) 중심으로 180도 만큼 프리팹의 스폰 방향 회전 시킴
        }
        else
        {
            CarCount = 0;
            return Instantiate(Spawn2, transform.position, Quaternion.AngleAxis(0, Vector3.up));
        }
    }
}
