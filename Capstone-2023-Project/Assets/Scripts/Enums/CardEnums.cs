using System.Collections;
using System.Collections.Generic;

public class CardEnums
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
