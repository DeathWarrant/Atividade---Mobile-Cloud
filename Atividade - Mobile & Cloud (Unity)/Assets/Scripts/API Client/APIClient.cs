using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class APIClient : MonoBehaviour
{
    [HideInInspector] public Modelo3D[] modelos = null;
    private const string baseUrl = "http://localhost:54853/API";

	void Start ()
    {
        StartCoroutine("GetItensAPISync");
	}

    IEnumerator GetItensAPISync()
    {
        UnityWebRequest request = UnityWebRequest.Get(baseUrl + "/Modelos3D");

        yield return request.SendWebRequest();

        if(request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
        }
        else
        {
            string response = request.downloadHandler.text;
            Debug.Log(response);

            modelos = JSonHelper.getJsonArray<Modelo3D>(response);

            foreach (Modelo3D i in modelos)
            {
                ImprimirItem(i);
            }
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
        Debug.Log("Peso: " + m.Peso);
    }
}
