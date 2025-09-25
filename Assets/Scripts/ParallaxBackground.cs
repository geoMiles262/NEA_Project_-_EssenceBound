using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("Parallax Settings")]
    [SerializeField] private float parallaxFactorX = 0.5f; // how much X movement is reduced
    [SerializeField] private float parallaxFactorY = 0.5f; // how much Y movement is reduced

    private Transform cam;
    private Vector3 previousCamPos;


    void Start()
    {
        cam = Camera.main.transform;
        previousCamPos = cam.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        Vector3 deltaMovement = cam.position - previousCamPos;
        transform.position += new Vector3(deltaMovement.x * parallaxFactorX, deltaMovement.y * parallaxFactorY, 0);
        previousCamPos = cam.position;
    }
}
