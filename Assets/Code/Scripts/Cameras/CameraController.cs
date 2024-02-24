using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Para obtener la posici�n objetivo de la c�mara
    public Transform target;
    //Variables para posici�n m�nima y m�xima en vertical de la c�mara
    public float minHeight, maxHeight;

    //Referencias a las posiciones de los fondos
    public Transform farBackground, middleBackground;
    ////Variable donde guardar la �ltima posici�n en X que tuvo el jugador
    //private float _lastXPos;
    //Referencia a la �ltima posici�n del jugador en X e Y
    private Vector2 _lastPos;

    // Start is called before the first frame update
    void Start()
    {
        //Al empezar el juego la �ltima posici�n del jugador ser� la actual
        //_lastXPos = transform.position.x;
        _lastPos = transform.position;
    }

    // LateUpdate se llama tambi�n una vez por frame, pero despu�s de todos los Update del juego
    //Con lo cu�l evitamos problemas de tirones de la c�mara
    void LateUpdate()
    {
        ////La c�mara sigue al jugador sin variar su posici�n en Z
        //transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
        ////Creamos una restricci�n entre un m�nimo y un m�ximo para el movimiento de la c�mara en Y
        //float _clampedY = Mathf.Clamp(transform.position.y, minHeight, maxHeight);
        ////Actualizamos el movimiento de la c�mara usando las restricciones
        //transform.position = new Vector3(transform.position.x, _clampedY, transform.position.z);

        //Esta l�nea equivale a todas las de arriba
        transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, minHeight, maxHeight), transform.position.z);

        //Variable que me permite conocer cuanto hay que moverse en X
        //float _amountToMoveX = transform.position.x - _lastXPos;
        //Referencia que me permite conocer cuanto hay que moverse en X e Y
        Vector2 _amountToMove = new Vector2(transform.position.x - _lastPos.x, transform.position.y - _lastPos.y);

        //Como el fondo del cielo se mueve a la misma velocidad que el jugador, le decimos que se mueva lo mismo que este
        //farBackground.position = farBackground.position + new Vector3(_amountToMoveX, 0f, 0f);
        farBackground.position = farBackground.position + new Vector3(_amountToMove.x, _amountToMove.y, 0f);
        //El fondo de las nubes se va a mover sin embargo a la mita de velocidad que lleve el jugador, luego se mover� la mitad
        //middleBackground.position += new Vector3(_amountToMoveX * .5f, 0f, 0f);
        middleBackground.position += new Vector3(_amountToMove.x, _amountToMove.y, 0f) * .5f;

        //Actualizamos la posici�n del jugador
        //_lastXPos = transform.position.x;
        _lastPos = transform.position;
    }
}
