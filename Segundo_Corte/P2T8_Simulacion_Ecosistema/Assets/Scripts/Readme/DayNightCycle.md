# Ciclo de Día - Noche

Es importante que dentro de la escena donde se va a hacer uso de esta funcionalidad, este presente un componente de ***Directional Light*** y que la ***Main Camera*** este configurada en la opcion de **Clear Flags** como *Skybox*. 

Dentro del script de `DayNightCycle.cs`, tenemos una variable para definir a que velocidad va a ocurrir nuestro cambio de dia a noche o viceversa.
```C#
public int rotationScale = 10;
```

Dentro del método *Update()*, simplemente se le dice que el objeto va a rotar solo en el eje X, con la escala designada a un tiempo parejo con los frames. 

```C#
private void Update() {
    transform.Rotate(rotationScale * Time.deltaTime, 0, 0);
}
```