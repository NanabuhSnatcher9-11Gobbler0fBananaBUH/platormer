using Unity.VisualScripting;
using UnityEngine;

public class WaypointFollower : MonoBehaviour


{

    [SerializeField] private GameObject[] waypoints;
    private int i = 0;
    private float speed = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, waypoints[i].transform.position) < 0.1f)        
        {
            if(i >= waypoints.Length-1)
            {
                i = 0;
            }
            else
            {
                i++;
            }
        }

        transform. position = Vector2.MoveTowards(transform.position, waypoints[i].transform. position, Time.deltaTime * speed);
    }
}
