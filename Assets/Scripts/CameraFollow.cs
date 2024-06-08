using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform lookAt;

    public float boundX = 0.15f;
    public float boundY = 0.1f;

    public Vector2 minBounds;
    public Vector2 maxBounds;

    public float speed;

    void LateUpdate() {
        Vector3 delta = Vector3.zero;

        float deltaX = lookAt.position.x - transform.position.x;
        
        if (deltaX > boundX || deltaX < -boundX) {
            if (deltaX > 0)
                delta.x = deltaX - boundX;
            else
                delta.x = deltaX + boundX;
        }

        float deltaY = lookAt.position.y - transform.position.y;
        
        if (deltaY > boundY || deltaY < -boundY) {
            if (deltaY > 0)
                delta.y = deltaY - boundY;
            else
                delta.y = deltaY + boundY;
        }
        
        Vector3 pos = transform.position +  new Vector3(delta.x, delta.y, 0);

        pos.x = Mathf.Clamp(pos.x, minBounds.x, maxBounds.x);
        pos.y = Mathf.Clamp(pos.y, minBounds.y, maxBounds.y);

        transform.position = Vector3.Slerp(transform.position, pos, Time.deltaTime*speed);
    }
}