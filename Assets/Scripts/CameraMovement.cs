using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private GameObject activeSide;
    private int roomSide; 
    public int side
    {
        get { return roomSide; }
        set
        {
            roomSide = value;
            if (side < 0)
            {
                side = RoomSpace.Length - 1;
            }
            else if (side > RoomSpace.Length - 1)
            {
                roomSide = 0;
            }

            activeRoom(); //sets active room
        }
    }


    public GameObject[] RoomSpace;




    // Start is called before the first frame update
    void Start()
    {
        if (RoomSpace.Length == 0)
        {
            return;
        }

        activeSide = RoomSpace[side];
        activeRoom();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void moveToNextSide()
    {
        side++;
    }

    public void moveBack()
    {
        side--;
    }

    private void activeRoom()
    {
        activeSide.SetActive(false);
        activeSide = RoomSpace[side];
        activeSide.SetActive(true);
    }
}
