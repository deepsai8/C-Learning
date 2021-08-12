using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ProceduralGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject wallPrefab;

    [SerializeField]
    private GameObject roofPrefab;

    [SerializeField]
    private bool includeRoof = false;
    
    [SerializeField]
    private int width = 2;
    
    [SerializeField]
    private int length = 3;

    [SerializeField]
    private float cellUnitSize = 1;

    [SerializeField]
    private int numFloors = 1;

    [SerializeField]
    private Floor[] floors;
    

    private void Awake()
    {
        Generate();
        Render();
    }


    void Generate(){
        floors = new Floor[numFloors];

        int floorCount = 0;

        foreach (Floor floor in floors){
            Room[,] rooms = new Room[width, length];

            for (int i = 0; i < width; i++){
                for(int j = 0; j < length; j++){
                    rooms[i,j] = new Room(new Vector2(i * cellUnitSize, j * cellUnitSize), includeRoof ? (floorCount == floors.Length - 1): false);

                }
            }
            floors[floorCount] = new Floor(floorCount++, rooms);

        }
    }

    void Render(){
        foreach (Floor floor in floors){
            for (int i = 0; i < width; i++){
                for(int j = 0; j < length; j++){
                    Room room = floor.rooms[i,j];
                    var wall1 = Instantiate(wallPrefab, new Vector3(room.RoomPosition.x, floor.FloorNumber, room.RoomPosition.y), Quaternion.Euler(0,0,0));
                    wall1.transform.parent = transform;
                    var wall2 = Instantiate(wallPrefab, new Vector3(room.RoomPosition.x, floor.FloorNumber, room.RoomPosition.y), Quaternion.Euler(0,90,0));
                    wall2.transform.parent = transform;
                    var wall3 = Instantiate(wallPrefab, new Vector3(room.RoomPosition.x, floor.FloorNumber, room.RoomPosition.y), Quaternion.Euler(0,180,0));
                    wall3.transform.parent = transform;
                    var wall4 = Instantiate(wallPrefab, new Vector3(room.RoomPosition.x, floor.FloorNumber, room.RoomPosition.y), Quaternion.Euler(0,-90,0));
                    wall4.transform.parent = transform;


                    if(room.HasRoof){
                        var roof = Instantiate(roofPrefab, new Vector3(room.RoomPosition.x, floor.FloorNumber, room.RoomPosition.y), Quaternion.identity);
                        roof.transform.parent = transform;
                    }

                }
            }
        }



    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
