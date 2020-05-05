using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBossAi : MonoBehaviour
{

    private Transform target;
    private float moveSpeed = 3;
    private float rotationSpeed = 3;
    private int aiOffset;

    private Transform myTransform;

    private void Awake()
    {
        //cache transform data for easy access/performance
        myTransform = transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Busca al player
        target = GameObject.FindWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 targetposition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);

        transform.LookAt(targetposition);

        myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;

    }
}
