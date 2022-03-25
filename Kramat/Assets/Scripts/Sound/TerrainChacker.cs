using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainChacker
{
    public float[] GetTextureMix(Vector3 playerPos, Terrain t)
    {
        Vector3 tPos = t.transform.position;
        TerrainData tData = t.terrainData;

        //player pos relative to terain
        int mapX = Mathf.RoundToInt((playerPos.x - tPos.x) / tData.size.x * tData.alphamapWidth);
        int mapZ = Mathf.RoundToInt((playerPos.z - tPos.z) / tData.size.z * tData.alphamapHeight);
        float[,,] splatMapData = tData.GetAlphamaps(mapX, mapZ, 1, 1);


        float[] cellMix = new float [splatMapData.GetUpperBound(2)+1];
        for(int i = 0; i < cellMix.Length; i++)
            cellMix[i] = splatMapData[0, 0, i];

        return cellMix;
    }

    public string GetLayerName(Vector3 playerPos, Terrain t)
    {
        float[] cellMix = GetTextureMix(playerPos, t);
        float strongestTexture = 0;
        int strongestTextureIndex = 0;

        for (int i = 0; i < cellMix.Length; i++)
            if (cellMix[i] > strongestTexture)
            {
                strongestTextureIndex = i;
                strongestTexture = cellMix[i];
            }

        return t.terrainData.terrainLayers[strongestTextureIndex].name;
    }


}
