# Escenas

En cada escena hay un Game Object vacio que va a contener el script de `SceneManager`.

## Escena Menú Principal

- Canvas Scaler: Scale with Screen Size, 1920 x 1080
- Panel: Fuente de la imagen en la carpeta ubicada en `Assets/Multimedia/Images`


Botones:
- **Start simulation**: Este botón tiene asociado la funcionalidad del script `SceneController` para dirigir a la escena de *Parameters*.
- **Credits**: Este botón tiene asociado la funcionalidad del script `SceneController` para dirigir a la escena de ***Credits***.
```c#
public void LoadScene(string nameScene) { ... }
```
- **Exit**: Este botón tiene asociado la funcionalidad del script `SceneController` para salir del programa.
```c#
public void Exit() { ... }
```


## Escena de establecimiento de párametros iniciales.

- Canvas Scaler: Scale with Screen Size, 1920 x 1080
- Panel: Fuente de la imagen en la carpeta ubicada en `Assets/Multimedia/Images`, dicha imagen se ha convertido a su Texture Type como Sprite.

Los elementos agrupados dentro del Canvas para obtener los input, estan organizados en:  
```
- GameObject  
    - Hijo Text  
    - Hijo Input Field 
        - Placeholder
        - Text
```

El botón de `Start Simulation` tiene asociada la siguiente función del script `SceneController` para pasar a la escena ***Simulation***:
```C#
public void LoadScene(string nameScene) { ... }
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


## Escena Créditos

- Canvas Scaler: Scale with Screen Size, 1920 x 1080
- Panel: Fuente de la imagen en la carpeta ubicada en `Assets/Multimedia/Images`

Botones: 
- **Main Menu**: Este botón tiene asociado la funcionalidad del script `SceneController` para dirigir a la escena de *MainMenu*.
- **Define Variables**: Este botón tiene asociado la funcionalidad del script `SceneManager` para dirigir a la escena de *Parameters*.
```c#
public void LoadScene(string nameScene) { ... }
```
- **Exit**: Este botón tiene asociado la funcionalidad del script `SceneController` para salir del programa.
```c#
public void Exit() { ... }
```

Esta escena tiene un componente de *Audio Source* para reproducir una melodía de fondo mientras pasan los créditos con una animación ascendente. Además tiene un componente de *Video Player* para hacer de fondo; para configurar este último, se debe ir al Inspector y en la sección de *Video Player*, cambiar la opción de Render Mode a *Camera Near Plane* y asignarle la cámara principal.

Para hacer la animación del texto, hacemos uso de la ventana *Animation*. Seleccinamos desde la jerarquía los elementos que queremos animar y presionamos Create. El archivo de animación estara guardado en `Assets/Multimedia/Animation`. Dentro de la ventana de animación,seleccinamos Credits, pulsamos el boton de REC y movemos en el inspector la Pos Y hacia el lugar que queremos animar, tambien podemos definir cuantos segundos son los más adecuados para observar una correcta transición.