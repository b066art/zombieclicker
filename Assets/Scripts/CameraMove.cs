using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private int minX = -70;
    [SerializeField] private int maxX = 0;
    [SerializeField] private int minZ = -115;
    [SerializeField] private int maxZ = -35;
    [SerializeField] private int cameraY = 35;

    private Vector3 hitPosition;
    private Vector3 currentPosition;
    private Vector3 cameraPosition;


    private void Start()
    {

    }
    
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            hitPosition = Input.mousePosition;
            cameraPosition = transform.position;
            
        }

        if(Input.GetMouseButton(0))
        {
            currentPosition = Input.mousePosition;
            MouseDrag();        
        }
    }
    
    private void MouseDrag()
    {
        currentPosition.z = hitPosition.z = cameraPosition.y;

        Vector3 direction = Camera.main.ScreenToWorldPoint(currentPosition) - Camera.main.ScreenToWorldPoint(hitPosition);

        direction = direction * -1;

        Vector3 position = cameraPosition + direction;

        transform.position = position;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), cameraY, Mathf.Clamp(transform.position.z, minZ, maxZ));
    }
}
