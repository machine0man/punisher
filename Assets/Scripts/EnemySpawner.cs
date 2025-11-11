using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    static EnemySpawner s_instance;

    [SerializeField] float m_spawnIntervalSec = 10f;
    [SerializeField] int m_numberOfEnemies = 10;
    [SerializeField] float m_spawnInnerRadius = 10f;
    [SerializeField] float m_spawnOuterRadius = 15f;
    [SerializeField] int m_maxEnemies = 500;
    [SerializeField] Enemy m_prefEnemy;
    [SerializeField] Pearl m_prefPearl;
    [SerializeField] List<Enemy> m_lstEnemies;

    float m_curTime = 0f;

    ItemPool<Enemy> m_poolEnemy;
    ItemPool<Pearl> m_poolPearl;

    #region Unity Methods
    private void Awake()
    {
        s_instance = this;
    }
    private void OnDestroy()
    {
        s_instance = null;
    }
    #endregion

    void Start()
    {
        m_poolEnemy = new ItemPool<Enemy>(m_prefEnemy, 100);
        m_poolPearl = new ItemPool<Pearl>(m_prefPearl, 100);
        SpawnEnemies();
    }
    private void Update()
    {
        m_curTime += Time.deltaTime;

        if (m_curTime > m_spawnIntervalSec)
        {
            SpawnEnemies();
            m_curTime = 0f;
        }
    }
    void SpawnEnemies()
    {
        for (int i = 0; i < m_numberOfEnemies; i++)
        {
            float l_randDist = Random.Range(m_spawnInnerRadius, m_spawnOuterRadius);
            Vector3 l_randomPoint = Random.insideUnitCircle * l_randDist;
            l_randomPoint.z = 0f;

            Vector3 l_spawnPosition = Gameplay.Player.Position + l_randomPoint;

            Enemy l_enemy = m_poolEnemy.GetItem();
            l_enemy.transform.position = l_spawnPosition;

            m_lstEnemies.Add(l_enemy);

            if (m_lstEnemies.Count >= m_maxEnemies)
                break;
        }
    }
    public static int EnemyCount => s_instance.m_lstEnemies.Count;
    public static Enemy GetClosestEnemy_s()
    {
        return s_instance.GetClosestEnemy();
    }
    public static void DestroyEnemy_s(Enemy a_enemy)
    {
        s_instance.DestroyEnemy(a_enemy);
    }
    public static void DestroyPearl_s(Pearl a_pearl)
    {
        s_instance.DestroyPearl(a_pearl);
    }
    void DestroyEnemy(Enemy a_enemy)
    {
        m_lstEnemies.Remove(a_enemy);
        Pearl l_pearl = m_poolPearl.GetItem();
        l_pearl.transform.position = a_enemy.transform.position;

        m_poolEnemy.ReleaseItem(a_enemy);
    }
    void DestroyPearl(Pearl a_pearl)
    {
        m_poolPearl.ReleaseItem(a_pearl);
    }
    public Enemy GetClosestEnemy()
    {
        Enemy l_closestEnemy = null;
        float l_closestDist = 100f;

        foreach (Enemy l_enemy in m_lstEnemies)
        {
            float l_dist = Vector3.Distance(Gameplay.Player.Position, l_enemy.transform.position);
            if (l_dist <= l_closestDist)
            {
                l_closestEnemy = l_enemy;
                l_closestDist = l_dist;
            }
        }
        return l_closestEnemy;
    }
}
