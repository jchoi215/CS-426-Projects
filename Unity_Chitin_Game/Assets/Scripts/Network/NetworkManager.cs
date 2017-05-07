using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
public class NetworkManager : MonoBehaviour
{

    public string roomName = "adahal3";
    public string playerPrefabName = "PlayerController";
    const string VERSION = "v 0.1";
    public GameObject LOGO;

    SpawnSpot[] spawnSpots;
    // Use this for initialization
    void Start()
    {
        LOGO.SetActive(true);
        spawnSpots = GameObject.FindObjectsOfType<SpawnSpot>();
        Connect();
    }
    void Connect()
    {
        PhotonNetwork.ConnectUsingSettings(VERSION);
        Debug.Log("NetworkManager: Connected to server");
    }

    void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
    }
   
    void OnJoinedLobby()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    void OnPhotonRandomJoinFailed()
    {
        PhotonNetwork.CreateRoom(null);
    }
    void OnJoinedRoom()
    {
        SpawnMyPlayer();
    }
    
    void SpawnMyPlayer()
    {
        SpawnSpot mySpawnSpot = spawnSpots[Random.Range(0, spawnSpots.Length)];
        
        GameObject myPlayerGO = PhotonNetwork.Instantiate(playerPrefabName, mySpawnSpot.transform.position, mySpawnSpot.transform.rotation, 0);

        myPlayerGO.transform.FindChild("PlayerCamera").gameObject.SetActive(true);
        myPlayerGO.transform.FindChild("HUD").gameObject.SetActive(true);
        // enable scripts
        myPlayerGO.GetComponent<RigidbodyFirstPersonController>().enabled = true;
        myPlayerGO.GetComponent<PlayerHealth>().enabled = true;
        myPlayerGO.GetComponent<PlayerStamina>().enabled = true;
        myPlayerGO.GetComponent<PlayerHunger>().enabled = true;
        myPlayerGO.GetComponent<PlayerConsume>().enabled = true;
        myPlayerGO.GetComponent<PlayerHealth>().enabled = true;
        myPlayerGO.GetComponent<PlayerScore>().enabled = true;
        myPlayerGO.GetComponent<DamageCollisions>().enabled = true;
        LOGO.SetActive(false);
    }
}