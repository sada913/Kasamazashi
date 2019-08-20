using UnityEngine;
using System.Collections;


public class PhotonConnect : MonoBehaviour
{
    [SerializeField]
    GameObject GetGyro;
    void Start()
    {
        // Photon に接続する(引数でゲームのバージョンを指定できる)
        PhotonNetwork.ConnectUsingSettings(null);
        //今回オートでロビーに Join する
    }
    // ロビーに入ると呼ばれる
    void OnJoinedLobby()
    {
        Debug.Log("ロビーに入りました。");
        // ランダムなルームに入室する
        PhotonNetwork.JoinRandomRoom();
    }
    // ルームに入室すると呼ばれる
    void OnJoinedRoom()
    {
        Debug.Log("ルームへ入室しました。");
        var player = PhotonNetwork.Instantiate(GetGyro.name, Vector3.zero, Quaternion.Euler(0, 0, 0), 0);
#if !UNITY_iOS
        player.SetActive(false);
#endif
    }
    // ルームの入室に失敗すると呼ばれる
    void OnPhotonRandomJoinFailed()
    {
        Debug.Log("ルームの入室に失敗しました。");
        PhotonNetwork.CreateRoom("aa");
    }
}