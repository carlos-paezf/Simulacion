using UnityEngine;

public class Animal : LivingEntity {

    private const int MaxViewDistance = 10;

    public  float walkSpeed;
    public  float runSpeed;
    public  float hunger;
    public  float thirst;
    public  float age;
    public  float _timeDeathAge;
    private float _drinkSpeed = 6;
    private float _eatSpeed   = 10;

    private float _timeBetweenActionChoices = 1;
    private float _timeDeathHunger          = 200;
    private float _timeDeathThirst          = 200;
    private float _criticalPercent          = 0.7f;
    private float _visionRadius             = 0.2f;

    protected virtual void Update() {
        hunger += Time.deltaTime * 1 / _timeDeathHunger;
        thirst += Time.deltaTime * 1 / _timeDeathHunger;
        age    += Time.deltaTime * 1 / _timeDeathAge;

        if (hunger >= 1) Die(CauseOfDeath.Hunger);
        else if (thirst >= 1) Die(CauseOfDeath.Thirst);
        else if (age >= 1) Die(CauseOfDeath.Age);
    }
}
