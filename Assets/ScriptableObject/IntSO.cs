using UnityEngine;

[CreateAssetMenu]
public class IntSO : ScriptableObject
{
  [SerializeField]
  private int _value;
  public int value
  {
    get { return _value; }
    set { _value = value; }
  }

}
