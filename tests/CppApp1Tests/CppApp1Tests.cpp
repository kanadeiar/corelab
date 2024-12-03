#include "pch.h"
#include "CppUnitTest.h"
#include "../../src/CppApp1/MyClass.cpp"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;
using namespace std;

namespace CppApp1Tests
{
	TEST_CLASS(MyClassTests)
	{
	public:
		
		TEST_METHOD(GetName)
		{
			string expected = "Bill";
			MyClass mc(expected);

			auto actual = mc.GetName();

			Assert::AreEqual(expected, actual);
		}
	};
}
