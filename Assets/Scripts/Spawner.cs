using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform spawnPoint;
    public float[] spwanTime ;
    
    public Transform[] LVL;

    public float[] eps ;

    public float waves=0 ;

    private int awave=0;

    public bool end = false;
    
    WinMenu winmenu;

    public int[] enemyInWave;

   

    public void Update()
    {
         bool EnemyOnMap = GameObject.FindGameObjectsWithTag("Enemy").Length > 0;
        if(end==true && EnemyOnMap==false )
        {
            winmenu = FindAnyObjectByType<WinMenu>();
            winmenu.WinMenuActiveate();
            return;
        }
    }
    void Start ()
    {
            StartCoroutine(SpawnWave());
    }

    IEnumerator SpawnWave ()
    {
            do
            {     
                for(int i = 0 ; i< enemyInWave[awave];i++)
                {
                 SpawnEnemy(awave);
                 yield return new WaitForSeconds(eps[awave]);
                }
                yield return new WaitForSeconds(spwanTime[awave]);
                awave++;
             }while(awave<=waves);
             end = true;      
    }

    void SpawnEnemy (int wave)
    {
        Instantiate(LVL[wave], spawnPoint.position, spawnPoint.rotation);
    }
}
