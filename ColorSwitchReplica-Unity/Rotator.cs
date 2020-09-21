
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float speed = 100f;//svake sekudne 100 stepeni

    // Update is called once per frame
    void Update()
    {
        if (transform.name!="SmallCircleDifferent")
        transform.Rotate(0f, 0f, speed*Time.deltaTime );
        else
        {
            transform.Rotate(0f, 0f, -speed * Time.deltaTime);

        }
    }
}
