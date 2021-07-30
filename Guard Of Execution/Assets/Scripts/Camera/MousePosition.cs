//Used this video https://www.youtube.com/watch?v=0jTPKz3ga4w to find position of mouse

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{

    [SerializeField] private Camera mainCamera;

    // Update is called once per frame
    private void Update()
    {
        mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mouseFollow = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mouseFollow;
    }
}
