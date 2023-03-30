using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class AudioSyncSpawn : AudioSyncer
{
	public UnityEvent onBeatEvent;
	public GameObject[] spawnObjects;
    public Transform[] spawnPoints;

	public override void OnBeat()
	{
		base.OnBeat();
        // hint: do this if the game isn't over
        onBeatEvent.Invoke();
    }
    public void SpawnObjects()
	{
        GameObject spawnedObject = Instantiate(spawnObjects[Random.Range(0, spawnObjects.Length)], spawnPoints[Random.Range(0, spawnPoints.Length)]);
        spawnedObject.GetComponent<Rigidbody>().velocity = Vector3.forward * -5;
    }
}
