using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveNPC : MonoBehaviour
{
    private Transform Target;
    private int RandomSpeed;
    void Start()
    {
        FindMyTarget();
    }

    void Update()
    {
        this.transform.LookAt(Target.transform);
        this.transform.position = Vector3.MoveTowards(this.transform.position, Target.transform.position, GameManager.Instance.FindRand(RandomSpeed, 1,4)* Time.deltaTime);
        if(transform.position == Target.transform.position) { Destroy(gameObject); }

    }

    void FindMyTarget()
    {
        if (this.tag == "pos0")
        {
            Target = GameObject.Find("destroyPos01").transform;
        }
        else if (this.tag == "pos1")
        {
            Target = GameObject.Find("destroyPos02").transform;
        }
    } 
}
