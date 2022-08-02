using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGenerator : MonoBehaviour
{
    public GameObject pipePrefab;

    private float countdown;
    public float timeDuration;
    public bool enableGenratePipe; //Cho phep sinh ra ong !

    private void Awake()
    {
        countdown = 1f;
        enableGenratePipe = false;
    }

    void Update() //
    {
        if(enableGenratePipe == true)
        {
            countdown -= Time.deltaTime; //moi frame countdown -= 1 /fps
                                         //30 FPS: moi frame countdown giam di 1/30s, mot giay (30 frames) thi countdown giam di dung 1
            if (countdown <= 0)
            {
                //Sinh ra ong
                Instantiate(pipePrefab, new Vector3(10, Random.Range(-1.2f, 2.1f), 0), Quaternion.identity);
                countdown = timeDuration;
            }
        }
    }
}
