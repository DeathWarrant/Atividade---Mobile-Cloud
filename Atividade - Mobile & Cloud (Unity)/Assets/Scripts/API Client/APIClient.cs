using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class APIClient : MonoBehaviour
{
    [HideInInspector] public Modelo3D[] modelos = null;
    private const string baseUrl = "http://localhost:54426/API";

    void Start()
    {
        StartCoroutine("GetModelosAPISync");
    }

    IEnumerator GetModelosAPISync()
    {
        UnityWebRequest request = UnityWebRequest.Get(baseUrl + "/Modelos3D");

        yield return request.Send();

        /*if(request.isNetworkError || request.isHttpError)     //TRECHO DESATIVADO DEVIDO À ERROS DA UNITY 5.6.4f1
        {
            Debug.Log(request.error);
        }*/

        string response = request.downloadHandler.text;
        Debug.Log(response);

        modelos = JSonHelper.getJsonArray<Modelo3D>(response);

        foreach (Modelo3D m in modelos)
        {
            ImprimirItem(m);
        }
    }
    private void ImprimirItem(Modelo3D m)
    {
        Debug.Log("=========== Dados do Objeto ===========");
        Debug.Log("ID: " + m.Modelo3DID);
        Debug.Log("Nome: " + m.Nome);
        Debug.Log("História: " + m.Historia);
        Debug.Log("Altura: " + m.Altura);
        Debug.Log("Peso: " + m.Peso);
        Debug.Log("Numero de Poligonos: " + m.NumeroDePoligonos);
        Debug.Log("Tipo de Modelo: " + m.TipoModelo3DID);
    }
}
