# Controlador de Escenas y Pausa de la Simuación

El script `SceneController`, permite hacer cambios entre escenas y salir de la aplicación. El script `PauseController`, permite hacer pausa dentro de la simulación y confirmar si desea salir de la misma. Es importante recordar que para hacer uso de estos scripts, se deben añadir a algún elemento de nuestra jerarquia dentro de las escena que se van a emplear, para luego asignar las funcionalidades dentro de los eventos de OnClick() de cada botón. En caso de necesitar un parametro, estos se pueden asignar dentro de la misma ventana de eventos de OnClick().


## Cambiar Escena y Salir

Para esta funcionalidad, se creo una función que recibe por parametro el nombre de la escena a la que se desea pasar. Por medio de SceneManager, se puede cargar la escene elegida.

```C#
public void LoadScene(string nameScene) {
    SceneManager.LoadScene(nameScene);
}
```

La función de Exit cierra por completo la simulación. Es importante aclarar que dicha función se ve en acción cuando la aplicación este un producto ya construido, porque mientras se esta en desarrollo, no genera ningún cambio.

```C#
public void Exit() {
    Application.Quit();
}
```

## Pausa

La opción de Pausa solo esta disponible dentro de la escena llamada *Simulation*. Para acceder al menú que hay dentro de ella, se debe presionar un botón y de esa manera desplegar un panel con opciones. En uno de esos elementos, esta presente la posibilidad de salir de la aplicación, porque que al dar en dicha opción, tambien debe desplegar otro panel a modo de popup para confirmar si desea salir. 

Traduciendo lo anterior a código, tendriamos 3 variables: 2 para paneles y 1 para estado del juego:
```C#
public GameObject pausePanel, exitPanel;
private bool _pause;
```

Los 2 paneles debe iniciar ocultos:
```C#
void Start() {
    pausePanel.SetActive(false);
    exitPanel.SetActive(false);
}
```

Cuando entremos al estado de pausa, se lanza el menú y el tiempo de la simulación no se detiene ya que el observador no afecta la simulación.
```C#
public void Pause() {
    _pause = true;
    pausePanel.SetActive(true);
}
```

Cuando retornamos a la simulación, los estados anteriores pasan a ser contrarios.
```C#
public void Resume() {
    pausePanel.SetActive(false);
    _pause = false;
}
```

Para alternar entre esos 2 estados, hay dos opcionee: la primera es que pulse el botón de de ***ESC*** dentro de la simulación o dentro del menú de pausa, y la segunda opción es estando dentro del menú de pausa pulsar la opción de Resume. Para la primera opción se debe acceder a la función de Update para acceder al cambio:
```C#
void Update() {
    if (Input.GetKeyDown(KeyCode.Escape)) SwitchPause();
}
```

Cuando el estado de la variable *pause* sea true, significa que tenemos la aplicación pausada, por lo que prodriamos retomar la simulación. En caso contrario, es decir que estamos en plena simulación, podemos pausar.
```C#
private void SwitchPause() {
    if (_pause) Resume();
    else Pause();
}
```

Para la segunda opción simplemente podemos añadir la función de *Resume()* al botón que representa dicha opción dentro del menú de pausa.


Para el panel que debe aparecer para confimar nuestra salida, se tiene una función que se debe asignar al botón que brinda esta opción dentro del menú de pausa.
```C#
public void ExitSimulation() {
    exitPanel.SetActive(true);
}
```

Dicho panel cuenta con un boton de YES y uno de NO. En caso de seleccionar el primero, cerramos la aplicación, por lo que se volveria a hacer uso de la función *Exit()* explicada anteriormente. En caso de seleccionar NO, entonces desactivamos el panel:
```C#
public void NoExitSimulation() {
    exitPanel.SetActive(false);
}
```