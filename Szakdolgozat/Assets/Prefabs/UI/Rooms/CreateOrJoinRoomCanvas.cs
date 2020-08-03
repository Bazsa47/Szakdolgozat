using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateOrJoinRoomCanvas : MonoBehaviour
{
    [SerializeField]
    private CreateRoom createRoom;

    private RoomsCanvases roomsCanvases;
    public void FirstInitialize(RoomsCanvases canvases)
    {
        roomsCanvases = canvases;
        createRoom.FirstInitialize(canvases);
    }
}
