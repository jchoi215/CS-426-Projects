using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkCharacter : Photon.MonoBehaviour {

    Vector3 realPosition = Vector3.zero;
    Quaternion realRotation = Quaternion.identity;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
	    if(photonView.isMine)
        {

        }
        else
        {
          //  transform.position = Vector3.Lerp(transform.position, realPosition, 0.1f);
           // transform.rotation = Quaternion.Lerp(transform.rotation, realRotation, 0.1f);
        }
	}

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
     if (stream.isWriting)
        { // Local
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
        }
        else // remote
        {
            transform.position = (Vector3)stream.ReceiveNext();
            transform.rotation = (Quaternion)stream.ReceiveNext();
        }
    }
}
