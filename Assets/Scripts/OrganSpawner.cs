using UnityEngine;
using System.Collections;

public class OrganSpawner : MonoBehaviour
{
    [System.Serializable]
    public class SpawnEntry
    {
        public OrganType type;
        public GameObject organPrefab;
    }

    public SpawnEntry[] spawnList;
    public Transform spawnPoint;
    public float respawnDelay = 0.5f;

    GameObject current;

    void Start()
    {
        SpawnAllOnce();
    }

    //  on garde toujours 1 organe de chaque type dispo
    void SpawnAllOnce()
    {
        foreach (var e in spawnList)
            SpawnIfMissing(e);
    }

    void SpawnIfMissing(SpawnEntry e)
    {
        // Instancier un organ neuf prêt à être pris 
        var go = Instantiate(e.organPrefab, spawnPoint.position, spawnPoint.rotation, transform);
        var organ = go.GetComponent<Organ>();
        if (organ != null)
        {
            organ.isOld = false;
            organ.SetTransportState(true);
        }
    }

    public void OnTaken(OrganType type)
    {
        StartCoroutine(CoRespawn(type));
    }

    IEnumerator CoRespawn(OrganType type)
    {
        yield return new WaitForSeconds(respawnDelay);
        var entry = System.Array.Find(spawnList, s => s.type == type);
        if (entry != null) SpawnIfMissing(entry);
    }
}
