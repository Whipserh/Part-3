using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightControlFree : MonoBehaviour
{
    public GameObject missile;
    public float speed = 5;
    public float turningSpeedReduction = 0.75f;
    Coroutine coroutine;
    float interpolation = 0;


    private void Update()
    {
        interpolation += Time.deltaTime;
        if (interpolation/speed < 1)
        {

            missile.transform.rotation = Quaternion.Lerp(currentHeading, newHeading, interpolation/speed);
            missile.transform.position = Vector3.Lerp(currentPosition, newPosition , interpolation/speed);//update the position
        }
        
    }
    Quaternion newHeading;
    Quaternion currentHeading;
    Vector3 currentPosition;
    Vector3 newPosition;
    public void MakeTurn(float turn)
    {
        
        
        currentHeading = missile.transform.rotation;
        newHeading = currentHeading * Quaternion.Euler(0, 0, turn);

        currentPosition = missile.transform.position;
        newPosition = missile.transform.position + transform.right;
        
        interpolation = 0;
        /**
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        coroutine = StartCoroutine(Turn(turn));
        */
    }


    public void MoveForwards(float length)
    {
        currentHeading = missile.transform.rotation;
        newHeading = missile.transform.rotation;

        currentPosition = missile.transform.position;
        newPosition = missile.transform.position + transform.right;
        /**
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        coroutine = StartCoroutine(RunLeg(length));
        **/
    }
    







    IEnumerator RunLeg(float legLength)
    {
        
        float time = 0;
        while (time < legLength)
        {
            time += Time.deltaTime;
            missile.transform.Translate(transform.right * speed * Time.deltaTime);
            yield return null;
        }
    }

    
    IEnumerator Turn(float turn)
    {
        

        float interpolation = 0;
        
        while (interpolation < 1)
        {
            interpolation += Time.deltaTime;
            
            missile.transform.Translate(transform.right * (speed * turningSpeedReduction) * Time.deltaTime);
            yield return null;
        }
    }
}
