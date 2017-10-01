using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupcakesFactory : MonoBehaviour {


    [SerializeField]
    public GameObject cupcakePrefab;
    public List<GameObject> Cupcakes;

    public static CupcakesFactory Instance
    {
        get;
        private set;
    }

    private void Awake()
    {
        Debug.Assert(CupcakesFactory.Instance == null); //verifier que le singleton n'as pas déja été enregistré
        CupcakesFactory.Instance = this;
    }

    public void AddToList(GameObject cupcake)
    {
        Cupcakes.Add(cupcake);
    }

    public CupcakesFactory GetCupcake()
    {
        int x = Random.Range(-4, 4);
        int y = Random.Range(-4, 4);
        Vector2 position = new Vector2(x, y);

        if (Cupcakes.Count == 0)
            Instantiate(cupcakePrefab, position, Quaternion.identity);

        else
        {
            GameObject cupcake = Cupcakes[0];
            Cupcakes.RemoveAt(0);
            cupcake.transform.position = position;
            cupcake.SetActive(true);
        }

        return this;
    }
}
