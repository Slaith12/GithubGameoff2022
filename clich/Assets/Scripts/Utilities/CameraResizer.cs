using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraResizer : MonoBehaviour
{
    private new Camera camera;
    private float normalSize;

    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
        normalSize = camera.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        float aspect = (float)Screen.width / Screen.height;
        float difference = (16f / 9) / aspect;
        if(difference > 1)
        {
            camera.orthographicSize = normalSize * difference;
        }
        else
        {
            camera.orthographicSize = normalSize;
        }
    }
}
