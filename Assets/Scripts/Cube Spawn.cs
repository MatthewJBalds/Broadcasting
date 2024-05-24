using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject template;
    [SerializeField] private List<GameObject> cubeList;

    public const string CUBE_SPAWNS_KEY = "CUBE_SPAWNS_KEY";
    // Start is called before the first frame update
    void Start()
    {
        this.template.SetActive(false);

        EventBroadcaster.Instance.AddObserver(EventNames.S23_Events.ON_SPAWN_CUBE_BUTTON_CLICKED, this.OnSpawnEvent);
    }

    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.S23_Events.ON_SPAWN_CUBE_BUTTON_CLICKED);
    }
    // Update is called once per frame
    void Update()
    {

    }


    private void OnSpawnEvent(Parameters parameters)
    {
        int cubeSpawns = parameters.GetIntExtra(CUBE_SPAWNS_KEY, 1);

        for (int i = 0; i < cubeSpawns; i++)
        {
            GameObject instance = GameObject.Instantiate(this.template, this.transform);
            instance.SetActive(true);
            this.cubeList.Add(instance);
        }

    }
}
