#include "MyClass.h"

MyClass::MyClass(string name)
{
    _name = name;
}

MyClass::~MyClass()
{
}

/// <summary>
/// ��������� �����
/// </summary>
/// <returns>���</returns>
string MyClass::GetName()
{
    return _name;
}