using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerBehaviour : MonoBehaviour
{
    public Text modelDescription = null;
    private APIClient apiClient = null;

    void Start()
    {
        apiClient = gameObject.GetComponent<APIClient>();
    }

    void Update()
    {
        SetText();
    }

    private void SetText()
    {
        modelDescription.text = "Nome: " + apiClient.modelos[0].Nome
                              + "\nHistoria: " + apiClient.modelos[0].Historia
                              + "\nAltura: " + apiClient.modelos[0].Altura
                              + "\nPeso: " + apiClient.modelos[0].Peso
                              + "\nNumero de Poligonos: " + apiClient.modelos[0].NumeroDePoligonos
                              + "\nTipo de modelo: " + apiClient.modelos[0].TipoModelo3DID;
    }
}
