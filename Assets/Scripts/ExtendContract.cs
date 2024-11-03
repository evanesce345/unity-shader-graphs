using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendContract : MonoBehaviour
{
    [Range(0, 1)] public float extendSpeed;
    public GameObject blade;

    private bool state;
    private float minScale;
    private float maxScale;
    private float interpol;
    private float currScale;
    private float initialX;
    private float initialZ;

    // Start is called before the first frame update
    void Start()
    {
        minScale = 0f;
        initialX = transform.localScale.x;
        initialZ = transform.localScale.z;
        maxScale = transform.localScale.y;
        currScale = maxScale;
        interpol = maxScale / extendSpeed;
        state = true;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            interpol = state ? -Mathf.Abs(interpol) : Mathf.Abs(interpol);
        }
        currScale += interpol * Time.deltaTime;
        currScale = Mathf.Clamp(currScale, minScale, maxScale);
        transform.localScale = new Vector3(initialX, currScale, initialZ);
        state = currScale > 0f;

        blade.SetActive(state);
    }
}