using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] private GameObject template;
    [SerializeField] private List<GameObject> objectList;

    public const string NUM_SPAWNS_KEY = "NUM_SPAWNS_KEY";
    // Start is called before the first frame update
    void Start()
    {
        this.template.SetActive(false);

        EventBroadcaster.Instance.AddObserver(EventNames.S23_Events.ON_SPAWN_BUTTON_CLICKED, this.OnSpawnEvent);
    }

    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.S23_Events.ON_SPAWN_BUTTON_CLICKED);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnSpawnEvent(Parameters parameters)
    {
        int numSpawns = parameters.GetIntExtra(NUM_SPAWNS_KEY, 1);

        for(int i = 0; i < numSpawns; i++) {
            GameObject instance = GameObject.Instantiate(this.template, this.transform);
            instance.SetActive(true);
            this.objectList.Add(instance);
        }
        
    }
}