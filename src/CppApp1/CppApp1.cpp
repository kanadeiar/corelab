#include <iostream>
#include <windows.h>
#include "MyClass.h"

using namespace std;

int main()
{
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
    cout << "Лаборатория C++" << endl << endl;

    auto cl = new MyClass("once");
    auto name = cl->GetName();

    cout << "name: " << name;

    delete cl;

    cout << endl << "Для завершения нажать любую кнопку ...";
    cin.get();
    return 0;
}


