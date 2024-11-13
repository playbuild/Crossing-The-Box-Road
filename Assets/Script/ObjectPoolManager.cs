using UnityEngine;
using UnityEngine.Pool;

public class ObjectPoolManager : MonoBehaviour
{
    public static ObjectPoolManager instance;
    //������ƮǮ�� �ν��Ͻ�ȭ
    public int defaultCapacity = 10;
    //�⺻ �뷮�� 10��
    public int maxPoolSize = 15;
    //pool �ִ�ġ�� 15
    public GameObject CarPrefab;

    public IObjectPool<GameObject> Pool {  get; set; }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        //�ν��Ͻ� ����ڵ�
        else
            Destroy(this.gameObject);

        Init();
    }
    private void Init()
    {
        Pool = new ObjectPool<GameObject>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, true, defaultCapacity, maxPoolSize);

        for(int i = 0;i< defaultCapacity; i++)
        {
            CarSpeed Car = CreatePooledItem().GetComponent<CarSpeed>();
            Car.Pool.Release(Car.gameObject);
        }
    }

    //����
    private GameObject CreatePooledItem()
    {
        GameObject poolGo = Instantiate(CarPrefab);
        poolGo.GetComponent<CarSpeed>().Pool = this.Pool;
        return poolGo;
    }

    //���
    private void OnTakeFromPool(GameObject poolGo)
    {
        poolGo.SetActive(true);
    }

    //��ȯ
    private void OnReturnedToPool(GameObject poolGo)
    {
        poolGo.SetActive(false);
    }

    //����
    private void OnDestroyPoolObject(GameObject poolGo)
    {
        Destroy(poolGo);
    }
}
