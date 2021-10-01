/*
* Author: Matthew Arthur
* 
* Date: 10/1/21
* 
* Purpose: Demonstrate a solution to the common "FizzBuzz" problem. In this problem, a list of numbers is entered.
* If the number is divisibile by 3, the program outputs "Fizz." If the number is divisible by 5, the program outputs "Buzz."
* If it is divisible by both, it outputs both.
*/

//Libraries
#include <iostream>

int main() {
	for (int i = 1; i <= 100; i++) {
		if (i % 3 == 0 && i % 5 == 0) {
			std::cout << "FizzBuzz ";
		} //if
		else if (i % 3 == 0) {
			std::cout << "Fizz ";
		} //elseif
		else if (i % 5 == 0) {
			std::cout << "Buzz ";
		} //elseif
		else {
			std::cout << i << " ";
		} //else
	} //for

	std::cout << std::endl;

	system("pause");
	return 0;
} //main