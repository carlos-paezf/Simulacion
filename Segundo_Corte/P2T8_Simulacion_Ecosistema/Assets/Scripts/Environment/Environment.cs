using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour {

    private static Dictionary<Species, Map> _speciesMaps;
    
    public static void RegisterDeath(LivingEntity entity) {
        _speciesMaps[entity.species].Remove(entity, entity.coord);
    }
}
