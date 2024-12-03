#include "MyClass.h"

MyClass::MyClass(string name)
{
    _name = name;
}

MyClass::~MyClass()
{
}

/// <summary>
/// Получение имени
/// </summary>
/// <returns>Имя</returns>
string MyClass::GetName()
{
    return _name;
}