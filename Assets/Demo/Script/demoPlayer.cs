using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class demoPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 10;
    public GameObject bullet;
    public Transform firePos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0,Input.GetAxis("Vertical"));
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0,Input.GetAxisRaw("Vertical"));
        Vector3 newPos = input * moveSpeed * Time.deltaTime;
        transform.position = Vector3.Slerp(transform.position, transform.position + newPos, .5f);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(input), .5f);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DemoFire();
        }
        //Debug.Log(input);
    }
    void DemoFire()
    {
        //Instantiate(bullet, firePos.position, Quaternion.identity);
        //Instantiate(bullet, firePos.position, bullet.transform.rotation);
        Instantiate(bullet, firePos.position, firePos.rotation);
        //Debug.Log(firePos.rotation);
    }
}
