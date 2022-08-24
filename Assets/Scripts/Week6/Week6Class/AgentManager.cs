using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentManager : MonoBehaviour
{
    public GameObject agentPrefab;
    public List<GameObject> agents;
    public List<int> agentsIndexes;
    public List<Vector3> path;

    public Queue<GameObject> pool;

    // Start is called before the first frame update
    void Start()
    {
        pool = new Queue<GameObject>();
        StartCoroutine(PathAgents());
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            SpawnAgent();
        }
    }

    void SpawnAgent()
    {
        //variable = condition ? true : false
        GameObject agent = pool.Count > 0 ? pool.Dequeue() : GameObject.Instantiate(agentPrefab);
        agent.transform.position = path[0];
        agents.Add(agent);
        agentsIndexes.Add(1);
        agent.SetActive(true);
    }

    void DespawnAgent(int agentIndex)
    {
        GameObject agent = agents[agentIndex];
        if(pool.Count < 10) 
        {
            pool.Enqueue(agent);
            agents.Remove(agent);
            agentsIndexes.Remove(agentsIndexes[agentIndex]);

            agent.transform.position = new Vector3(100, 100, 100);
            agent.SetActive(false);
        }
        else
        {
            Destroy(agent);
        }
    }

    IEnumerator PathAgents()
    {
        while (true)
        {
            Debug.Log(pool.Count);
            for (int i = 0; i < agents.Count; i++)
            {
                Vector3 agentDirection = (path[agentsIndexes[i]] - agents[i].transform.position).normalized;
                agents[i].transform.Translate(agentDirection * 20 * Time.smoothDeltaTime);
                if (Vector3.Distance(agents[i].transform.position, path[agentsIndexes[i]]) < 1)
                {
                    agentsIndexes[i]++;
                    if (agentsIndexes[i] > path.Count - 1)
                    {
                        DespawnAgent(i);
                    }
                }
                yield return null;
            }
            yield return null;
        }
    }

    private void OnDrawGizmos()
    {
        for(int i = 0; i < path.Count; i++)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(path[i], 1.0f);
            if(i < path.Count - 1)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawLine(path[i], path[i + 1]);
            }
        }
    }
}