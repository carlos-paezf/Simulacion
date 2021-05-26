# Animales

El script de `Animal.cs`, esta diseñado para modelar el comportamiento tanto de las presas como de los depredadores. Muchos elementos son comunes para ambos, mientras que otros se deben establecer desde el editor de Unity. 

Esa clase hereda del script `LivingEntity.cs`, y de la cual hacemos uso con el método de *Die()*. 

> Nota: Ir al archivo readme [LivingEntity.md](https://github.com/carlos-paezf/Simulacion/blob/main/Segundo_Corte/P2T8_Simulacion_Ecosistema/Assets/Scripts/Readme/LivingEntity.md) para obtener la explicación del mismo.

## Parametros

### Parametros de velocidad

Estos parametros se deben personalizar para cada especie.

```C#
public float walkSpeed;
public float runSpeed;
```

### Parametros de visión

La visión es importante para identificar a que distancia esta el animal de la comida, bebida o en el caso de la presa, si el depredador entra en su rango de visión. La distancia máxima a la que pueden ver es de 10 metros. 

```C#
private const int MaxViewDistance = 10;
private float _visionRadius = 0.2f;
```

### Parametros de estados

Los animales tienen las necesidades de alimentarse y de beber, pero estas variables aumentan en relación con el paso del tiempo.

```C#
public float hunger;
public float thirst;
```

Cada vez que el animal entre en un estado de bebiendo agua o comiendo, se debe tener un tiempo de espera hasta que se satisfaga la necesidad. 

```C#
private float _drinkSpeed = 6;
private float _eatSpeed = 10;
```

Los animales si no se alimentan o no encuentran bebida dentro de una cantidad de tiempo, o por tener una determinada edad, deben morir. 

```C#
public float _timeDeathAge;
private float _timeDeathHunger = 200;
private float _timeDeathThirst = 200;
```

Antes de llegar a morir por sed o por hambre, se debe tener un porcentaje crítico para acelerar la búsqueda del alimento o del agua. 

```C#
private float _criticalPercent = 0.7f;
```

Antes de pasar de un estado a otro, hay un tiempo de espera entre las acciones, no puede comer y beber al mismo tiempo. 

```C#
private float _timeBetweenActionChoices = 1;
```

### Parametros de movimiento

### Parametros de género

## Actualización de los estados

Es común ver que el metodo *Update()* sea privado, pero en este caso se requiere que las clases que hereden de este script, puedan acceder al mismo y en dado caso, sobreescribirlo o anularlo, para ello se hace uso de **protected** y de **virtual** en su respectivo orden. 

```C#
protected virtual void Update() { ... }
```

Lo primero es actualizar el estado de hambriento, sediento y edad. En cada caso, el incremento se hara respecto al tiempo. 

```C#
hunger += Time.deltaTime * 1 / _timeDeathHunger;
thirst += Time.deltaTime * 1 / _timeDeathHunger;
age    += Time.deltaTime * 1 / _timeDeathAge;
```

Los valores que se tendran en cuenta para esas variables estan en el rango de [0,1] y cuando el valor llegue a 1 en cada parametro, el animal debe morir y se debe reportar el porque de su muerte. 

```C#
if (hunger >= 1) Die(CauseOfDeath.);
else if (thirst >= 1) Die(CauseOfDeath.);
else if (age >= 1) Die(CauseOfDeath.);
```