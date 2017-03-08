using System;

public class PhoneNumber
{
    private string _number;
    public PhoneNumber(string phoneNumber)
    {
        _number = System.Text.RegularExpressions.Regex.Replace(phoneNumber, @"[^\d]", string.Empty);
        if( _number.Length < 10)
        {
            _number = new string('0', 10);
        }
        else if( _number.Length > 11 || _number.Length==11 && _number[0] != '1')
        {
            _number = new string('0', 10);
        }
        else if(_number.Length == 11 && _number[0] == '1')
        {
            _number = _number.Substring(1);
        }
    }

    public string Number => _number;

    public string AreaCode => _number.Substring(0, 3);

    public override string ToString() => $"({_number.Substring(0,3)}) {_number.Substring(3,3)}-{_number.Substring(6)}";
}