using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demoBullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10;
    void Start()
    {
        InvokeRepeating("MoveForward", 0, 0.01f);
        //StartCoroutine(MoveForwardV2());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void MoveForward()
    {

        //Vector3.Forward
        transform.position = Vector3.Slerp(transform.position, transform.position + transform.forward * Time.deltaTime * speed, 0.1f);
        //transform.position += transform.forward * Time.deltaTime * speed;
    }

    IEnumerator MoveForwardV2()
    {
        while(true){
            transform.position = Vector3.Slerp(transform.position, transform.position + transform.forward * Time.deltaTime * speed, 0.1f);
            //transform.position += transform.forward * Time.deltaTime * speed;
            //Debug.Log(transform.position);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
