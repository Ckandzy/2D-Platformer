using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamekit2D;

public class LevelSpawner : ObjectPool<LevelSpawner, LevelObject, Vector2>
{
    //public int totalLevelsToBeSpawned;
    /// <summary>
    /// 同时存在的关卡
    /// </summary>
    public int concurrentLevelsToBeSpawned;
    public Transform levelStartPos;
    public float LenthPerLevel;
    public int totalLevelCount;
    //protected int m_TotalSpawnedLevelCount;
    public int m_CurrentSpawnedLevelCount;
    public Coroutine m_SpawnTimerCoroutine;

    public void LevelInit()
    {
        totalLevelCount = 0;
        m_CurrentSpawnedLevelCount = 0;
        m_SpawnTimerCoroutine = null;
        PushAll();
        for (int i = 0; i < initialPoolCount; i++)
        {
            LevelObject newLevel = CreateNewPoolObject();
            pool.Add(newLevel);
        }
        
        int count = concurrentLevelsToBeSpawned - m_CurrentSpawnedLevelCount;
        if (count > 0)
            for (int i = 0; i < count; i++)
            {
                Pop(levelStartPos.position - new Vector3(0, totalLevelCount * LenthPerLevel, 0));
                totalLevelCount++;
                m_CurrentSpawnedLevelCount++;
            }
        StartSpawnTimer();
    }

    void Start()
    {
        LevelInit();
    }
    public override void Push(LevelObject poolObject)
    {
        poolObject.inPool = true;
        m_CurrentSpawnedLevelCount--;
        poolObject.Sleep();
    }

    protected void StartSpawnTimer()
    {
        if (m_SpawnTimerCoroutine == null)
            m_SpawnTimerCoroutine = StartCoroutine(Spawn());
    }

    protected IEnumerator Spawn()
    {
        //while (m_CurrentSpawnedLevelCount < concurrentLevelsToBeSpawned && m_TotalSpawnedLevelCount < totalLevelsToBeSpawned)
        //{
        //    Pop(transform.position);
        //    m_CurrentSpawnedLevelCount++;
        //}
        while (true)
        {
            if (m_CurrentSpawnedLevelCount < concurrentLevelsToBeSpawned)
            {
                Pop(levelStartPos.position - new Vector3(0, totalLevelCount * LenthPerLevel, 0));
                totalLevelCount++;
                m_CurrentSpawnedLevelCount++;
            }
            yield return null;
        }
    }

    public void ResetLevelSpawner()
    {
        LevelInit();
    }
}

public class LevelObject : PoolObject<LevelSpawner, LevelObject, Vector2>
{
    //public Damageable damageable;
    //public EnemyBehaviour enemyBehaviour;
    public Transform transform;
    public Level level;

    protected WaitForSeconds m_RemoveWait;

    protected override void SetReferences()
    {
        //damageable = instance.GetComponent<Damageable>();
        //enemyBehaviour = instance.GetComponent<EnemyBehaviour>();

        //damageable.OnDie.AddListener(ReturnToPoolEvent);

        //m_RemoveWait = new WaitForSeconds(objectPool.removalDelay);
        transform = instance.transform;
        level = instance.GetComponent<Level>();
        level.levelPoolObject = this;
    }

    public override void WakeUp(Vector2 info)
    {
        //enemyBehaviour.SetMoveVector(Vector2.zero);
        instance.SetActive(true);
        instance.transform.position = info;
        instance.GetComponentInChildren<EnemySpawner>().ResetSpawner();
        instance.GetComponent<Level>().WakeUp();
        //damageable.SetHealth(damageable.startingHealth);
        //damageable.DisableInvulnerability();
        //enemyBehaviour.contactDamager.EnableDamage();
        //SceneLinkedSMB<EnemyBehaviour>.Initialise(enemyBehaviour.GetComponent<Animator>(), enemyBehaviour);
        //enemyBehaviour.EndAttack();
    }

    public override void Sleep()
    {
        instance.GetComponentInChildren<EnemySpawner>().PushAll();
        //instance.GetComponent<Level>()
        instance.SetActive(false);
    }
}
