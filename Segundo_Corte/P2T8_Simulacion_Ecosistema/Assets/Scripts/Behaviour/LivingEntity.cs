using UnityEngine;

public class LivingEntity : MonoBehaviour {

    public Coord coord;
    public Species species;
    
    [HideInInspector]
    public int mapIndex;

    protected bool dead;

    public enum CauseOfDeath {
        Hunger, Thirst, Age, Eaten
    }

    protected virtual void Die(CauseOfDeath cause) {
        if (dead) return;
        dead = true;
        Environment.RegisterDeath(this);
        Destroy(gameObject);
    }

}
