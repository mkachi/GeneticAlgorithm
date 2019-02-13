using UnityEngine;
using System.Collections.Generic;
using System.Text;

public class Gene
{
    private List<float> _datas = null;
    public float Rank { get; set; }

    public Gene(params float[] datas)
    {
        _datas = new List<float>();
        _datas.AddRange(datas);
    }
    public Gene(Gene other)
    {
        _datas = other._datas;
        Rank = other.Rank;
    }

    public void setData(int index, float value)
    {
        _datas[index] = value;
    }
    public float getData(int index) { return _datas[index]; }

    public Gene Evolution(Gene mother)
    {
        float rangeValue = 0;
        if (Random.Range(0, 100) < 3)
        {
            rangeValue = Random.Range(0.0f, 4.0f);
        }

        Gene result = new Gene(this);
        int slot = Random.Range(0, _datas.Count - 1);
        result.setData(slot, mother.getData(slot) + rangeValue);
        return result;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("{ ");
        _datas.ForEach((float value) => 
        {
            sb.Append(value).Append(" ");
        });
        sb.Append("} = ").Append(Rank);
        return sb.ToString();
    }
}