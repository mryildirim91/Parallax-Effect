using StarterKit.Base;
using UnityEngine;

public class FollowPlayer : BaseObject
{
    [SerializeField]
    private Transform _target;

    [SerializeField]
    private float _smoothness;

    [SerializeField]
    private Vector3 _offset;

    public override void BaseObjectFixedUpdate()
    {
        Follow();
    }

    private void Follow()
    {
        Vector3 desiredPos = _target.position + _offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, _smoothness * Time.deltaTime);

        transform.position = smoothedPos;
    }
}
