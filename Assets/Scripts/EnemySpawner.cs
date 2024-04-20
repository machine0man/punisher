using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    static EnemySpawner s_instance;

    [SerializeField] float m_spawnIntervalSec = 10f;
    [SerializeField] int m_numberOfEnemies = 10;
    [SerializeField] float m_spawnInnerRadius = 10f;
    [SerializeField] float m_spawnOuterRadius = 15f;
    [SerializeField] Enemy m_prefEnemy;
    [SerializeField] Pearl m_prefPearl;
    [SerializeField] List<Enemy> m_lstEnemies;

    float m_curTime = 0f;

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

            Enemy l_enemy = Instantiate(m_prefEnemy, l_spawnPosition, Quaternion.identity);

            m_lstEnemies.Add(l_enemy);
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
    void DestroyEnemy(Enemy a_enemy)
    {
        m_lstEnemies.Remove(a_enemy);
		Pearl l_pearl =Instantiate(m_prefPearl);
        l_pearl.transform.position = a_enemy.transform.position;
        Destroy(a_enemy.gameObject);
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
