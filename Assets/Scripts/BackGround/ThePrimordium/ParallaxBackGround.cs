using UnityEngine;
//this scripts is for helping the background move with camera
public class ParallaxBackGround : MonoBehaviour
{
    private GameObject camera;
    
    private float cameraStartXPosition;
    private float cameraStartYPosition;
    [SerializeField]  private float xParallaxEffect = 1;

    [SerializeField]  private float yParallaxEffect = 0.95f;

    private float xPosition;
    private float yPosition;
    
    private float xLength;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camera = GameObject.Find("Main Camera");
        cameraStartXPosition = camera.transform.position.x;
        cameraStartYPosition = camera.transform.position.y;
        xPosition = transform.position.x;
        yPosition = transform.position.y;
        xLength = GetComponent<SpriteRenderer>().bounds.size.x;
        
    }

    // Update is called once per frame
    void Update()
    {
        float distanceMoved = camera.transform.position.x * (1 - xParallaxEffect);
        float distanceToMove = camera.transform.position.x * xParallaxEffect;
        float yDistanceMoved = camera.transform.position.y * (1 - yParallaxEffect);
        float yDistanceToMove = camera.transform.position.y * yParallaxEffect;
        
        transform.position = new Vector3(xPosition + distanceToMove, yPosition + yDistanceToMove);

        if (distanceMoved - xPosition> xLength)
        {
            xPosition = xPosition + xLength;
            cameraStartXPosition = camera.transform.position.x;
        }
        else if (distanceMoved - xPosition < -xLength)
        {
            xPosition = xPosition - xLength;
            cameraStartXPosition = camera.transform.position.x;
        }
    }
}
