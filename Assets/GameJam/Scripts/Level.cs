using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamekit2D;
using UnityEngine.Events;
using System;

public class Level : MonoBehaviour
{
    [HideInInspector]
    public LevelObject levelPoolObject;
    public EnemySpawner enemySpawner;
    public List<BreakablePlatform> breakablePlatforms;

    public float maxLenthFromPlayer = 20f;
    public float curLenthFromPlayer;
    public UnityEvent levelDestroyEvent;
    // Start is called before the first frame update
    private void Awake()
    {
        
    }
    private void Start()
    {
        breakablePlatforms = new List<BreakablePlatform>(GetComponentsInChildren<BreakablePlatform>());
    }

    // Update is called once per frame
    void Update()
    {
        curLenthFromPlayer = this.transform.position.y - PlayerCharacter.PlayerInstance.transform.position.y;
        if (this.transform.position.y - PlayerCharacter.PlayerInstance.transform.position.y > maxLenthFromPlayer)
        {
            levelDestroyEvent.Invoke();
        }
        //Debug
        enemySpawner = levelPoolObject.instance.GetComponentInChildren<EnemySpawner>();
    }

    public void ReturnToPool()
    {
        levelPoolObject.ReturnToPool();
    }
    public void WakeUp()
    {
        foreach(var bp in breakablePlatforms)
        {
            bp.WakeUp();
        }
    }
}
