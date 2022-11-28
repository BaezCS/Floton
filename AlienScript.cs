using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienScript : MonoBehaviour
{

    Animator animator;

/*
    public float cycle = 10000000;
    public float speed = 1f;
    public float pause = 1000f;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Left)
        {
            //for(int i = 0; i<cycle; i++)
            //{
                StartCoroutine(Move(Vector2.left));
                //transform.Translate(Vector2.left * speed * Time.deltaTime);

            //}
            Left = false;
        }
        else
        {
            //for (int i = 0; i < cycle; i++)
            //{
                StartCoroutine(Move(Vector2.right));
                //transform.Translate(Vector2.right * speed * Time.deltaTime);

            //}
            Left = true;
        }
    }
    IEnumerator Move(Vector2 direction)
    {
        for (int i = 0; i < cycle; i++)
        {
            yield return new WaitForSeconds(pause);

            transform.Translate(direction * speed * Time.deltaTime);

        }
       



        //print("released");
    }
    */
    public Vector3 pointB = new Vector3(-40,-25,0);
    public GameObject mirror;

    IEnumerator Start()
    {
        animator = GetComponent<Animator>();

        Vector3 pointA = transform.position;
        while (true)
        {
            yield return StartCoroutine(MoveObject(transform, pointA, pointB, 10));
            yield return StartCoroutine(MoveObject(transform, pointB, pointA, 10));
        }
    }

    IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
    {
        float i = 0.0f;
        float rate = 1.0f / time;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            thisTransform.position = Vector3.Lerp(startPos, endPos, i);
            yield return null;
        }
        if (animator.GetBool("Left"))
        {
            animator.SetBool("Left", false);
            mirror.transform.Translate(15, 0, 0);
        }
        else
        {
            animator.SetBool("Left", true);
            mirror.transform.Translate(-15, 0, 0);
        }
    }
}
