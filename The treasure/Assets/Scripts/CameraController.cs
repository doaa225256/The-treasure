using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Target;
    public float Cameraspeed;
    public float minX,maxX;
    public float minY, maxY;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {

        if (Target != null)
        {
            Vector2 newcamPosition = Vector2.Lerp(transform.position, Target.position, Time.deltaTime * Cameraspeed);
            float ClampX = Mathf.Clamp(newcamPosition.x, minX, maxX);
            float ClampY = Mathf.Clamp(newcamPosition.y, minY, maxY);
            transform.position = new Vector3(ClampX, ClampY, -10f);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
