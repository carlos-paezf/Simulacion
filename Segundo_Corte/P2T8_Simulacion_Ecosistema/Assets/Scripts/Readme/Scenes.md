# Escenas


## Escena Menú Principal

- Canvas Scaler: Scale with Screen Size, 1920 x 1080
- Panel: Fuente de la imagen en la carpeta ubicada en `Assets/Images`

Botones:
- **Start simulation**: Este botón tiene asociado la funcionalidad del script SceneManager para dirigir a la escena de *Parameters*.
- **Credits**: Este botón tiene asociado la funcionalidad del script SceneManager para dirigir a la escena de ***Credits***.
```c#
public void SceneChange(string nameScene) { ... }
```

- Exit: Este botón tiene asociado la funcionalidad del script SceneManager para salir del programa.
```c#
public void Exit() { ... }
```


## Escena de establecimiento de párametros iniciales.

- Canvas Scaler: Scale with Screen Size, 1920 x 1080
- Panel: Fuente de la imagen en la carpeta ubicada en `Assets/Images`, dicha imagen se ha convertido a su Texture Type como Sprite.

Los elementos agrupados dentro del Canvas para obtener los input, estan organizados en:  
```
- GameObject  
    - Hijo Text  
    - Hijo Input Field 
        - Placeholder
        - Text
```

El botón de `Start Simulation` tiene asociada la siguiente función del script `SceneManager` para pasar a la escena ***Simulation***:
```C#
public void SceneChange(string nameScene) { ... }
```

Para poder capturar los elementos que se ingresan dentro de los input field, se creo un script llamado `InputText.cs`, el cual esta asignado a un Game Object empty. En el script se asigna el valor capturado a una variable privada llamada `_input`.

```C#
int _inputFoo;
string _patternFoo = @"^[valores recibidos]\d{n min recibidos -1}";
public GameObject popupFoo;

void Start(){
    this.popupFoo.SetActive(false);
}

public void InputFoo(string value) {
    bool isNumber = Regex.IsMatch(value, _patternFoo);
    if (!isNumber) {
        this.popupFoo.SetActive(true);
    } else {
        this._inputFoo = int.Parse(value);
        this.popupFoo.SetActive(false);
    }
}
```

En lo anterior se puede observar que cada vez que el valor sera incorrecto, se lanza un popup para anunciar un error, y luego se retira, si el valor es correcto.

Dentro de los Input Field,en el evento *On End Edit*, llevamos el Game Object (InputText) el cual tiene asignado el script anterior, y seleccionamos el método de arriba. 

## Escena Creditos