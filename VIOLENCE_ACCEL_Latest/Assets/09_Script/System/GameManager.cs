using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public VR.Players.PlayerData SetPlayerData; // 次のシーン行く前に必要なデータを保管する所、或いはロードで取得したもの

   public void SceneChange(string _name)
    {
        SceneManager.LoadScene(_name);
    }
}
