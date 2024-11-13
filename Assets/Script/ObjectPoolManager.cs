using UnityEngine;
using UnityEngine.Pool;

public class ObjectPoolManager : MonoBehaviour
{
    public static ObjectPoolManager instance;
    //오브젝트풀을 인스턴스화
    public int defaultCapacity = 10;
    //기본 용량은 10개
    public int maxPoolSize = 15;
    //pool 최대치는 15
    public GameObject CarPrefab;

    public IObjectPool<GameObject> Pool {  get; set; }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        //인스턴스 방어코드
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

    //생성
    private GameObject CreatePooledItem()
    {
        GameObject poolGo = Instantiate(CarPrefab);
        poolGo.GetComponent<CarSpeed>().Pool = this.Pool;
        return poolGo;
    }

    //사용
    private void OnTakeFromPool(GameObject poolGo)
    {
        poolGo.SetActive(true);
    }

    //반환
    private void OnReturnedToPool(GameObject poolGo)
    {
        poolGo.SetActive(false);
    }

    //삭제
    private void OnDestroyPoolObject(GameObject poolGo)
    {
        Destroy(poolGo);
    }
}
