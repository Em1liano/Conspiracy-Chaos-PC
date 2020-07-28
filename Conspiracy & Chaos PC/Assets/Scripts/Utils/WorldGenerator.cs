using Assets.Scripts.Utils.WorldGenerator;
using Assets.Scripts.Utils.WorldGenerator.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    private Stage[] avaiableStages;
    private StagesLoader stagesLoader;
    private Stage currentStage;

    void Start()
    {
        avaiableStages = Resources.LoadAll<Stage>("Stages");
        stagesLoader = new StagesLoader(avaiableStages);

        //Spawn first stage
        currentStage = Instantiate(stagesLoader.GetNext(), new Vector3(), new Quaternion());
        currentStage.onLoadNextStagePointEnter += CurrentStage_onLoadNextStagePointEnter;
    }

    private void FixedUpdate()
    {
        
    }

    private void CurrentStage_onLoadNextStagePointEnter(object sender, System.EventArgs e)
    {
        var currentStageHeight = currentStage.transform.localScale.y;
        var currentStageWidth = currentStage.transform.localScale.x;

        var nextStage = stagesLoader.GetNext();
        var nextStageWidth = nextStage.transform.localScale.x;
        var nextStageHeight = nextStage.transform.localScale.y;

        var nextStageSpawnPosition = currentStage.Exit.transform.position += new Vector3(nextStageWidth/2, -nextStageHeight/2);

        currentStage.onLoadNextStagePointEnter -= CurrentStage_onLoadNextStagePointEnter;
        currentStage = Instantiate(nextStage, nextStageSpawnPosition, new Quaternion());
        currentStage.onLoadNextStagePointEnter += CurrentStage_onLoadNextStagePointEnter;
    }

     
}
