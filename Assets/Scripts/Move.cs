using UnityEngine;

public class Move : MonoBehaviour
{

    [SerializeField] private Transform target;
    [SerializeField] private float speed;
    
    void FixedUpdate()
    {
        var pos = transform.position;
        var targetPos = target.transform.position;
        pos = Vector3.MoveTowards(pos, targetPos, Time.deltaTime * speed);
    }
}
