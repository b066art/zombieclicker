using UnityEngine;

public class AIRagdoll : MonoBehaviour
{
    [SerializeField] private GameObject _root;

    private void Awake()
    {
        RagdollOff();
    }

    public void RagdollOn()
    {
        Collider[] collidersObj = _root.GetComponentsInChildren<Collider>();
        for (var index = 0; index < collidersObj.Length; index++)
        {
            var colliderItem = collidersObj[index];
            colliderItem.enabled = true;
        }

        Rigidbody[] rbObj = _root.GetComponentsInChildren<Rigidbody>();
        for (var index = 0; index < rbObj.Length; index++)
        {
            var rbItem = rbObj[index];
            rbItem.useGravity = true;
        }
    }

    private void RagdollOff()
    {
        Collider[] collidersObj = _root.GetComponentsInChildren<Collider>();
        for (var index = 0; index < collidersObj.Length; index++)
        {
            var colliderItem = collidersObj[index];
            colliderItem.enabled = false;
        }

        Rigidbody[] rbObj = _root.GetComponentsInChildren<Rigidbody>();
        for (var index = 0; index < rbObj.Length; index++)
        {
            var rbItem = rbObj[index];
            rbItem.useGravity = false;
        }
    }
}
