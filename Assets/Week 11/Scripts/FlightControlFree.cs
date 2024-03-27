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
    float distance = 0;

    private void Update()
    {
      
        interpolation += 0.2f *Time.deltaTime;
        if (interpolation < 1)
        {
            if (turning)
            {
                missile.transform.rotation = Quaternion.Lerp(currentHeading, newHeading, interpolation);
                distance = 3;

            }
            missile.transform.position += missile.transform.right*distance* 0.2f * Time.deltaTime;//update the position
        }
        if (missile.transform.rotation == newHeading)
            turning = false;
        if(interpolation > 1)
        {
            distance = 0;
        }
    }


    Quaternion newHeading;
    Quaternion currentHeading;
    Vector3 currentPosition;
    Vector3 newPosition;
    bool turning = false;
    
    
    public void MakeTurn(float turn)
    {
        interpolation = 0;
        turning = true;
        currentHeading = missile.transform.rotation;
        newHeading = currentHeading * Quaternion.Euler(0, 0, turn);

        currentPosition = missile.transform.position;
        newPosition = missile.transform.position + missile.transform.right;
        

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
        distance = length;
        currentHeading = missile.transform.rotation;
        newHeading = missile.transform.rotation;

        currentPosition = missile.transform.position;
        newPosition = missile.transform.position + transform.right*length;
        interpolation = 0;
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
