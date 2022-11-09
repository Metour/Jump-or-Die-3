using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float duration;
    [SerializeField] private float magnitude;

    //Comentar estos solo si se hace de la otra forma
    //[SerializeField] private float duration;
    //[SerializeField] private float magnitude;

    void Start()
    {
        //Llamar funcion
        //Shake();

        //Llamar corutina
        //StartCoroutine(Shake());
    }

    //Otra forma
    //public IEnumerator Shake(float duration, float magnitude)
    public IEnumerator Shake()
    {
        //No retorna nada
        //yield return null;

        //Es lo mismo que null
        //yield return 0;

        //Espera por x segundos
        //yield return new WaitForSeconds(1f);

        Vector3 originalPos = transform.position;
        float elapsed = 0f;

        //El While sirve para bucles (mientras estas condiciones se cumplan haz un bucle de esto)
        while(elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.position = new Vector3(x + originalPos.x, y + originalPos.y, transform.position.z);
            elapsed += Time.deltaTime;
            yield return 0;
        }

        /*for (float i = elapsed; i < duration; i += Time.deltaTime)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.position = new Vector3(x + originalPos.x, y + originalPos.y, transform.position.z);
            yield return 0;
        }*/

        //Esto es un array, se convierte en array el [] tras el nombre
        /*GameObject[] vidas;

        foreach(GameObject vida in vidas)
        {
            vida.SetActive(false);
        }*/

        /*do
        {
            Debug.Log("Shake");
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.position = new Vector3(x + originalPos.x, y + originalPos.y, transform.position.z);
            elapsed += Time.deltaTime;
            yield return 0;

        }while(elapsed < duration);*/
    }
}
