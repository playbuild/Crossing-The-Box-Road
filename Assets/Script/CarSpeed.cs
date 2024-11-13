using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class CarSpeed : MonoBehaviour
{
    public CarData carData;
    public GameObject Car;
    public IObjectPool<GameObject> Pool { get; set; }

    private float Carspeed;
    private Material Carmaterial;

    // Start is called before the first frame update
    void Start()
    {
        Carspeed = carData.Speed;
        Carmaterial = carData.Color;
    }

    // Update is called once per frame
    void Update()
    {
        //speed = CarDataValues.speed;

        transform.Translate (Vector3.forward * Carspeed);
        gameObject.GetComponent<Renderer>().material = Carmaterial;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
            //Pool.Release(this.gameObject);
        }
    }
}
