using UnityEngine;

[System.Serializable]
public class Floor{
    
    public int FloorNumber {get; private set; }
    [SerializeField]

    public Room[,] rooms;

    public Floor(int floorNum, Room[,] rooms){
        FloorNumber = floorNum;
        this.rooms = rooms;
    }
}