# Entidad Viviente

En el script `LivingEntity.cs` se define la posición del animal y su estado de si esta muerto o no. 

## Variables

Es importante almacenar la posición y especie del animal dentro del mapa para posteriormente acceder a ellas, y de ser necesario, elminiarlas. Para ello, se crean 2 variables del tipo Coord y Species:

```C#
public Coord coord;
public Species species;
```

Hay una variable que sera oculta en el inspector, pero la cual sera usada intensamente en el script de `Map.cs`, cumple con el objetivo de reconocer el indice que ocupa dentro de los animales que esten en el mapa.

```C#
[HideInInspector]
public int mapIndex;
```

## Muerte

Es importante reportar el estado de muerte, para ello, lo primero es crear una una variable para actualizar dicho estado en las clases que se hereden:

```C#
protected bool dead;
```

Lo segundo es que en caso de que muera el animal, se cambie el estado a verdadero y se destruya el objeto, además de registrar la muerte al entorno por medio de un método al que pueden acceder las clases que hereden la clase LivingEntity.

```C#
protected virtual void Die(CauseOfDeath cause){
    if (dead) return;
    dead = true;
    Environment.RegisterDeath(this);
    Destroy(gameObject);
}
```

Las causas de muerte que podemos encontrar son: por hambre, por sed, por edad, o por ser comido. Para ello esta un enumerador para listar dichas causas.

```C#
public enum CauseOfDeath {
    Hunger, Thirst, Age, Eaten
}
```