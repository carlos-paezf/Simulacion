using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

    public readonly List<LivingEntity>[,] map;

    private readonly int _regionSize;
    public int numEntities;
    
    public void Remove(LivingEntity entity, Coord coord){
        var regionX = coord.x / _regionSize;
        var regionY = coord.y / _regionSize;

        int index = entity.mapIndex;
        var lastElementIndex = map[regionX, regionY].Count - 1;

        if (index != lastElementIndex) {
            map[regionX, regionY][index] = map[regionX, regionY][lastElementIndex];
            map[regionX, regionY][index].mapIndex = entity.mapIndex;
        }

        map[regionX, regionY].RemoveAt(lastElementIndex);
        numEntities--;
    }
}
