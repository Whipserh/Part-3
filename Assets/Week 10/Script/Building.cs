using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public GameObject post1, post2, roof;
    public float speed = 2f;
    private float a, b, c;
    IEnumerator buildStall()
    {
        
        //wait till scale of the object is back to normal
        while (post1.transform.localScale.y < 1f)
        {

            a += Time.deltaTime;
            post1.transform.localScale = Vector3.Lerp(new Vector3(1, 0, 1), new Vector3(1, 1.1f, 1), a/speed);
            yield return null;//pauses until the next frame
        }
        a = 0;
        //wait till scale of the object is back to normal
        while (post2.transform.localScale.y < 1)
        {
            a += Time.deltaTime;
            post2.transform.localScale = Vector3.Lerp(new Vector3(1, 0, 1), new Vector3(1, 1.1f, 1), (a) / speed);
            yield return null;
        }
        a = 0;
        //wait till scale of the object is back to normal
        while (roof.transform.localScale.y < 1)
        {
            a+= Time.deltaTime;
            roof.transform.localScale = Vector3.Lerp(new Vector3(1, 0, 1), new Vector3(1, 1.1f, 1), (a) / speed);
            yield return null;
        }
    }





    // Start is called before the first frame update
    void Start()
    {
        a = 0;
        StartCoroutine(buildStall());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
