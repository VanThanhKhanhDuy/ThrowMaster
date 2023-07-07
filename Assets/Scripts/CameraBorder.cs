using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBorder : MonoBehaviour
{
    private Camera mainCamera;
    private float cameraMinX, cameraMaxX, cameraMinY, cameraMaxY;

    void Start(){
        mainCamera = Camera.main;
        CalculateCameraBounds();
    }

    void Update(){
        CheckObjectBounds();
    }

    void CalculateCameraBounds(){
        // Get the camera's viewport coordinates in world space
        Vector3 cameraMin = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane));
        Vector3 cameraMax = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, mainCamera.nearClipPlane));

        // Calculate the bounds based on the viewport coordinates
        cameraMinX = cameraMin.x;
        cameraMaxX = cameraMax.x;
        cameraMinY = cameraMin.y;
        cameraMaxY = cameraMax.y;
    }

    void CheckObjectBounds(){
        // Get all objects in the scene
        GameObject[] objectsInScene = GameObject.FindObjectsOfType<GameObject>();

        foreach (GameObject obj in objectsInScene){
            Vector3 clampedPosition = obj.transform.position;
            clampedPosition.x = Mathf.Clamp(clampedPosition.x, cameraMinX, cameraMaxX);
            clampedPosition.y = Mathf.Clamp(clampedPosition.y, cameraMinY, cameraMaxY);
            obj.transform.position = clampedPosition;
        }
    }
}
