[System.Serializable]
public class Modelo3D
{
    public int Modelo3DID;
    public string Nome;
    public string Historia;
    public int Altura;
    public int Peso;
    public int NumeroDePoligonos;

    // Relacionamento Item --> TipoItem
    public int TipoModelo3DID;
}