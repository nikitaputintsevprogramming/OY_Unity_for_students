using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moving : MonoBehaviour
{
    public float speed = 1.0F; 
    public float jumpValue = 7.0F; 
    public float gravity = 20.0F; 
    private Vector3 moveDirection = Vector3.zero; 

    private int jumpBool;                          
    private int groundedBool;                      
    private bool jump;                             
    private bool isColliding;
    private Vector3 colExtents;
    private int motion;
    public GameObject fox;
    private int money;
    public Text Score;

  
    void Start()
    {
        jumpBool = Animator.StringToHash("Jump");
        groundedBool = Animator.StringToHash("Grounded");
        GetComponent<Animator>().SetInteger("Move", 2);
        //GetComponent<Animator>().SetBool("N", true);

    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Money")  
        {
            money +=1;
            Score.text = money.ToString();
            Destroy(collision.gameObject);
        }
    }
    void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {
            fox.transform.rotation*=Quaternion.Euler(0, -1, 0);
            GetComponent<Animator>().SetInteger("Move", 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            fox.transform.rotation *= Quaternion.Euler(0, 1, 0);
            GetComponent<Animator>().SetInteger("Move", 1);
        }
        if (Input.GetKey(KeyCode.W))
        {
            fox.transform.position += fox.transform.forward * speed *1* Time.deltaTime;
            GetComponent<Animator>().SetInteger("Move", 2);
        }
        if (Input.GetKey(KeyCode.S))
        {
            fox.transform.position += fox.transform.forward * speed*-1 * Time.deltaTime;
            GetComponent<Animator>().SetInteger("Move", 3);
        }
        if (Input.GetButton("Jump"))
        {
            GetComponent<Animator>().SetBool(jumpBool, true);
            moveDirection.y = jumpValue *20* Time.deltaTime;
            fox.transform.Translate(moveDirection * Time.deltaTime);
        }

        else
        {
            GetComponent<Animator>().SetBool(jumpBool, false);
        }

        if (Input.GetAxis("Vertical") == 0)
            GetComponent<Animator>().SetBool("N", true);
        else
            GetComponent<Animator>().SetBool("N", false);
    }
}