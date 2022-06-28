using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public Transform stackParent;
    private Vector3 newPos;

    int indexOrange = 0;
    int indexBlue = 0;
    int indexYellow = 0;
    private void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag=="Obstacle")
        {
            Destroy(gameObject);

            newPos = stackParent.localPosition;
            newPos.x = 0;
            newPos.y -= 1;
            newPos.z = 0;
            stackParent.localPosition = newPos;

        }

    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Orange" && gameObject.tag == "Orange")
        {
            indexOrange += 1;
            indexBlue = 0;
            indexYellow = 0;
            if (collision.gameObject.tag == "Orange" && indexOrange == 2)
            {
                Destroy(gameObject);
                Destroy(collision.gameObject);
                PositionCube();
                indexOrange = 0;
            }
            else if (collision.gameObject.tag == "Blue" && gameObject.tag == "Blue")
            {
                indexBlue += 1;
                indexYellow = 0;
                indexOrange = 0;
                if (collision.gameObject.tag == "Blue" && indexBlue == 2)
                {
                    Destroy(gameObject);
                    Destroy(collision.gameObject);
                    PositionCube();
                    indexBlue = 0;
                }
            }
            else if (collision.gameObject.tag == "Yellow" && gameObject.tag == "Yellow")
            {
                indexYellow += 1;
                indexOrange = 0;
                indexBlue = 0;
                if (collision.gameObject.tag == "Yellow" && indexYellow == 2)
                {
                    Destroy(gameObject);
                    Destroy(collision.gameObject);
                    PositionCube();
                    indexYellow = 0;

                }
            }
        }
        
        void PositionCube()
        {
            newPos = stackParent.localPosition;
            newPos.x = 0;
            newPos.y -= 2;
            newPos.z = 0;
            stackParent.localPosition = newPos;
        }

    }
}
