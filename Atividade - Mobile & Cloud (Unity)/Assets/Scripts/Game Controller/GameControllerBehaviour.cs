using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerBehaviour : MonoBehaviour
{
    public Text modelDescription = null;

    private bool checkIfAdded = false;
    private int itemCounter = 0;
    private List<GameObject> gameObjectsOnDisplay = new List<GameObject>();
    private APIClient apiClient = null;

    void Start()
    {
        apiClient = gameObject.GetComponent<APIClient>();
        itemCounter = 0;
    }

    void Update()
    {
        SetText();
        LookForGameObjects();
    }

    private void SetText()
    {
        modelDescription.text = "Nome: " + apiClient.modelos[itemCounter].Nome
                              + "\nHistoria: " + apiClient.modelos[itemCounter].Historia
                              + "\nAltura: " + apiClient.modelos[itemCounter].Altura
                              + "\nPeso: " + apiClient.modelos[itemCounter].Peso
                              + "\nNumero de Poligonos: " + apiClient.modelos[itemCounter].NumeroDePoligonos
                              + "\nTipo de modelo: " + apiClient.modelos[itemCounter].TipoModelo3DID;
    }

    private void LookForGameObjects()
    {
        if (!checkIfAdded)
        {
            if (apiClient.modelos.Length != 0)
            {
                for (int i = 0; i < apiClient.modelos.Length; i++)
                {
                    gameObjectsOnDisplay.Add(GameObject.Find(apiClient.modelos[i].Nome));
                    gameObjectsOnDisplay[i].SetActive(false);
                }

                Debug.Log("To saindo errado");
                checkIfAdded = true;
                gameObjectsOnDisplay[itemCounter].SetActive(true);
            }
        }
    }

    public void NextModel()
    {
        if (itemCounter != apiClient.modelos.Length -1)
        {
            gameObjectsOnDisplay[itemCounter].transform.eulerAngles = new Vector3(0, 0, 0);
            gameObjectsOnDisplay[itemCounter].SetActive(false);
            itemCounter++;
            gameObjectsOnDisplay[itemCounter].SetActive(true);
        }
        else
        {
            gameObjectsOnDisplay[itemCounter].transform.eulerAngles = new Vector3(0, 0, 0);
            gameObjectsOnDisplay[itemCounter].SetActive(false);
            itemCounter = 0;
            gameObjectsOnDisplay[itemCounter].SetActive(true);
        }
    }

    public void PrevModel()
    {
        if (itemCounter != 0)
        {
            gameObjectsOnDisplay[itemCounter].transform.eulerAngles = new Vector3(0, 0, 0);
            gameObjectsOnDisplay[itemCounter].SetActive(false);
            itemCounter--;
            gameObjectsOnDisplay[itemCounter].SetActive(true);
        }
        else
        {
            gameObjectsOnDisplay[itemCounter].transform.eulerAngles = new Vector3(0, 0, 0);
            gameObjectsOnDisplay[itemCounter].SetActive(false);
            itemCounter = apiClient.modelos.Length - 1;
            gameObjectsOnDisplay[itemCounter].SetActive(true);
        }
    }
}
