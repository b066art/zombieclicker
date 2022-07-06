using System.Collections;
using UnityEngine;

public class TargetClicker : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private AudioSource hitSound;
    [SerializeField] private AudioSource shotgunSound;

    public bool superBullet = false;

    private float clickTime;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetMouseButtonDown (0))
        {
           clickTime = Time.time;
        }
        
        if(Input.GetMouseButtonUp(0) && (Time.time - clickTime) < 0.2)
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if(hitInfo.collider.gameObject.GetComponent<AIHealth>() != null)
                {
                    if(!superBullet)
                    {
                        hitSound.pitch = Random.Range(0.9f, 1.1f);
                        hitSound.Play();
                        hitInfo.collider.gameObject.GetComponent<AIHealth>().DecreaseHealth();
                    }
                    else
                    {
                        shotgunSound.Play();
                        hitInfo.collider.gameObject.GetComponent<AIHealth>().DecreaseAllHealth();
                    }
                }
            }
        }
    }

    public IEnumerator SetSuperBulletMode(float durationTime)
    {
        superBullet = true;
        yield return new WaitForSeconds(durationTime);
        superBullet = false;
    }
}
