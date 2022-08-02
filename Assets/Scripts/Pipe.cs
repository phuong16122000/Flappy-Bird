using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() //goi dua tren FPS: Time.deltaTime = 1 / FPS;
    {
        Move();
    }

    private void Move()
    {
        //Vector3: x, y, z
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
