# Player Controller

Este script cumple la función de controlar el player en su movimiento y rotación. Es importante resaltar que cualquier acción de movimiento dentro de la simulación, no afecta a la misma ya que el player solo cumple el papel de observador. 


## Movimiento y Rotación del Player

Lo primero es crear dentro de la jerarquia, un Game Object, al cual le vamos a asignar la cámara principal. Podemos ubicar de manera personalizada la cámara. Luego, seleccionado el Game Object, le añadimos un componente llamado *Character Controller* para tener un mejor movimiento del personaje y debemos llamarlo dentro del script `PlayerController.cs`, requriendo un componente de este tipo antes de crear la clase.

```C#
[RequireComponent(typeof(CharacterController))]
```

Luego si podemos crear una variable para poder hacer uso de dicho componente, y luego debemos llamarlo al despertar la aplicación.

```C#
private CharacterController _characterController;

private void Awake() {
    _characterController = GetComponent<CharacterController>();
}
```

Tambien podemos encontrar como parametros una escala de gravedad para hacer un poco más realista el movimiento. 
```C#
public float gravityScale = -40f;
```

Existe una variable para poder refenciar la cámara, otras para el movimiento del personaje y rotación de la cámara, junto al angulo vertical de la misma. La sensibilidad de rotación permite que la cámara gire de una manera más cómoda. Por último, encontramos 2 variables "especiales":

```C#
public float walkSpeed = 5f;
public float runSpeed = 10f;
```

Estas variables interprentan la velocidad de movimiento del observador, según su pulsación de teclas. Para ello controlamos su funcionalidad en la función *Move()*

```C#
private void Move() {
    ... ;
    if (Input.GetButton("Sprint")) {
        moveInput = transform.TransformDirection(moveInput) * runSpeed;
    }
    else {
        moveInput = transform.TransformDirection(moveInput) * walkSpeed;
    }
    ... ;
}
```

El boton `"Sprint"`, se debe configurar de la siguiente manera desde el editor de Unity:

- Ingresar al menú de ***Edit***
- Ir a ***Project Settings***
- En el menú lateral ingresamos a ***Input Manager***
- En la opción de ***Axes***, en el input de ***Size*** aumentamos en 1 la cantidad presente.
- Luego de lo anterior, aparece una dentro de la lista de la parte inferior un nuevo elemento, el cual debemos seleccionar y desplegar.
- Cambiamos el nombre a `Sprint` y dentro de input de ***Positive Button*** ingresamos `left shift`.

Resumiendo la función de *Move()*, se puede decir que es la manera en que el player se puede mover y alterar su velocidad mediante las teclas de W.A.S.D y Shift Izquierdo. Mientras que la función de *Look()* permite que la cámara siga el movimento del mouse. 