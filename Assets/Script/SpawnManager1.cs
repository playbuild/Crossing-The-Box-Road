using System.Collections.Generic;
using UnityEngine;

public class SpawnManager1 : MonoBehaviour
{
    public GameObject Spawn1;
    public GameObject Spawn2;
    //������ �־��ٰ�
    public float Spawntime;

    int CarCount = 0;

    private void Start()
    {
        if (Spawntime > 0)
        {
            InvokeRepeating("CarSpawn", 3f, Spawntime);
            //InvokeReapeating�� CarSpawn �޼��带 3�� �Ŀ� Spawntime�� �� �� ��ŭ�� �ʰ� ������ �ڿ� �ݺ� �ߵ���
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
            //Instantiate�� Spawn1�� �� �������� ��ȯ, transform.position�� ��ġ�� ��ũ��Ʈ�� �޸� ������Ʈ�� ��ġ�� ����, Quaternion�� Vector3.up(Y��) �߽����� 180�� ��ŭ �������� ���� ���� ȸ�� ��Ŵ
        }
        else
        {
            CarCount = 0;
            return Instantiate(Spawn2, transform.position, Quaternion.AngleAxis(0, Vector3.up));
        }
    }
}
