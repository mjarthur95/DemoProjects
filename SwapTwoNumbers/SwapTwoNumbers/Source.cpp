/*
* Author: Matthew Arthur
* 
* Date: 10/1/21
* 
* Purpose: Demonstrate the algorithm to swap two numbers without using creating a temporary value holder, instead
* using algebra to swap the values
*/

//Libraries
#include <iostream>

int main() {

	int a, b;

	std::cout << "Enter your two numbers here: ";
	std::cin >> a >> b;

	//a = a + b
	a += b;

	//b = (a + b) - b = a + (b - b) = a
	b = a - b;

	//a = (a + b) - a = b + (a - a) = b
	a -= b;

	std::cout << "The value of a is " << a << std::endl;
	std::cout << "The value of b is " << b << std::endl;


	system("pause");
	return 0;
}