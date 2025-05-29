#pragma once
#include <string>

using namespace std;

class MyClass
{
public:
	MyClass(string name);
	~MyClass();
    string GetName();

private:
    string _name;
};

