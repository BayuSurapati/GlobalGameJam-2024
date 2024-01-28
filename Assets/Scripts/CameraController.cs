using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private PlayerController player;
    public PolygonCollider2D cameraBoundsBox;

    private float halfHeight, halfWidth;
    // Start is called before the first frame update
    void Start()
    {
        

        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Camera.main.aspect;
    }

    private void Update()
    {
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(player != null)
        {
            transform.position = new Vector3 (
            Mathf.Clamp(player.transform.position.x, cameraBoundsBox.bounds.min.x + halfWidth, cameraBoundsBox.bounds.max.x - halfWidth), 
                Mathf.Clamp (player.transform.position.y,cameraBoundsBox.bounds.min.y + halfHeight, cameraBoundsBox.bounds.max.y - halfHeight),
                transform.position.z);
        }
    }
}
