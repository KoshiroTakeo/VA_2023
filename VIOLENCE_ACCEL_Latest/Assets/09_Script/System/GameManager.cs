using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public VR.Players.PlayerData SetPlayerData; // ���̃V�[���s���O�ɕK�v�ȃf�[�^��ۊǂ��鏊�A�����̓��[�h�Ŏ擾��������

   public void SceneChange(string _name)
    {
        SceneManager.LoadScene(_name);
    }
}
