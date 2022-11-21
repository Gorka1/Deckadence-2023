using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestEnums : MonoBehaviour
{
    public enum SignalOrigin {
        Player,
        SceneObj,
        Enemy,
        Quest
    }

    public enum TargetType {
        Tags,
        Layer,
        Name,
        Component
    }
}
