using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotComponent : MonoBehaviour
{
    public LaneComponent lane;
    public SlotComponent opposingSlot;
    public MinionComponent current_minion;


    // Start is called before the first frame update
    void Start()
    {
        
    }
}
