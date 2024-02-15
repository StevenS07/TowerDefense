
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    public int dmg = 1;
    public float speed = 0.1f;

    private Transform target;
    private int wavepointIndex = 0;

    public HealthBar healthBar;
    bool slowefect = false;
    void Start ()
    {
        target = WayPoints.points[0];
    }

    public void StartEfect(float slow, float slowtime)
    {   
        StartCoroutine(SlowEfect(slow, slowtime));
    }
    public IEnumerator SlowEfect(float slow, float slowtime)
    {   
        
        if(!slowefect){
        slowefect=true;
        float speedtemp = speed;
        speed = slow;
        yield return new WaitForSeconds(slowtime);
        speed = speedtemp;
        slowefect=false;
        }
    }
    void Update ()
    {
        Vector2 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        
        if (Vector2.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }

    }

    void GetNextWaypoint()
    {
        if(wavepointIndex >= WayPoints.points.Length-1)
        {   
            Destroy(gameObject);
            return;
        }
      wavepointIndex++;
      target = WayPoints.points[wavepointIndex]; 
      float dir =  Mathf.Atan2(target.position.y - transform.position.y, target.position.x- transform.position.x)*Mathf.Rad2Deg -transform.rotation.z;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, dir));
        transform.rotation= targetRotation;
      
      
    }
}
