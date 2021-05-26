# Entorno

El ideal del script `Environment.cs`, es el de determinar funciones para espacio, ubicaciones, mapa, terreno, y demás asociadas a las anteriores. 

## Variables

Hay un diccionario que define la especie y su ubicación en el mapa. Esta variable es usada en multiples funciones.

```C#
private static Dictionary<Species, Map> _speciesMaps;
```

## Funciones

La función de registrar la muerte, tiene como objetivo remover la entidad viva del diccionario de especies en el mapa. 

```C#
public static void RegisterDeath(LivingEntity entity) {
    _speciesMaps[entity.species].Remove(entity, entity.coord);
}
```