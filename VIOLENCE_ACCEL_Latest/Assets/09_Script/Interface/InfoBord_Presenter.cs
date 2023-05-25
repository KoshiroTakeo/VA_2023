using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInfoBord
{
    public VR.Players.PlayerParameter ThrowData { get; set; }
}



public class InfoBord_Presenter : MonoBehaviour
{
    // View ‚Æ model
    [SerializeField] private InfoBord view;
    [SerializeField] private VR.Players.MasterPlayer model; //ˆË‘¶


    // ˆË‘¶‹t“]‚Ì‚½‚ß
    private IInfoBord Iinfo;

    public bool Set()
    {
        // model‚Ì•Ï‰»‚ðView‚É“`‚¦‚é
        Iinfo = GetComponent<IInfoBord>();

        model = GameObject.FindWithTag("Player").GetComponent<VR.Players.MasterPlayer>();
        Iinfo.ThrowData = model.ThrowData();

        return true;
    }

    private void Start()
    {
        
    }
}


