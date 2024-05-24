using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIControls : MonoBehaviour
{

    [SerializeField] private Text spawnText;
    [SerializeField] public InputField numberInput;
    private int counter = 1;
    public int NUM_SPAWNS = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        NUM_SPAWNS = int.Parse(numberInput.text);
    }

    public void OnSpawbBallsClicked()
    {
        Parameters Param = new Parameters();
        Param.PutExtra(Spawner.NUM_SPAWNS_KEY, NUM_SPAWNS);
        EventBroadcaster.Instance.PostEvent(EventNames.S23_Events.ON_SPAWN_BUTTON_CLICKED, Param);

    }

    public void onSpawnCubesButtonClicked()
    {
        Parameters Param = new Parameters();
        Param.PutExtra(CubeSpawner.CUBE_SPAWNS_KEY, NUM_SPAWNS);
        EventBroadcaster.Instance.PostEvent(EventNames.S23_Events.ON_SPAWN_CUBE_BUTTON_CLICKED, Param);
    }
}
